using UnityEngine;

public class Scripts_Fall : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Scripts_PlayerMovement player = GameObject.FindGameObjectWithTag("Player").GetComponent<Scripts_PlayerMovement>();
            collision.GetComponent<Scripts_Health>().TakeDamage(damage);
        }
    }
}
