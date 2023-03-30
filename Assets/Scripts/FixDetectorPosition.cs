using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixDetectorPosition : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
