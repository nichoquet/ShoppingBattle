using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> inventory;
    public int inventoryMaxSize = 4;
    private int indexSelected = -1;
    public HandScript hand;
    public UnityEvent<GameObject> onPlayerSelectedInventoryItemChanged;
    public RawImage selectedItemImage;
    void Start()
    {
        inventory = new List<GameObject>();
    }

    public void ThrowCurrentItem(CallbackContext context)
    {
        if (context.phase == UnityEngine.InputSystem.InputActionPhase.Performed && hand.heldItem != null)
        {
            GameObject newObject = Instantiate(hand.heldItem, hand.transform.position, hand.transform.rotation);
            newObject.transform.localScale = newObject.transform.localScale / 10;
            // newObject.SetActive(true);
            newObject.GetComponent<GameItem>().deactivateAsPlayerItem();
            newObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 100, 0) + transform.forward * 500);
            Destroy(inventory[indexSelected]);
            Destroy(hand.heldItem);
            inventory.RemoveAt(indexSelected);
            if (inventory.Count == 0) {
                indexSelected = -1;
            }
        }
    }

    public void OnNextSelectedItem(CallbackContext context)
    {
        if (context.phase == UnityEngine.InputSystem.InputActionPhase.Performed) { 
            if (inventory.Count > 0)
            {
                indexSelected = (indexSelected + 1) % inventory.Count;
                this.onSelectedItemChanged(inventory[indexSelected]);
            }
        }
    }

    private void onSelectedItemChanged(GameObject item) {
        selectedItemImage.texture = item.GetComponent<GameItem>().icon;
        onPlayerSelectedInventoryItemChanged.Invoke(item);
    }

    public void OnLastSelectedItem(CallbackContext context)
    {
        if (context.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
        {
            if (inventory.Count > 0)
            {
                int newIndex = indexSelected - 1;
                if (newIndex < 0)
                {
                    newIndex = inventory.Count - 1;
                }
                indexSelected = newIndex;
                this.onSelectedItemChanged(inventory[indexSelected]);
            }
        }
    }

    public bool addItem(GameObject item)
    {
        if (inventory.Count < inventoryMaxSize)
        {
            inventory.Add(item);
            item.GetComponent<GameItem>().activateAsPlayerItem();
            if (inventory.Count == 1) {
                indexSelected = 0;
                //onPlayerSelectedInventoryItemChanged.Invoke(inventory[indexSelected]);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
