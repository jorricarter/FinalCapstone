using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class AlphaFirstPersonController : MonoBehaviour{
    private MouseLook mouseView;

//    private CharacterController characterController;
    private Camera cameraView;
    private Transform cameraCoordinates;
    private Vector2 directionInput;
    private Vector3 characterMovement = Vector3.zero;

    private void Start(){
//        characterController = GetComponent<CharacterController>();
        cameraView = Camera.main;
        cameraCoordinates = cameraView.transform;
		mouseView.Init(transform , cameraCoordinates);
    }


    private void Update(){
        RotateView();
    }


    private void FixedUpdate(){
        GetInput();
        // always move along the camera forward as it is the direction that it being aimed at
        Vector3 desiredMove = transform.forward*directionInput.y + transform.right*directionInput.x;

        characterMovement.x = desiredMove.x;
        characterMovement.z = desiredMove.z;

        characterMovement += Physics.gravity*Time.fixedDeltaTime;
    }


    private void GetInput(){
        // Read input
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        // set the desired speed to be walking or running
        directionInput = new Vector2(horizontal, vertical);

        // normalize input if it exceeds 1 in combined length:
        if (directionInput.sqrMagnitude > 1){
            directionInput.Normalize();
        }
    }


    private void RotateView(){
        mouseView.LookRotation (transform, cameraCoordinates);
    }
}
