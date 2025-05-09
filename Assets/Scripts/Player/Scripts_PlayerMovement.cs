using UnityEngine;

public class Scripts_PlayerMovement : MonoBehaviour 
{
    private Rigidbody2D playerBody;
    private BoxCollider2D playerCollider;
    private Scripts_Shadow shadow;
    private Animator playerAnimator;

    
    [HideInInspector] public bool isShadow;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask shadowLayer;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpingVelocity;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        shadow = GetComponent<Scripts_Shadow>();
        playerAnimator = GetComponent<Animator>();

        isShadow = false;
    }

    private void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        bool grounded = isNotJumping();

        playerAnimator.SetBool("Run", horizontalMovement != 0);
        playerAnimator.SetBool("Grounded", grounded);

        playerBody.linearVelocity = new Vector2(horizontalMovement * playerSpeed, playerBody.linearVelocity.y);

        if (horizontalMovement > 0.01f)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        else if (horizontalMovement < -0.0f)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump();
         
            
        if (Input.GetKeyDown(KeyCode.X))
        {
            shadow.ShadowForm();
        }
    }

    public void Jump()
    {
        playerBody.linearVelocity = new Vector2(playerBody.linearVelocity.x, jumpingVelocity);
        FindObjectOfType<Scripts_AudioManager>().Play("PlayerJump");
    }

    private bool isNotJumping()
    {
        RaycastHit2D groundRaycast = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        RaycastHit2D enemyRaycast = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, Vector2.down, 0.1f, enemyLayer);
        RaycastHit2D shadowRaycast = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, Vector2.down, 0.1f, shadowLayer);
        if (groundRaycast || enemyRaycast || shadowRaycast) return true;
        else return false;
    }
}
