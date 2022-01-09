using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class HandScript : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public GrabItemScript grabItem;
    public GameObject heldItem;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnGrab(CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (grabItem.seenObjects.Count > 0)
            {
                for (int x = 0; x < grabItem.seenObjects.Count; x++)
                {
                    if (playerInventory.addItem(grabItem.seenObjects[x]))
                    {
                        grabItem.seenObjects[x].SetActive(false);
                        grabItem.seenObjects.RemoveAt(x);
                        x--;
                    }
                }
                //grabItem.seenObjects.ForEach((item) =>
                //{
                //});
            }
        }
    }

    public void onSelectionChanged(GameObject item) {
        if (item != null)
        {
            PlayerInput playerInputs = playerInventory.gameObject.GetComponent<PlayerInput>();
            if (heldItem != null)
            {
                playerInputs.actions["Fire"].performed -= heldItem.GetComponent<GameItem>().OnFire;
                Destroy(heldItem);
            }
            heldItem = item.GetComponent<GameItem>().showInHands(playerInventory.gameObject, gameObject);
            playerInputs.actions["Fire"].performed += heldItem.GetComponent<GameItem>().OnFire;
        }
        // Debug.Log(heldItem.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
