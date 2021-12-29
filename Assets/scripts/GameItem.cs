using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void handleIsSeen(GameObject player)
    {
        gameObject.GetComponent<Renderer>().material = selectedMaterial;
    }

    public void handleIsNotSeen(GameObject player)
    {
        gameObject.GetComponent<Renderer>().material = defaultMaterial;
    }
}
