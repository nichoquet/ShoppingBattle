using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShelves : MonoBehaviour
{
    public int rows = 2;
    public int nbPerRows = 4;
    public GameObject shelve;
    public List<GameObject> possibleItems = new List<GameObject>();
    private List<GameObject> shelves = new List<GameObject>();
    private List<Color> colors = new List<Color>() { Color.red, Color.green, Color.blue };
    // Start is called before the first frame update
    void Start()
    {
        spawnShelves();
        fillShelves();
    }

    private void spawnShelves ()
    {
        Vector3 lastPosDebutRow = new Vector3(0, shelve.transform.position.y, 0);
        for (int i = 0; i < rows; i++)
        {
            GameObject lastItem = null;
            for (int j = 0; j < nbPerRows; j++)
            {
                Vector3 newPosition = lastPosDebutRow;
                if (lastItem != null)
                {
                    newPosition = lastItem.transform.position + new Vector3(lastItem.GetComponent<Collider>().bounds.size.x, 0, 0);
                }
                GameObject item = Instantiate(shelve, newPosition, shelve.transform.rotation);
                shelves.Add(item);
                Vector3 reverseRowRotation = item.transform.rotation.eulerAngles + new Vector3(0, 180, 0);
                Vector3 reverseRowPosition = newPosition - new Vector3(0, 0, item.GetComponent<Collider>().bounds.size.z);
                GameObject item2 = Instantiate(shelve, reverseRowPosition, Quaternion.Euler(reverseRowRotation));
                shelves.Add(item2);
                lastItem = item;
                item.GetComponent<Renderer>().material.color = getRandomColor();
                item2.GetComponent<Renderer>().material.color = getRandomColor();
            }
            Vector3 lastItemCollSize = lastItem.GetComponent<Collider>().bounds.size;
            lastPosDebutRow = lastPosDebutRow + new Vector3(0, 0, lastItemCollSize.x * 2 + lastItemCollSize.z * 2);
        }
    }

    private Color getRandomColor ()
    {
        return colors[Random.Range(0, colors.Count)];
    }

    private void fillShelves()
    {
        int totalInventory = 0;
        shelves.ForEach(shelve => {
            totalInventory += shelve.GetComponent<ItemInventory>().inventoryMaxSize;
        });
        int compteurTotal = 0;
        for(int i = 0; i < shelves.Count; i++)
        {
            ItemInventory inventory = shelves[i].GetComponent<ItemInventory>();
            for(int j = 0; j < inventory.inventoryMaxSize; j++)
            {
                int itemIndex = (int)((float)compteurTotal / totalInventory * possibleItems.Count);
                inventory.addItem(possibleItems[itemIndex]);
                compteurTotal++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
