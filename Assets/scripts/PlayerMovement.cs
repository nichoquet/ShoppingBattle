using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 200.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public bool moveInputPressed;
    Vector2 currentMovement;
    public @PlayerInputs input;
    private MeleeWeapon meleeWeapon;

    private void Awake()
    {
        input = new @PlayerInputs();
        meleeWeapon = gameObject.GetComponentInChildren<MeleeWeapon>();
        input.Player.Move.performed += ctx => this.movement(ctx);
        input.Player.Fire.performed += ctx => meleeWeapon.Fire();
    }

    private void movement(CallbackContext ctx) {
        this.currentMovement = ctx.ReadValue<Vector2>();
        this.moveInputPressed = this.currentMovement.x != 0 || this.currentMovement.y != 0;
        //groundedPlayer = controller.isGrounded;
        //if (groundedPlayer && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        //}

        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //float facing = transform.eulerAngles.y;
        //Vector3 myTurnedInputs = Quaternion.Euler(0, facing, 0) * move;
        //Vector3 trueMove = myTurnedInputs * Time.deltaTime * playerSpeed;
        //controller.Move(trueMove);

        //// Changes the height position of the player..
        //if (Input.GetButtonDown("Jump") && groundedPlayer)
        //{
        //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //}

        //playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
    }

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        if (moveInputPressed)
        {
            Vector3 move = new Vector3(currentMovement.x, 0, currentMovement.y);
            float facing = transform.eulerAngles.y;
            Vector3 myTurnedInputs = Quaternion.Euler(0, facing, 0) * move;
            Vector3 trueMove = myTurnedInputs * Time.deltaTime * playerSpeed;
            controller.Move(trueMove);
        }

        // Changes the height position of the player..
        //if (Input.GetButtonDown("Jump") && groundedPlayer)
        //{
        //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //}

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnEnable()
    {
        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }
}
