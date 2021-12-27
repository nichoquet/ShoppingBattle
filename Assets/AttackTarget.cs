using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    public float forceApplied = 50;
    public Vector3 initialRotation;
    private PlayerMovement playerMovement;

    void Start()
    {
        initialRotation = transform.eulerAngles;
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        Debug.Log("Reussi");
        if (gameObject.TryGetComponent<PlayerMovement>(out playerMovement)) {
            playerMovement.input.Player.Jump.performed += ctx => getUp();
        }
    }

    private void getUp()
    {
        transform.eulerAngles = new Vector3(initialRotation.x, initialRotation.y, initialRotation.z);
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject != gameObject && col.gameObject.tag == "Player")
        {
            Vector3 force = transform.position + col.transform.position;
            force.Normalize();
            gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            gameObject.GetComponent<Rigidbody>().AddForce(col.transform.forward * forceApplied);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
