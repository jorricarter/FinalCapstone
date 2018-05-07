using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour {

    //making this accessible by other scripts so stats and info will only pop up when player is looking at something closely.
    public static float LookingDistance;
    public static GameObject weapons;
    public static int quantityGameGuns;


    private RaycastHit raycastHit;
    private GameObject equippedWeapon;
    private static GameObject weaponDisplays;
    private static GameObject currentDisplay;


    private void Awake()
    {
        //this gets the 'guns' object if it is a child of the 'player' that this script is attached to.
        weapons = this.transform.Find("Weapons").gameObject;
        weaponDisplays = this.transform.Find("PlayerHUD/WeaponDisplay").gameObject;
        //get number of guns in game.
        quantityGameGuns = weapons.transform.childCount;
    }

    private void FixedUpdate () {
        //check how far it is from cameraview to the first collider the player's vision hits.
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out raycastHit))
        {
            LookingDistance = raycastHit.distance;
        }
    }

    public static void GrabWeapon(String equipping)
    {
        GameObject active = CurrentWeapon(out active);
        Debug.Log("active = " + active);
        DisableWeapon(active);
        ActivateWeapon(equipping);
    }

    private static GameObject CurrentWeapon(out GameObject weapon)
    {
        //loop through all weapons.
        for (int i = 0; i < weapons.transform.childCount; i++) {
            weapon = weapons.transform.GetChild(i).gameObject;
            if (weapon.activeSelf)
            {
                Debug.Log("weapon found");
                currentDisplay = weaponDisplays.transform.GetChild(i).gameObject;
                return weapon;
            }
        }
        Debug.Log("weapon not found");
        return weapon = null;
    }

    private static void DisableWeapon(GameObject active)
    {
        active.SetActive(false);
        currentDisplay.SetActive(false);
        Debug.Log("weapon Deactivated");
    }

    private static void ActivateWeapon(string equipping)
    {
        GameObject weapon = weapons.transform.Find(equipping).gameObject;
        GameObject display = weaponDisplays.transform.Find(equipping).gameObject;
        weapon.SetActive(true);
        display.SetActive(true);
    }
}
