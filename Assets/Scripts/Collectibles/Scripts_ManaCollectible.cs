using UnityEngine;

public class Scripts_ManaCollectible : MonoBehaviour
{
    [SerializeField] private int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Scripts_Shadow playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<Scripts_Shadow>();

            if (playerMana.AddMana(value)) gameObject.SetActive(false);
        }
    }
}
