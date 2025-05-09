using UnityEngine;

public class Scripts_Health : MonoBehaviour
{
    public Scripts_Healthbar healthBar;

    [SerializeField] private int maxHealth;
    private Scripts_GameManager gameManager;

    private int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentHealth = maxHealth;
        gameManager = FindAnyObjectByType<Scripts_GameManager>();

        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            gameManager.GameOver();
            gameManager.gameOverMenu = true;
            FindObjectOfType<Scripts_AudioManager>().Play("PlayerDeath");
        }
        else
        {
            FindObjectOfType<Scripts_AudioManager>().Play("PlayerHurt");
        }
    }

    public void SetHealth() { 
    }

    public bool AddHealth(int _health)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Clamp(currentHealth + _health, 0, maxHealth);
            healthBar.SetHealth(currentHealth);
            FindObjectOfType<Scripts_AudioManager>().Play("PickUp");
            return true;
        }
        else return false;
    }
}
