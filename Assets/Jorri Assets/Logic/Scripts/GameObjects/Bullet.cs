using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int speed = 300;
    //how many seconds bullet exists.
    public float lifeDuration = 2f;
    private float lifeTimer;
    //Since I'm pulling from a pool, 'start' wouldn't activate lifetimer for pooled bullets.
	void OnEnable () {
        lifeTimer = lifeDuration;
	}
	
	// Update is called once per frame
	void Update () {
        //move bullet each frame. deltaTime keeps speed similar on faster devices.
        transform.position += transform.forward * speed * Time.deltaTime;
        //check if bullet should be deleted
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f) {
            gameObject.SetActive(false);
        }
	}
}
