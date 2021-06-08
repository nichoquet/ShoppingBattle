using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowScript : MonoBehaviour
{
    public GameObject ammunition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Vector3 pos = transform.position;
            Quaternion rotation = transform.rotation;
            GameObject obj = Instantiate(ammunition, transform.position, transform.rotation);
            obj.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50, 500));
        }
    }
}
