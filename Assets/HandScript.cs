using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public GrabItemScript grabItem;
    public GameObject heldItem;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnGrab()
    {
        if (grabItem.seenObjects.Count > 0)
        {
            grabItem.seenObjects.ForEach((item) => {
                if (playerInventory.addItem(item))
                {
                    Destroy(item);
                }
            });
        }
    }

    public void onSelectionChanged(GameObject item) {
        if (heldItem != null)
        {
            Destroy(heldItem);
        }
        heldItem = item;
        Instantiate(heldItem, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
