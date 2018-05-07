using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGunAK47 : MonoBehaviour {

    private float distance;
    private Canvas display;


    private void Awake()
    {
        display = GetComponentInChildren<Canvas>();
    }
    private void OnMouseOver()
    {
        distance = PlayerLooking.LookingDistance;
        display.enabled = true;

        //submit is usually set to 'enter' or left Alt on computers running unity.
        if (Input.GetButton("Submit") && distance < 2)
        {
            TakeWeapon();
        }
    }

    private void TakeWeapon()
    {
        PlayerLooking.GrabWeapon("AK47");
        gameObject.SetActive(false);
    }

    private void OnMouseExit()
    {
        display.enabled = false;
    }
}
