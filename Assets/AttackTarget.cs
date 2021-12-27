using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    public float forceApplied = 50;

    void Start()
    {

    }

    //void OnCollisionEnter(Collision col)
    //{
    //    Debug.Log("MeleeWeapon");
    //    if (col.gameObject.tag == "MeleeWeapon")
    //    {
            
    //        gameObject.GetComponent<Rigidbody>().AddForce(col.relativeVelocity * forceApplied);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
