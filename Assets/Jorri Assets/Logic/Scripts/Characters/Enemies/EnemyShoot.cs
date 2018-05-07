using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    //serializefield makes it show in editor gui and it is easier to adjust from enemy to enemy.
    [SerializeField] private int attackDamage = 10;
    [SerializeField] [Range(0, 60)] private float attackRate = 1f;
    [SerializeField] [Range(0, 5)] private float attackVariance = .50f;
    //    [SerializeField] private float attackRange = 1f;
    //these 2 lines will make me able to drag-and-drop the particles and sounds to the enemies.
    [SerializeField] private ParticleSystem gunFlash;
    [SerializeField] private AudioSource gunSound;
    [SerializeField] private Transform FirePoint;


    private EnemyAggro enemyAggro;
    private PlayerHealth playerHealth;
    private PlayerDeath death;
    private float attackTimer;


    private void Awake()
    {
        enemyAggro = GetComponent<EnemyAggro>();
        enemyAggro.Aggro += AggroDetection;
        //this is so they don't get to shoot you the instant they see you.
        attackTimer = Random.Range(-attackRate * attackVariance, 0);
    }

    private void AggroDetection(Transform detectedTarget)
    {
        //get health of player to do damage to
        PlayerHealth detectedHealth = detectedTarget.GetComponent<PlayerHealth>();
        if (detectedHealth != null)
        {
            playerHealth = detectedHealth;
            death = detectedTarget.GetComponent<PlayerDeath>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != null && playerHealth.currentHealth > 0)
        {
            attackTimer += Time.deltaTime;
            if (CanAttack())
            {
                Attack();
            }
        }
    }

    //This is in a separate method cause I might add more to whether they can attack.
    private bool CanAttack()
    {
        return attackTimer >= attackRate;
    }

    private void Attack()
    {
        attackTimer = Random.Range(-attackRate * attackVariance, 0);
        //these next 2 lines are referencing drag-and-drop fields that I drag the animations and sounds to using the serializeFields from lines 12-13.
        gunSound.Play();
        gunFlash.Play();
        playerHealth.TakeDamage(attackDamage);
        if (playerHealth.currentHealth < 1)
        {
            death.Die();

        }
        //get a physical bullet from the pool that is not in use
        GameObject currentBullet = PoolingManager.Instance.GetBullet();
        //put bullet in front of firepoint.
        currentBullet.transform.position = FirePoint.transform.position + FirePoint.transform.forward;
        currentBullet.transform.forward = (FirePoint.transform.forward);
    }
}
