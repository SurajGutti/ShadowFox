using UnityEngine;

public class Scripts_Key : MonoBehaviour
{
    [SerializeField] private Scripts_GameManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<Scripts_AudioManager>().Play("PickUp");
            levelManager.chestOpened = true;
            gameObject.SetActive(false);
        }
    }
}
