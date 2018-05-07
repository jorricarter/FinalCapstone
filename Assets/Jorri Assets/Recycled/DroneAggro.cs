using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAggro : MonoBehaviour {

    private PlayerMovement movement;

    public event Action<Transform> Aggro = delegate { };

    private void OnTriggerEnter(Collider other) {
        movement = other.GetComponent<PlayerMovement>();
        if (movement != null) {
            Aggro(movement.transform);
        }
    }
}
