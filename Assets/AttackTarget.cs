using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    public float forceApplied = 50;
    public Quaternion initialRotation;
    private PlayerMovement playerMovement;
    public bool isDown = false;

    void Start()
    {
        initialRotation = transform.rotation;
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    }

    public void getUp()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        transform.eulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, 0);
        transform.position = new Vector3(x, transform.position.y, z);
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        isDown = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "Terrain")
        {
            if (col.gameObject != gameObject && col.collider.tag == "MeleeWeapon")
            {
                Debug.Log(col.gameObject.name);
                Vector3 force = transform.position + col.transform.position;
                force.Normalize();
                gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                gameObject.GetComponent<Rigidbody>().AddForce(col.transform.forward * forceApplied);
                isDown = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
