using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

    [SerializeField] private int AmmoReward = 10;


    private Animator animator;
    private EnemyAggro movement;
    private EnemyShoot attack;


    private void Awake()
    {
        //I don't need these, but the animation acts weird without disabling these.
        animator = GetComponent<Animator>();
        movement = GetComponent<EnemyAggro>();
        attack = GetComponent<EnemyShoot>();
    }

    public void Die() {
        //disable enemy movement
        movement.enabled = false;
        attack.enabled = false;
        animator.SetTrigger("Die");
        gameObject.SetActive(false);
    }
    
    //since the last line of 'die()' disables the object, this 'OnDisable' method will be called immediately after.
    private void OnDisable() {
        DeathReward();
    }

    private void DeathReward()
    {
        PlayerAmmo.CurrentAmmo += AmmoReward;
    }
}
