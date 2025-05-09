using UnityEngine;

public class Scripts_Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorialUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            tutorialUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            tutorialUI.SetActive(false);
    }
}
