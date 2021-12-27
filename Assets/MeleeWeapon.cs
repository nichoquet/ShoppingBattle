using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public float forceApplied = 50;
    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.transform.parent.GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("MeleeWeapon");
        //if (col.gameObject.TryGetComponent(out AttackTarget attackTarget))
        //{
        //    Vector3 force = transform.position - col.transform.position;
        //    force.Normalize();
        //    Debug.Log(col.contacts[0].point * forceApplied);
        //    col.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        //    col.gameObject.GetComponent<Rigidbody>().AddForce(col.transform.forward * forceApplied);
        //}
    }

    public void Fire()
    {
        m_Animator.SetTrigger("Fire");
    }

    // Update is called once per frame
    void Update()
    {
        //this.Fire();
    }
}