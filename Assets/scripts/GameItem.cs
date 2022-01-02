using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;
    public bool canBeTaken = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //if (collision.gameObject.TryGetComponent<PlayerInventory>(out PlayerInventory playerInventory)) {
    //    //    playerInventory.addItem(gameObject);
    //    //}
    //}

    // Update is called once per frame
    void Update()
    {

    }

    public void deactivateAsPlayerItem()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<MeleeWeapon>().enabled = false;
        // gameObject.GetComponent<Renderer>().material = defaultMaterial;
        gameObject.GetComponent<Collider>().enabled = true;
        canBeTaken = true;
    }

    public void activateAsPlayerItem()
    {
        Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.GetComponent<MeleeWeapon>().enabled = true;
        gameObject.GetComponent<Renderer>().material = defaultMaterial;
        gameObject.GetComponent<Collider>().enabled = true;
        canBeTaken = false;
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
