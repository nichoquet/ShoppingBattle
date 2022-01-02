using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MouseAimCamera : MonoBehaviour
{
    public GameObject player;
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
            // Debug.Log("Debut");
            // float posY = vertical + target.transform.localRotation.y;
            player.transform.Rotate(0, horizontal, 0);
            Vector3 angles = target.transform.rotation.eulerAngles;
            //Debug.Log(angles.x);
            angles.x -= vertical;
            if (angles.x > 180)
            {
                float trueYMin = 360 + YMin;
                if (angles.x < trueYMin) {
                    angles.x = trueYMin;
                }
            }
            else
            {
                if (angles.x > YMax)
                {
                    //Debug.Log("Max");
                    // Debug.Log(angles.x);
                    angles.x = YMax;
                }
                else if (angles.x < YMin)
                {
                    angles.x = YMin;
                    // Debug.Log("Min");
                }
            }
            // angles.x = Mathf.Clamp(angles.x, YMin, YMax);
            // Debug.Log(angles.x);
            target.transform.rotation = Quaternion.Euler(angles);
            //Debug.Log(posY);


            //if (posY <= YMax && posY > YMin)
            //{
            //    transform.parent.Rotate(new Vector3(posY - transform.parent.localRotation.y, 0, 0));
            //}
            //posY = Mathf.Clamp(posY, YMin, YMax);
            // transform.parent.localRotation = Quaternion.Euler();

            //if (Input.GetMouseButton(0))
            //{
            //    float h = rotateSpeed * currentMouseValue.x;
            //    float v = rotateSpeed * currentMouseValue.y;

            //    if (transform.eulerAngles.z + v <= 0.1f || transform.eulerAngles.z + v >= 179.9f)
            //        v = 0;

            //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + v);
            //}
            // float rotation = Mathf.Clamp(vertical, YMin + transform.rotation.eulerAngles.y, YMax - transform.rotation.eulerAngles.y);
            //Vector3 rotation = new Vector3(0, currentMouseValue.y * rotateSpeed * Time.deltaTime, 0);
            // transform.RotateAround(target.transform.position, new Vector3(1, 0, 0), vertical);
            //if (vertical < 0)
            //{
            //}
            //else if (vertical > 0)
            //{
            //    transform.RotateAround(target.transform.position, new Vector3(1, 0, 0), vertical);
            //}

            // float currentX = target.transform.rotation.x + horizontal;
            // float currentY = target.transform.rotation.y;
            //float moveX = target.transform.localEulerAngles.x + currentMouseValue.x * rotateSpeed * Time.deltaTime;
            //float moveY = target.transform.localEulerAngles.y + currentMouseValue.x * rotateSpeed * Time.deltaTime;
            //moveY = Mathf.Clamp(moveY, YMin, YMax);
            //Debug.Log(currentX);
            ////Debug.Log(this.currentX);
            //currentX += currentMouseValue.x * rotateSpeed * Time.deltaTime;
            //currentY -= currentMouseValue.y * rotateSpeed * Time.deltaTime;
            //Debug.Log(currentX);

            //currentY = Mathf.Clamp(currentY, YMin, YMax);

            //Vector3 Direction = new Vector3(0, 0, -distance);
            //Quaternion rotation = Quaternion.Euler(moveX, moveY, 0);
            //transform.position = target.transform.position + rotation * Direction;
            //Vector3 Direction = new Vector3(0, 0, -distance);
            //Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            //transform.position = target.transform.position + rotation * Direction;

            //var rotationLR = transform.localEulerAngles;
            //rotationLR.y += currentMouseValue.x * rotateSpeed;
            //transform.rotation = Quaternion.AngleAxis(rotationLR.y, Vector3.up);
            //var cameraRot = gameObject.transform.localEulerAngles;
            //cameraRot.x += currentMouseValue.y * rotateSpeed;
            //gameObject.transform.localRotation = Quaternion.AngleAxis(cameraRot.x, Vector3.right);
            // transform.LookAt(target.transform.position);

            //target.transform.Rotate(0, horizontal, 0);

            //float desiredAngle = target.transform.eulerAngles.y;
            //this.desireAngle = desiredAngle;
            //Quaternion rotation = Quaternion.Euler(vertical, desiredAngle, 0);
            //transform.position = target.transform.position - (rotation * offset);

            transform.LookAt(target.transform.position);
        }
        // handleGrabableItems();
    }

    //private void handleGrabableItems() {
    //    Ray ray = new Ray(transform.position, transform.forward);
    //    int layerMask = LayerMask.GetMask("GameItems");
    //    if (Physics.Raycast(ray, out RaycastHit hit, 1000, layerMask)) {
    //        if (selectedItem != hit.collider.gameObject)
    //        {
    //            selectedItem = hit.collider.gameObject;
    //            selectedItem.GetComponent<GameItem>().handleIsSeen(target);
    //        }
    //    }
    //    else if (selectedItem != null)
    //    {
    //        selectedItem.GetComponent<GameItem>().handleIsNotSeen(target);
    //        selectedItem = null;
    //    }
    //}
}
