using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> inventory;
    public int inventorySize = 4;
    void Start()
    {
        inventory = new List<GameObject>(inventorySize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
