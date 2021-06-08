using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float destructionTime = 5.0f;
        Destroy(gameObject, destructionTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
