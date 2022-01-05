using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class GameItem : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;
    public bool canBeTaken = true;
    public Texture icon;
    public GameItemScript gameItemScript;
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
        if (gameItemScript != null)
        {
            gameItemScript.deactivateAsPlayerItem();
        }
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Collider>().enabled = true;
        canBeTaken = true;
    }

    public void activateAsPlayerItem()
    {
        if (gameItemScript != null)
        {
            gameItemScript.activateAsPlayerItem();
        }
        Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.GetComponent<Renderer>().material = defaultMaterial;
        gameObject.GetComponent<Collider>().enabled = true;
        canBeTaken = false;
    }

    public GameObject showInHands()
    {
        Vector3 newPosition = transform.position;
        Vector3 scale = transform.localScale;
        scale = scale * 10;
        if (gameItemScript != null)
        {
            newPosition = gameItemScript.GetTruePosition(newPosition, scale);
            scale = gameItemScript.GetTrueScale(newPosition, scale);
        }
        GameObject newItem = Instantiate(gameObject, newPosition, transform.rotation, transform);
        newItem.SetActive(true);
        newItem.transform.localScale = scale;
        return newItem;
    }

    public void handleIsSeen(GameObject player)
    {
        gameObject.GetComponent<Renderer>().material = selectedMaterial;
    }

    public void handleIsNotSeen(GameObject player)
    {
        gameObject.GetComponent<Renderer>().material = defaultMaterial;
    }

    public void OnFire(CallbackContext context)
    {
        if (gameItemScript != null)
        {
            gameItemScript.OnFire(context);
        }
    }
}
