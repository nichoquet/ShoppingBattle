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
                    item.SetActive(false);
                }
            });
        }
    }

    public void onSelectionChanged(GameObject item) {
        if (heldItem != null)
        {
            Destroy(heldItem);
        }
        Vector3 newPosition = transform.position;
        Vector3 scale = item.transform.localScale;
        newPosition.y += scale.y / 2;
        scale = scale * 10;
        heldItem = Instantiate(item, newPosition, transform.rotation, transform);
        heldItem.SetActive(true);
        heldItem.transform.localScale = scale;
        Debug.Log(heldItem.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
