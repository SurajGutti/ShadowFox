using UnityEngine;

public class Scripts_HeallthCollectible : MonoBehaviour
{
    [SerializeField] private int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Scripts_Health playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Scripts_Health>();

            if (playerHealth.AddHealth(value)) gameObject.SetActive(false);
        }
    }
}
