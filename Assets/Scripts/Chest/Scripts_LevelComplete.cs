using UnityEngine;

public class Scripts_LevelComplete : MonoBehaviour
{
    [SerializeField] private Scripts_GameManager gameManager;

    private bool pickUp;

    private void Start()
    {
        pickUp = false;
    }

    private void Update()
    {
        if (pickUp && Input.GetKeyDown(KeyCode.E))
        {
            gameManager.LevelComplete();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            pickUp = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            pickUp = false;
    }
}
