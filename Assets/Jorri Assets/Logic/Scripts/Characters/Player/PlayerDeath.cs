using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameObject deathDisplay;
    private PlayerMovement playerMovement;
    private Animator animator;


    private void Awake()
    {
        deathDisplay = this.transform.Find("PlayerHUD/DeathDisplay").gameObject;
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();
    }

    public void Die()
    {
        //TODO make death animation and call it from here.
        animator.SetTrigger("Die");
        deathDisplay.SetActive(true);
        playerMovement.enabled = false;
    }
}
