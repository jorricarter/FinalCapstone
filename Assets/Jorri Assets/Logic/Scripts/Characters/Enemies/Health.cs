using UnityEngine;

public class Health : MonoBehaviour
{

    //serialize, makes this variable editable through GUI when testing the level.
    [SerializeField]
    private int startingHealth = 100;

    public int currentHealth;

    private void OnEnable()
    {

        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
    }
}