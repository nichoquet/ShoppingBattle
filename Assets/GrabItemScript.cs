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

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out GameItem gameItem))
        {
            seenObjects.Remove(collision.gameObject);
            gameItem.handleIsNotSeen(transform.parent.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out GameItem gameItem))
        {
            seenObjects.Add(collision.gameObject);
            gameItem.handleIsSeen(transform.parent.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
