using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayerShooting : MonoBehaviour {

    public Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
	}
	
	public void animateShootingWalk () {
        animator.Play("animateShootingWalk");
	}
}
