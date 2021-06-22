using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shelve;
    public int shelveGroupRowX = 2;
    public int shelveGroupRowZ = 2;
    public int shelveGroupInnerRowX = 2;
    public int shelveGroupInnerRowZ = 6;
    public int shelveGroupSpaceBetwenRows = 20;
    public int shelveSpaceBetwenRows = 8;
    void Start()
    {
        GameObject shelveForSize = Instantiate(shelve, new Vector3(), Quaternion.Euler(270, 0, 0));
        Vector3 size = shelveForSize.GetComponent<Collider>().bounds.size;
        Vector3 initialPosition = transform.position - new Vector3(shelveGroupRowX * shelveGroupInnerRowX / 2 * size.x + shelveGroupRowX * shelveGroupSpaceBetwenRows/2, 0, shelveGroupRowZ * shelveGroupInnerRowZ * size.z + shelveGroupRowZ * shelveGroupSpaceBetwenRows / 2) + new Vector3(0, transform.position.y,0);
        Destroy(shelveForSize);
        for (int x = 0; x < shelveGroupRowX; x++) {
            for (int z = 0; z < shelveGroupRowZ; z++)
            {
                for (int innerX = 0; innerX < shelveGroupInnerRowX; innerX++)
                {
                    for (int innerZ = 0; innerZ < shelveGroupInnerRowZ; innerZ++)
                    {
                        float positionX = (x * shelveGroupInnerRowX + innerX) * size.x * shelveSpaceBetwenRows + (x * shelveGroupInnerRowX * shelveGroupSpaceBetwenRows);
                        float positionZ = (z * shelveGroupInnerRowZ + innerZ) * size.z + (z * shelveGroupInnerRowZ * shelveGroupSpaceBetwenRows);
                        Instantiate(shelve, (initialPosition + new Vector3(positionX, 0, positionZ)), Quaternion.Euler(270,0,0));
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
