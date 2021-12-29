using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MeleeWeapon : MonoBehaviour
{
    public float forceApplied = 50;
    Animator m_Animator;
    private Collider collider;

    void Start()
    {
        m_Animator = gameObject.transform.parent.GetComponent<Animator>();
        collider = gameObject.GetComponent<Collider>();
        collider.enabled = false;
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

    public void Fire(CallbackContext context)
    {
        if (context.performed)
        {
            m_Animator.SetTrigger("Fire");
        }
    }

    public void OnAnimationStart()
    {
        collider.enabled = true;
    }

    public void OnAnimationEnd()
    {
        collider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //this.Fire();
    }
}