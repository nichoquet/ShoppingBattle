using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelveContentSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> ItemsToSpawn;
    void Start()
    {
        int sizeW = 2;
        int nbHeight = 2;
        for (int x = 0; x < sizeW; x+= 1)
        {
            //for (int y = 0; x < 10; x++)
            //{

            for (int z = 1; z <= nbHeight; z+=2)
            {
                GameObject item = Instantiate(ItemsToSpawn[0], this.transform.position + new Vector3(0, (0.3f*z), (0.2f * x) + 0.5f), ItemsToSpawn[0].transform.rotation);
                item.transform.parent = this.transform;
            }
            // }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
