using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLocalized : MonoBehaviour
{

    //    private MouseLook mouseView;
//    private CharacterController characterController;
//    private Camera cameraView;
    //This is to get the camera's transform which gets its position, rotation and scale so I'm assuming this gets its coordinates.
//    private Transform cameraCoordinates;
    private Vector2 directionInput;
    //This is to get the user's relative 'forward', 'left', 'right' when directional inputs are received.
//    private Vector3 cameraVector;
//    private Vector3 characterMovement;
    //whether character is jumping
    private bool jumping;
    private Animator animator;

    //this makes this variable editable from the unity play screen.
//    [SerializeField]
    //setting the range makes it a slider in settings menu when testing the level-scene.
//    [Range(1, 100)]
    //this needs to be a float or dividing by 100 to get the percentage will result in 0 most of the time.
//    private float MovementSpeed = 100;

//    [SerializeField]
//    private float turnSpeed = 2;

    private void Start()
    {
//        characterController = GetComponent<CharacterController>();
//        cameraView = Camera.main;
//        cameraCoordinates = cameraView.transform;
        //        mouseView.Init(transform, cameraCoordinates);
        animator = GetComponentInChildren<Animator>();
    }

    //update is called every frame
    private void Update()
    {
//        ViewTilt();

        if (!jumping)
        {
            jumping = Input.GetButtonDown("Jump");
        }

        //        if (characterMovement.magnitude > 0) {
        //get the direction the character is moving
        //            Quaternion movementDirection = Quaternion.LookRotation(characterMovement);
        //change rotation of player-animation and camera-view to align with the movementDirection. Slerp allows me to control turnspeed so character doesn't teleport front-back or left-right when changing direction.
        //            transform.rotation = Quaternion.Slerp(transform.rotation, movementDirection, Time.deltaTime * turnSpeed);
        //        }
    }

    private void FixedUpdate()
    {
        //get direction user is inputting such as arrow keys.
//        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //get the vector of the camera to figure out the user's relative 'forward', and other directions.
        //        cameraVector = Vector3.Scale(cameraCoordinates.forward, new Vector3(1, 0, 1)).normalized;
        //        Vector3 intendedMove = transform.forward * directionInput.y + transform.right * directionInput.x;
//        characterMovement = vertical * cameraVector + horizontal * cameraCoordinates.right;
        //        characterMovement.x = intendedMove.x;
        //        characterMovement.y = intendedMove.y;
        animator.SetFloat("Speed", vertical);
        //        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        //check if y axis on controller or arrow keys is positive or negative. If not, we should not move after rotating.
//        if (vertical != 0)
//        {
//            Move(characterMovement, jumping);
//        }
//        jumping = false;
//    }
//
//    private void Move(Vector3 movement, bool jumping)
//    {
        //this maintains speed consistency by keeping the magnitude capped at 1 after calculating the horizontal and vertical direction.
        //        if (movement.magnitude > 1f) movement.Normalize();
        //        movement = transform.InverseTransformDirection(movement);
        //        movement = Vector3.ProjectOnPlane(movement, ground);
//        characterController.Move(movement * MovementSpeed);
//    }

//    private void ViewTilt()
//    {
        //        mouseView.LookRotation(transform, cameraCoordinates);
    }
}
