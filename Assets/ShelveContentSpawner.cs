using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelveContentSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> ItemsToSpawn;
    void Start()
    {
        int sizeW = 8;
        int nbHeight = 4;
        Collider collider = GetComponent<Collider>();
        float positionPerFloor = collider.bounds.size.y/4;
        float shelveWidth = collider.bounds.size.z;
        float initialPositionZ = shelveWidth / 2;
        for (int z = 0; z < nbHeight; z++)
        {
            GameObject lastItem = null;
            for (int x = 0; x < sizeW; x+= 1)
            {
                float newXPosition = this.transform.position.z + initialPositionZ;
                if(lastItem != null)
                {
                    newXPosition = lastItem.transform.position.z - lastItem.GetComponent<Collider>().bounds.size.z;
                }
                if (newXPosition < shelveWidth)
                {
                    GameObject itemToPlace = getRandomObject();
                    GameObject item = Instantiate(itemToPlace, new Vector3(this.transform.position.x, this.transform.position.y + (positionPerFloor * z) + 0.3f, newXPosition), itemToPlace.transform.rotation);
                    item.transform.parent = this.transform;
                    if (lastItem == null)
                    {
                        item.transform.position = item.transform.position - new Vector3(0, 0, item.GetComponent<Collider>().bounds.size.z / 2);
                    }
                    item.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    lastItem = item;
                }
            }
        }
    }

    private GameObject getRandomObject() {
        return ItemsToSpawn[Random.Range(0, ItemsToSpawn.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
