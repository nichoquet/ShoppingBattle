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

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.TryGetComponent<PlayerInventory>(out PlayerInventory playerInventory)) {
        //    playerInventory.addItem(gameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void deactivateAsPlayerItem()
    {
        gameObject.AddComponent<Rigidbody>();
    }

    public void activateAsPlayerItem()
    {
        Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.GetComponent<MeleeWeapon>().enabled = true;
        gameObject.GetComponent<Renderer>().material = defaultMaterial;
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
