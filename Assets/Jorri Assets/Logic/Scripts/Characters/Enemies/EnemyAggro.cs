using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAggro : MonoBehaviour {

    //    [SerializeField]
    //    Transform destination;
    //
    //    NavMeshAgent navMeshAgent;


    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Transform destination;


    public event Action<Transform> Aggro = delegate { };


    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        //'+=' adds the current 'aggro' to the 'delegate' list.
        Aggro += AggroDetection;
    }

    //I might put more in here later to make pathing more tactical.
    private void AggroDetection(Transform detectedTarget) {
        destination = detectedTarget;
    }

    //when a collider set as a trigger collider is triggered, this will happen.
    private void OnTriggerEnter(Collider detected) {

        var detectedMovement = detected.GetComponent<PlayerMovement>();

        //if detected object has a 'playermovement' component, it's a user.
        if (detectedMovement != null) {
            //if it's null, it won't cause problems since it's going to the empty delegate.
            Aggro(detectedMovement.transform);
        }
    }

    // Update is called once per frame
    void Update() {
        if (destination != null) {
            //navigate toward user
            navMeshAgent.SetDestination(destination.position);
            float currentSpeed = navMeshAgent.velocity.magnitude;
            //tell navigator how fast we are going so it knows how to blend animations.
            animator.SetFloat("Speed", currentSpeed);
        }
    }
}
