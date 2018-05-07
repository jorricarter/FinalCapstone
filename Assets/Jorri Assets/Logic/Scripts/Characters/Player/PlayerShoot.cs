using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public Camera playerCamera;

    //this is a point I created on the character where bullet logic and raycasts begin.
    [SerializeField]
    public Transform firePoint;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            GameObject bulletObject = PoolingManager.Instance.GetBullet();
            bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            bulletObject.transform.forward = playerCamera.transform.forward;
        }
	}
}
