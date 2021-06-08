using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class MoveCharacterScript : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private float playerSpeed = 8.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    public Vector3 m_Move;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        // get the transform of the main camera
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool crouch = Input.GetKey(KeyCode.C);

        // calculate move direction to pass to character
        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * m_Cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_Move = v * Vector3.forward + h * Vector3.right;
        }

        // pass all parameters to the character control script
        controller.Move(m_Move);
        animator.SetBool("run", m_Move != Vector3.zero);
        m_Move.y = 0;
        transform.rotation = Quaternion.LookRotation(m_Move);
        //transform.Translate(new Vector3((Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime), 0, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime));
    }
}
