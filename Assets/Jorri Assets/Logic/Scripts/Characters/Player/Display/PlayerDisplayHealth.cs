using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplayHealth : MonoBehaviour {

//    private PlayerHealth playerHealth;
//    private int healthPoints;
    private RectTransform display;


    private void Awake()
    {
//        playerHealth = gameObject.GetComponentInParent<PlayerHealth>();
//        healthPoints = playerHealth.currentHealth;
        display = GetComponent<RectTransform>();
    }

    //I'm not putting this in generic update because it desn't need to update every frame.
    public void HealthUpdate(int healthPoints)
    {
        display.sizeDelta = new Vector2(healthPoints * 3, 20);
    }
}
