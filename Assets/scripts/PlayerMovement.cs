using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Rigidbody rigidbody;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 200;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public bool moveInputPressed;
    Vector2 currentMovement;
    public @PlayerInputs input;
    private MeleeWeapon meleeWeapon;
    private AttackTarget attackTarget;

    private void Awake()
    {
        input = new @PlayerInputs();
        meleeWeapon = gameObject.GetComponentInChildren<MeleeWeapon>();
        // input.Player.Move.performed += ctx => this.movement(ctx);
        //input.Player.Fire.performed += ctx =>
        //{
        //    // rigidbody.AddForce(new Vector3(0,50,0));
        //    meleeWeapon.Fire();
        //};
        attackTarget = gameObject.GetComponent<AttackTarget>();
    }

    public void OnMove(CallbackContext ctx)
    {
        this.currentMovement = ctx.ReadValue<Vector2>();
        this.moveInputPressed = this.currentMovement.x != 0 || this.currentMovement.y != 0;
    }

    public void OnJump(CallbackContext ctx)
    {
        if (attackTarget.isDown)
        {
            attackTarget.getUp();
        }
        //this.currentMovement = ctx.ReadValue<Vector2>();
        //this.moveInputPressed = this.currentMovement.x != 0 || this.currentMovement.y != 0;
    }

    private void movement(CallbackContext ctx) {
        this.currentMovement = ctx.ReadValue<Vector2>();
        this.moveInputPressed = this.currentMovement.x != 0 || this.currentMovement.y != 0;
    }

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackTarget.isDown)
        {
            //groundedPlayer = controller.isGrounded;
            //if (groundedPlayer && playerVelocity.y < 0)
            //{
            //    playerVelocity.y = 0f;
            //}
            if (moveInputPressed)
            {
                Vector3 move = new Vector3(currentMovement.x, 0, currentMovement.y);
                float facing = transform.eulerAngles.y;
                Vector3 myTurnedInputs = Quaternion.Euler(0, facing, 0) * move;
                Vector3 trueMove = myTurnedInputs * Time.deltaTime * playerSpeed;
                rigidbody.AddForce(trueMove);
                // trueMove.y = 0;
                // trueMove.y = 0;
                Debug.Log("x: " + trueMove.x);
                Debug.Log("y: " + trueMove.y);
                Debug.Log("z: " + trueMove.z);
                // controller.Move(trueMove);
            }

            // Changes the height position of the player..
            //if (Input.GetButtonDown("Jump") && groundedPlayer)
            //{
            //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            //}

            // playerVelocity.y += gravityValue * Time.deltaTime;
            // controller.Move(playerVelocity * Time.deltaTime);
        }
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
