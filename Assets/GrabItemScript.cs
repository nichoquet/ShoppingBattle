using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItemScript : MonoBehaviour
{
    public List<GameObject> seenObjects;
    // Start is called before the first frame update
    void Start()
    {
        seenObjects = new List<GameObject>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out GameItem gameItem))
        {
            seenObjects.Remove(other.gameObject);
            gameItem.handleIsNotSeen(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out GameItem gameItem))
        {
            if (gameItem.canBeTaken)
            {
                seenObjects.Add(other.gameObject);
                gameItem.handleIsSeen(transform.parent.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
