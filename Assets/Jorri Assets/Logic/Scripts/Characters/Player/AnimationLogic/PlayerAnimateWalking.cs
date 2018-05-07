using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimateWalking : MonoBehaviour {

    //serialize, makes this editable when I test the level-Scene in unity.
    [SerializeField]
    //setting the range makes it a slider in settings menu when testing the level-scene.
    [Range(1, 100)]
    private int walkRate = 100;

    //this lets me add a list of footstepsounds
    [SerializeField]
    private AudioClip[] FootstepSounds;

    private AudioSource audioSource;
    Vector3 lastPosition;
    private float distanceTraveled = 0f;


    private void Start(){
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position;
    }

    //Update is called once per frame
    private void Update(){
        distanceTraveled += (Vector3.Distance(transform.position, lastPosition)/100);
        //this checks if enough time has passed since our last footstep.
        if (distanceTraveled >= walkRate) {
            distanceTraveled = 0f;
            FootstepSound();
        }
    }

    private void FootstepSound()
    {
        //this skips the first index to reserve it for the most recently played sound
        int n = Random.Range(1, FootstepSounds.Length);
        audioSource.clip = FootstepSounds[n];
        audioSource.PlayOneShot(audioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        FootstepSounds[n] = FootstepSounds[0];
        FootstepSounds[0] = audioSource.clip;
    }
}
