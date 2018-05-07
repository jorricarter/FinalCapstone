using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerDisplayHealth playerDisplayHealth;


    //serialize, makes this variable editable through GUI when testing the level.
    [SerializeField] private int startingHealth = 100;


    public int currentHealth;


    private void Awake()
    {
        playerDisplayHealth = GetComponentInChildren<PlayerDisplayHealth>();
    }

    private void OnEnable()
    {

        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        playerDisplayHealth.HealthUpdate(currentHealth);
        if (currentHealth < 1)
        {
            enabled = false;
        }
    }
}