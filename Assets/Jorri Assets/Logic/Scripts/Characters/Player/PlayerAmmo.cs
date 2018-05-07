using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmmo : MonoBehaviour {

    [SerializeField] private int MaxAmmo = 100;


    public static int CurrentAmmo = 100;
    private Text ammoDisplay;


	void Awake () {
        ammoDisplay = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        AmmoCap();
        ammoDisplay.text = CurrentAmmo + "/" + MaxAmmo;
	}

    private void AmmoCap()
    {
        if (CurrentAmmo > MaxAmmo)
        {
            CurrentAmmo = MaxAmmo;
        }
    }
}
