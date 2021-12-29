using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> inventory;
    public int inventorySize = 4;
    private int indexSelected = -1;
    public UnityEvent<GameObject> onPlayerSelectedInventoryItemChanged;
    void Start()
    {
        inventory = new List<GameObject>();
    }

    public void OnNextSelectedItem()
    {
        indexSelected = (indexSelected + 1) % inventorySize;
        onPlayerSelectedInventoryItemChanged.Invoke(inventory[indexSelected]);
    }

    public void OnLastSelectedItem()
    {
        int newIndex = indexSelected - 1;
        if (newIndex < 0) {
            newIndex = inventorySize - 1;
        }
        indexSelected = newIndex;
        onPlayerSelectedInventoryItemChanged.Invoke(inventory[indexSelected]);
    }

    public bool addItem(GameObject item)
    {
        if (inventory.Count < inventorySize)
        {
            inventory.Add(item);
            if (inventory.Count == 1) {
                indexSelected = 0;
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
