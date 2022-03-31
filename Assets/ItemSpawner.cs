using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> ItemsToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 100; x++)
        {
            //for (int y = 0; x < 10; x++)
            //{

                for (int z = 0; z < 100; z++)
                {
                    Instantiate(ItemsToSpawn[0], new Vector3(x, 0, z), ItemsToSpawn[0].transform.rotation);
                }
            // }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
