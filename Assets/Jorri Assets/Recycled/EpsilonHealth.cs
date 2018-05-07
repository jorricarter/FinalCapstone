using UnityEngine;

public class EpsilonHealth : MonoBehaviour
{

    //serialize, makes this variable editable through GUI when testing the level.
    [SerializeField]
    private int startingHealth = 100;

    private int currentHealth;

    private void OnEnable()
    {

        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
            gameObject.SetActive(false);

    }

    private void Die()
    {

    }
}