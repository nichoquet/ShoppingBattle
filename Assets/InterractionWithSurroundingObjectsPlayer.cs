using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InterractionWithSurroundingObjectsPlayer : MonoBehaviour
{
    public (GameObject, System.Action<GameObject>) objCollidedWith;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnFire(CallbackContext context)
    {
        if (context.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
        {
            if(objCollidedWith.Item1 != null)
            {
                objCollidedWith.Item2(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
