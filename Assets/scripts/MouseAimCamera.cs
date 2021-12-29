using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MouseAimCamera : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 10f;
    Vector3 offset;
    Vector2 currentMouseValue;
    bool isMouseMoving;
    public float desireAngle;
    private Camera camera;
    private GameObject selectedItem;

    private const float YMin = -50.0f;
    private const float YMax = 50.0f;

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity = 4.0f;
    // @PlayerInputs input;

    void Start()
    {
        camera = gameObject.GetComponent<Camera>();
        target = transform.parent.gameObject;
        // input = target.GetComponent<PlayerMovement>().input;
        offset = target.transform.position - transform.position;
        // input.Player.Look.performed += handleLook;
    }

    public void handleLook(CallbackContext ctx)
    {
        Vector2 newMouseValue = ctx.ReadValue<Vector2>();
        this.isMouseMoving = this.currentMouseValue.x != newMouseValue.x || this.currentMouseValue.y != newMouseValue.y;
        this.currentMouseValue = newMouseValue;
    }

    void LateUpdate()
    {
        if (isMouseMoving)
        {
            float horizontal = (currentMouseValue.x) * rotateSpeed * Time.deltaTime;
            float vertical = (currentMouseValue.y) * rotateSpeed * Time.deltaTime;
            target.transform.Rotate(0, horizontal, 0);

            currentX += currentMouseValue.x * rotateSpeed * Time.deltaTime;
            currentY -= currentMouseValue.y * rotateSpeed * Time.deltaTime;

            currentY = Mathf.Clamp(currentY, YMin, YMax);

            Vector3 Direction = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            transform.position = target.transform.position + rotation * Direction;

            transform.LookAt(target.transform.position);
            
            //target.transform.Rotate(0, horizontal, 0);

            //float desiredAngle = target.transform.eulerAngles.y;
            //this.desireAngle = desiredAngle;
            //Quaternion rotation = Quaternion.Euler(vertical, desiredAngle, 0);
            //transform.position = target.transform.position - (rotation * offset);

            //transform.LookAt(target.transform);
        }
        // handleGrabableItems();
    }

    private void handleGrabableItems() {
        Ray ray = new Ray(transform.position, transform.forward);
        int layerMask = LayerMask.GetMask("GameItems");
        if (Physics.Raycast(ray, out RaycastHit hit, 1000, layerMask)) {
            if (selectedItem != hit.collider.gameObject)
            {
                selectedItem = hit.collider.gameObject;
                selectedItem.GetComponent<GameItem>().handleIsSeen(target);
            }
        }
        else if (selectedItem != null)
        {
            selectedItem.GetComponent<GameItem>().handleIsNotSeen(target);
            selectedItem = null;
        }
    }
}
