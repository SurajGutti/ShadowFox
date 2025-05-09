using UnityEngine;

public class Scripts_Enemy_Shooting : MonoBehaviour
{
    /*private Rigidbody2D enemyBody;
    private BoxCollider2D enemyCollider;
    private SpriteRenderer enemySprite;*/
    private float timer;

    [SerializeField] private float cooldown;
    [SerializeField] private Transform firingPoint;
    [SerializeField] public GameObject fireBall;

    /*void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<BoxCollider2D>();
        enemySprite = GetComponent<SpriteRenderer>();
    }*/

    // Update is called once per frame
    void Update()
    {
        if (timer > cooldown)
            Attack();

        timer += Time.deltaTime;
    }

    private void Attack()
    {
        timer = 0;

        Instantiate(fireBall, firingPoint.position, firingPoint.rotation);
        fireBall.transform.position = firingPoint.position;
    }

}
