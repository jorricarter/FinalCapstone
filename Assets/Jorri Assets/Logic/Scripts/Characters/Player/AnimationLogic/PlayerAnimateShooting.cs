using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimateShooting : MonoBehaviour {

    private Animator animator;


    //serialize, makes this editable when I test the level-Scene in unity.
    [SerializeField]
    //how long to wait after shooting before killing the shooting animation. (too short, looks unatural.)
    private float shootingAnimationTime = .25f;

    [SerializeField]
    private AudioSource gunSound;

//    [SerializeField] private ParticleSystem gunFlash;
//
//    [SerializeField]
//    [Range(0.25f, 3f)]
//    private float fireRate = .25f;
//
    //this is a timer for how long to wait before killing the shooting animation.
    private float graphicTimer;
    private GameObject crosshair;

//    private float audioTimer;

        
    //Awake is called when game loads, before it starts.
    void Awake () {
        animator = GetComponent<Animator>();
	}

//    //I put audio in update because it wasn't responding very quickly in 'FixedUpdate'. 'FixedUpdate' isn't called as often.
//    private void Update () {
//        audioTimer += Time.deltaTime;
//        if (audioTimer >= fireRate && Input.GetButtonDown("Fire1")) {
//            audioTimer = 0f;
//            gunSound.Play();
//        }
//    }
//
    //I chose fixedupdate instead of updated because I think it's called less than update and is less likely to slow down the game.
    void FixedUpdate () {
        graphicTimer += Time.deltaTime;
        //"Fire1" can be set in seetings. It is currently mapped to main fire buttons like mouseclick0(left) and various keys.
        if (Input.GetButtonDown("Fire1")) {
            //starts graphic for gunflash. this should be in the if statement above after I polish the graphics.
//            gunFlash.Play();
            graphicTimer = 0f;
            //animator triggers shooting animation when it's "shooting" var is set to true.
            animator.SetBool("Shooting", true);
        }
        //this checks if enough time has passed since our last shot.
        else if (graphicTimer >= shootingAnimationTime) {
            //not shooting and animator has had enough time to look natural so que animator to start the animation for transferring from shooting to idle.
            animator.SetBool("Shooting", false);
        }
	}

//    public void PlayerShoot () {
//        //starts animation I made for the crosshair
//        crosshair.GetComponent(Animator).enabled = true;
//        //starts graphic for gunflash. this should be in the if statement above after I polish the graphics.
//        gunFlash.Play();
//        graphicTimer = 0f;
//        //animator triggers shooting animation when it's "shooting" var is set to true.
//        animator.SetBool("Shooting", true);
//        PlayerDoneShooting();
//    }
//
    private void PlayerDoneShooting() {
//TODO wait a couple seconds before reseting animation signal.
    }
}
