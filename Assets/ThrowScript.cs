using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowScript : MonoBehaviour
{
    public GameObject ammunition;
    public Vector3 throwForce = new Vector3(0, 500, 5000);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            GameObject obj = Instantiate(ammunition, transform.position, transform.rotation);
            obj.GetComponent<Rigidbody>().AddForce(Camera.main.transform.TransformDirection(throwForce));
        }
    }
}
