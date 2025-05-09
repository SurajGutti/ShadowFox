using UnityEngine;

public class Scripts_BearTop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBottom")
        {
            Scripts_PlayerMovement player = GameObject.FindGameObjectWithTag("Player").GetComponent<Scripts_PlayerMovement>();
            if (!player.isShadow)
            {
                GameObject enemy = this.transform.parent.gameObject;
                enemy.SetActive(false);
                player.Jump();
            }
        }
    }
}
