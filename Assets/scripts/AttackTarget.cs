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

    public void getHit(Vector3 force)
    {
        gameObject.GetComponent<Rigidbody>().freezeRotation = false;
        gameObject.GetComponent<Rigidbody>().AddForce(force * forceApplied);
        isDown = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "Terrain")
        {
            if (col.gameObject != gameObject && col.collider.tag == "MeleeWeapon")
            {
                // getHit(col.transform.forward);
                // Debug.Log(col.gameObject.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
