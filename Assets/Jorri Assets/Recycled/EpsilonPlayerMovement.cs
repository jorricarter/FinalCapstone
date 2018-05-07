using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I can't access 'ThirdPersonCharacter' without this so maybe this is a very local import of the component??
namespace UnityStandardAssets.Characters.ThirdPerson {

    public class EpsilonPlayerMovement : MonoBehaviour {

        private ThirdPersonCharacter characterController;
        //This is to get the camera's transform which gets its position, rotation and scale so I'm assuming this gets its coordinates.
        private Transform cameraCoordinates;
        //This is to get the user's relative 'forward', 'left', 'right' when directional inputs are received.
        private Vector3 cameraVector;
        private Vector3 characterMovement;
        //whether character is jumping
        private bool jumping;

        private void Start() {
            cameraCoordinates = Camera.main.transform;
            characterController = GetComponent<ThirdPersonCharacter>();
        }

        //update is called every frame
        private void Update() {
            if (!jumping) {
                jumping = Input.GetButtonDown("Jump");
            }
        }

        private void FixedUpdate() {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            //get the vector of the camera to figure out the user's relative 'forward', and other directions.
            cameraVector = Vector3.Scale(cameraCoordinates.forward, new Vector3(1, 0, 1)).normalized;
            characterMovement = vertical * cameraVector + horizontal * cameraCoordinates.right;
            characterController.Move(characterMovement, false, jumping);
            jumping = false;
        }
    }
}
