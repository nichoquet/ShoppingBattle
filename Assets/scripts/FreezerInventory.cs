using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class FreezerInventory : ItemInventory
{
    protected List<GameObject> selectedIndicators = new List<GameObject>();
    public GameObject itemCounter;
    protected override void onSelectedItemChanged(GameObject item) {
        base.onSelectedItemChanged(item);
        if (selectedIndicators.Count > 0)
        {
            selectedIndicators.ForEach(i => { i.GetComponent<Renderer>().material.color = Color.red; });
            selectedIndicators[indexSelected].GetComponent<Renderer>().material.color = Color.green;
        }
    }

    protected void onFire (GameObject player)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out InterractionWithSurroundingObjectsPlayer i))
        {
            SelectNextItem();
            i.objCollidedWith = (gameObject, onFire);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out InterractionWithSurroundingObjectsPlayer i) && i.objCollidedWith.Item1 == gameObject)
        {
            i.objCollidedWith.Item1 = null;
            i.objCollidedWith.Item2 = null;
        }
    }

    protected override void onStart()
    {
        Vector3 itemCounterCenter = itemCounter.transform.position;
        //float width = itemCounter.GetComponent<Collider>().bounds.size.x;
        //float chunkX = (width / inventoryMaxSize);
        //float initialX = -chunkX * inventoryMaxSize / 2 + (chunkX / 2);
        float width = 10;
        float chunkX = (width / inventoryMaxSize);
        float initialX = chunkX * inventoryMaxSize / 2 - (chunkX / 2);
        float ratio = itemCounter.transform.lossyScale.x / itemCounter.transform.lossyScale.z;
        for (int i = 0; i < inventoryMaxSize; i++)
        {
            GameObject itemCounterPlaneItem = GameObject.CreatePrimitive(PrimitiveType.Plane);
            itemCounterPlaneItem.transform.rotation = itemCounter.transform.rotation;
            itemCounterPlaneItem.transform.position = itemCounterCenter; // + new Vector3(initialX + (chunkX * i), 0, 0);
            itemCounterPlaneItem.GetComponent<Renderer>().material.color = Color.red;
            if (i == indexSelected)
            {
                itemCounterPlaneItem.GetComponent<Renderer>().material.color = Color.green;
            }
            itemCounterPlaneItem.transform.parent = itemCounter.transform;
            itemCounterPlaneItem.transform.localScale = new Vector3(0.08f, 1, 0.08f * ratio);
            itemCounterPlaneItem.transform.localPosition += new Vector3(initialX - (chunkX * i), 0.05f, 0);
            selectedIndicators.Add(itemCounterPlaneItem);
        }
        base.onStart();
    }
}
