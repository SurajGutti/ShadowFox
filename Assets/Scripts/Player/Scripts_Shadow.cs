using UnityEngine;

public class Scripts_Shadow : MonoBehaviour
{
    private Scripts_PlayerMovement player;

    public Scripts_ManaBar manaBar;

    [SerializeField] private int maxMana;
    [SerializeField] private int manaDrain;
    [SerializeField] private int manaRecharge;

    [HideInInspector] public int currentMana;

    private void Awake()
    {
        player = GetComponent<Scripts_PlayerMovement>();

        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    private void Update()
    {
        if (player.isShadow)
        {
            currentMana -= manaDrain;

            if (currentMana <= 0)
            {
                player.isShadow = false;
            }
        }
        else
        {
            if (currentMana < maxMana)
                currentMana = Mathf.Clamp(currentMana + manaRecharge, 0, maxMana);
            else
            {
                player.isShadow = false;
            }
        }

        manaBar.SetMana(currentMana);
    }

    public void ShadowForm()
    {
        if (!player.isShadow && currentMana > 0)
        {
            player.isShadow = true;
            FindObjectOfType<Scripts_AudioManager>().Play("PlayerShadowEnter");
        }
        else
        {
            player.isShadow = false;
            FindObjectOfType<Scripts_AudioManager>().Play("PlayerShadowExit");
        }
    }

    public bool AddMana(int _mana)
    {
        if (currentMana < maxMana)
        {
            currentMana = Mathf.Clamp(currentMana + _mana, 0, maxMana);
            manaBar.SetMana(currentMana);
            FindObjectOfType<Scripts_AudioManager>().Play("PickUp");
            return true;
        }
        else return false;
    }
}
