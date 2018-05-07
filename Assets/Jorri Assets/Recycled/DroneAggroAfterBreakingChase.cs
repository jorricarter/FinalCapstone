using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneAggroAfterBreakingChase : MonoBehaviour {

    //    [SerializeField]
    //    Transform destination;
    //
    //    NavMeshAgent navMeshAgent;

    [SerializeField]
    private int attackDamage = 1;

    [SerializeField]
    private float attackRate = 1;

    private PlayerMovement detectedMovement;
    private Health detectedHealth;
    private float attackTimer;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
//    private Transform detectedTarget;


    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public event Action<Transform> OnAggro = delegate { };

    private void OnTriggerEnter(Collider other) {

        detectedMovement = other.GetComponent<PlayerMovement>();

        //if detected object has a 'playermovement' component, it's a user.
        if (detectedMovement != null) {
            //Enemy aggro on user's position
            OnAggro(detectedMovement.transform);
            Debug.Log("DetectedByDrone");
            OnAggro += AggroDetection;
            //get health of player to do damage to
            detectedHealth = other.GetComponent<Health>();
            //update animator of enemy's movements.
            float currentSpeed = navMeshAgent.velocity.magnitude;
            animator.SetFloat("Speed", currentSpeed);
        }
    }

    //I might put more in here later.
    private void AggroDetection(Transform detectedPosition) {
//        detectedTarget = detectedPosition;
    }

    private void Update() {
        
        if (detectedHealth != null) {
            attackTimer += Time.deltaTime;
            if (CanAttack()) {
//                //navigate toward user
//                navMeshAgent.SetDestination(detectedMovement.transform.position);
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
//TODO add shooting logic/particles
        detectedHealth.TakeDamage(attackDamage);
    }
}
