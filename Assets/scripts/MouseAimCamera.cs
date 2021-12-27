using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MouseAimCamera : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 2555;
    Vector3 offset;
    Vector2 currentMouseValue;
    bool isMouseMoving;
    public float desireAngle;
    @PlayerInputs input;

    void Start()
    {
        target = transform.parent.gameObject;
        input = target.GetComponent<PlayerMovement>().input;
        offset = target.transform.position - transform.position;
        input.Player.Look.performed += handleLook;
    }

    private void handleLook(CallbackContext ctx)
    {
        Vector2 newMouseValue = ctx.ReadValue<Vector2>();
        this.isMouseMoving = this.currentMouseValue.x != newMouseValue.x;
        this.currentMouseValue = newMouseValue;
    }

    void LateUpdate()
    {
        if (isMouseMoving)
        {
            float horizontal = (currentMouseValue.x) * rotateSpeed * Time.deltaTime;
            target.transform.Rotate(0, horizontal, 0);

            float desiredAngle = target.transform.eulerAngles.y;
            this.desireAngle = desiredAngle;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = target.transform.position - (rotation * offset);

            transform.LookAt(target.transform);
        }
    }
}
