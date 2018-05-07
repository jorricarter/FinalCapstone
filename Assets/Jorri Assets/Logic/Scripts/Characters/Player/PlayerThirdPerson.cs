using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerThirdPerson : MonoBehaviour {
    private CharacterController m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
    
    private void Start()
    {
        // get the transform of the main camera
        m_Cam = Camera.main.transform;
        // get the third person character ( this should never be null due to require component )
        m_Character = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        if (!m_Jump) {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }
    
    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        // read inputs
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        // calculate move direction to pass to character
        // calculate camera relative direction to move:
        m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
        m_Move = v * m_CamForward + h * m_Cam.right;

        // pass all parameters to the character control script
        m_Character.Move(m_Move);
        m_Jump = false;
    }
}
