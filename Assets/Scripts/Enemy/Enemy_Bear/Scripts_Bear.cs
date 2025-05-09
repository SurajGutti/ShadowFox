using UnityEngine;

public class Scripts_Bear : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float distance;
    [SerializeField] private bool movingLeft;

    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - distance;
        rightEdge = transform.position.x + distance;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector2(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            }
            else movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector2(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            }
            else movingLeft = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Scripts_PlayerMovement player = GameObject.FindGameObjectWithTag("Player").GetComponent<Scripts_PlayerMovement>();
            if (!player.isShadow)
            {
                collision.GetComponent<Scripts_Health>().TakeDamage(damage);
            }
        }
    }
}
