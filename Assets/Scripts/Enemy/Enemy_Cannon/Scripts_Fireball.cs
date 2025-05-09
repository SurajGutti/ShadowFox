using UnityEngine;

public class Scripts_fireball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D fireballCollider;

    private Rigidbody2D fireballBody;
    private bool hit;
    private Animator fireballAnimator;

    void Awake()
    {
        fireballCollider = GetComponent<BoxCollider2D>();
        fireballAnimator = GetComponent<Animator>();
        fireballBody = GetComponent<Rigidbody2D>();

        fireballBody.linearVelocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
            fireballBody.linearVelocity = new Vector2(0,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Scripts_PlayerMovement player = GameObject.FindGameObjectWithTag("Player").GetComponent<Scripts_PlayerMovement>();
            if (!player.isShadow)
            {
                collision.GetComponent<Scripts_Health>().TakeDamage(damage);
                Hit();
            } 
        }
        else
        {
            Hit();
        }
    }

    private void Hit()
    {
        hit = true;
        fireballCollider.enabled = false;
        fireballAnimator.SetTrigger("Explode");
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
