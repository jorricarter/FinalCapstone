using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunAK47 : MonoBehaviour {




    private void OnEnable()
    {
        PlayerGun.PlayerDamage = 80;
        PlayerGun.PlayerFireRate = .22f;
        PlayerGun.PlayerGunAutomatic = true;
    }

    private void OnDisable()
    {
        PlayerGun.PlayerDamage = 100;
        PlayerGun.PlayerFireRate = .40f;
        PlayerGun.PlayerGunAutomatic = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
