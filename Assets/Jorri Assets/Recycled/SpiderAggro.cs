using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderAggro : MonoBehaviour {

    //    [SerializeField]
    //    Transform destination;
    //
    //    NavMeshAgent navMeshAgent;

    [SerializeField]
    private int attackDamage = 2;

    [SerializeField]
    private float attackRate = 1;

    private PlayerMovement detected;
    private Health detectedHealth;
    private float attackTimer;
    private NavMeshAgent navMeshAgent;
//    private Animator animator;


    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
//        animator = GetComponent<Animator>();
    }

    public event Action<Transform> OnAggro = delegate { };

    private void OnTriggerEnter(Collider other) {

        detected = other.GetComponent<PlayerMovement>();

        //if detected object has a 'playermovement' component, it's a user.
        if (detected != null) {
            OnAggro(detected.transform);
            Debug.Log("DetectedBySpider");
            OnAggro += AggroDetection;
            detectedHealth = other.GetComponent<Health>();
            GetComponent<NavMeshAgent>().SetDestination(detected.transform.position);
        }
    }

    //I might put more in here later.
    private void AggroDetection(Transform detected) {
        navMeshAgent.SetDestination(detected.position);
    }

    private void Update() {
        float currentSpeed = navMeshAgent.velocity.magnitude;
//        animator.SetFloat("Speed", currentSpeed);

        if (detectedHealth != null) {
            attackTimer += Time.deltaTime;
            if (CanAttack()) {
                Debug.Log("SpiderAttacked!");
                Attack();
            }
        }
    }

    //This is in a separate method cause I might add more to whether they can attack.
    private bool CanAttack() {
        return attackTimer >= attackRate;
    }

    private void Attack() {
        attackTimer = 0;
        detectedHealth.TakeDamage(attackDamage);
    }
}
