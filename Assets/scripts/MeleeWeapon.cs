using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MeleeWeapon : GameItemScript
{
    public float forceApplied = 50;
    Animator m_Animator;
    private Collider collider;

    void Start()
    {
        // m_Animator = gameObject.transform.parent.GetComponent<Animator>();
        collider = gameObject.GetComponent<Collider>();
        collider.enabled = false;
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    Debug.Log(collider.enabled);
    //    if (col.gameObject.TryGetComponent(out AttackTarget attackTarget) && collider.enabled)
    //    {
    //        //Vector3 force = transform.position - col.transform.position;
    //        //force.Normalize();
    //        //Debug.Log(col.contacts[0].point * forceApplied);
    //        // attackTarget.getHit(col.transform.forward);
    //        //col.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    //        //col.gameObject.GetComponent<Rigidbody>().AddForce(col.transform.forward * forceApplied);
    //    }
    //}

    public override void OnFire(CallbackContext context)
    {
        if (context.performed)
        {
            m_Animator.SetTrigger("Fire");
        }
    }

    public  void OnAnimationStart()
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
    public override void deactivateAsPlayerItem(GameObject player, GameObject hand)
    {
        base.deactivateAsPlayerItem(player, hand);
        gameObject.GetComponent<MeleeWeapon>().enabled = false;
    }

    public override void activateAsPlayerItem(GameObject player, GameObject hand)
    {
        base.activateAsPlayerItem(player, hand);
        gameObject.GetComponent<MeleeWeapon>().enabled = true;
    }
    public override void ShowInHands(GameObject player, GameObject hand)
    {
        base.ShowInHands(player, hand);
        m_Animator = hand.GetComponent<Animator>();
    }

    public override Vector3 GetTruePosition(Vector3 pos, Vector3 scale, Vector3 rotation)
    {
        pos.y += scale.y / 20;
        return base.GetTruePosition(pos, scale, rotation);
    }

    public override Vector3 GetTrueScale(Vector3 pos, Vector3 scale, Vector3 rotation)
    {
        return base.GetTrueScale(pos, scale, rotation);
    }
}