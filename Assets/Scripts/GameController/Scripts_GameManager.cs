using UnityEngine;
using UnityEngine.Tilemaps;
using Unity.Cinemachine;

public class Scripts_GameManager : MonoBehaviour
{
    public Animator chestAnimator;
    public bool chestOpened;   
    public SpriteRenderer playerSprite;
    public GameObject gameHUD;
    public GameObject menuUI;
    public GameObject gameOverUI;
    public GameObject levelCompleteUI;

    [HideInInspector] public bool isPaused = false;
    [HideInInspector] public bool gameOverMenu = false;
    [HideInInspector] public GameObject[] shadowObjects;

    [SerializeField] private int deathJump;
    [SerializeField] private float targetTime;
    [SerializeField] private GameObject keyRequiredUI;
    [SerializeField] private Scripts_PlayerMovement player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private CinemachineCamera cineMachine;

    private Scripts_GameMenu gameMenu;
    private Animator playerDead;
    private Rigidbody2D playerBody;
    private BoxCollider2D playerCollider;

    private bool canPause;
    private float currentTime = 0f;
    private float gameOverTimer = 0f;

    private void Start()
    {
        keyRequiredUI.SetActive(false);
        Time.timeScale = 1f;

        gameHUD.SetActive(true);
        canPause = true;
        shadowObjects = GameObject.FindGameObjectsWithTag("Shadow");

        playerDead = player.GetComponent<Animator>();
        playerBody = player.GetComponent<Rigidbody2D>();
        playerCollider = player.GetComponent<BoxCollider2D>();
        gameMenu = menuUI.GetComponent<Scripts_GameMenu>();
    }

    private void Update()
    {
        KeyTextCheck(targetTime);

        if (gameOverMenu)
        {
            gameOverTimer += Time.deltaTime;
            if (gameOverTimer >= 2)
                ShowGameOverMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canPause)
            {
                if (isPaused) gameMenu.Resume();
                else gameMenu.Pause();
            } 
        }

        if (player.isShadow == true)
        {
            playerSprite.color = new Color(0, 0, 0, 1);

            foreach (GameObject shadow in shadowObjects)
            {
                TilemapCollider2D collider = shadow.GetComponent<TilemapCollider2D>();
                collider.isTrigger = true;
            }
        }
        else
        {
            playerSprite.color = new Color(1, 1, 1, 1);

            foreach (GameObject shadow in shadowObjects)
            {
                TilemapCollider2D collider = shadow.GetComponent<TilemapCollider2D>();
                collider.isTrigger = false;
            }
        }
    }

    public void LevelComplete()
    {
        if (chestOpened)
        {
            chestAnimator.SetBool("LevelComplete", true);
            playerBody.linearVelocity = new Vector2(0, 0);
            player.enabled = false;
            playerAnimator.enabled = false;
            levelCompleteUI.SetActive(true);
            canPause = false;
            gameHUD.SetActive(false);
            FindObjectOfType<Scripts_AudioManager>().Play("LevelComplete");
        }
        else
        {
            keyRequiredUI.SetActive(true);
            FindObjectOfType<Scripts_AudioManager>().Play("KeyNeeded");
        }
    }

    private void KeyTextCheck(float _targetTime)
    {
        if (keyRequiredUI.activeSelf)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= _targetTime)
            {
                keyRequiredUI.SetActive(false);
                currentTime = 0f;
            }
        }
    }

    public void GameOver()
    {
        playerDead.SetTrigger("Die");
        player.isShadow = false;
        player.enabled = false;
        playerBody.linearVelocity = new Vector2(0, deathJump);
        playerCollider.enabled = false;
        cineMachine.Follow = null;
        cineMachine.LookAt = null;
        gameHUD.SetActive(false);
    }

    private void ShowGameOverMenu()
    {
        gameOverUI.SetActive(true);
        gameOverMenu = false;
        canPause = false;
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
    }

    public void NextLevel()
    {
        // Check if last level
        int nextSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
            gameOverUI.SetActive(false);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}
