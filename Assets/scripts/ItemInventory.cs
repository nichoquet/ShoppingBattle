using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class ItemInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> inventory = new List<GameObject>();
    public int inventoryMaxSize = 4;
    protected int indexSelected = -1;
    public GameObject selectedItemImageObject;
    void Start()
    {
        onStart();
    }

    protected virtual void onStart() { 
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

    protected virtual void onSelectedItemChanged(GameObject item) {
        if (item != null)
        {
            selectedItemImageObject.GetComponent<Renderer>().material.mainTexture = item.GetComponent<GameItem>().icon;
        }
        else
        {
            selectedItemImageObject.GetComponent<Renderer>().material.mainTexture = null;
        }
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
            if (inventory.Count == 1) {
                indexSelected = 0;
                onSelectedItemChanged(inventory[0]);
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
