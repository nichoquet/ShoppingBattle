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
        PlayerInput playerInputs = playerInventory.gameObject.GetComponent<PlayerInput>();
        if (heldItem != null)
        {
            playerInputs.actions["Fire"].performed -= heldItem.GetComponent<MeleeWeapon>().Fire;
            Destroy(heldItem);
        }
        Vector3 newPosition = transform.position;
        Vector3 scale = item.transform.localScale;
        newPosition.y += scale.y / 2;
        scale = scale * 10;
        heldItem = Instantiate(item, newPosition, transform.rotation, transform);
        heldItem.SetActive(true);
        heldItem.transform.localScale = scale;
        playerInputs.actions["Fire"].performed += heldItem.GetComponent<MeleeWeapon>().Fire;
        // Debug.Log(heldItem.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
