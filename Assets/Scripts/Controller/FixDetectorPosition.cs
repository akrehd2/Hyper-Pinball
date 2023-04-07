using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FixDetectorPosition : MonoBehaviour
{
    public GameObject Pin;

    void FixedUpdate()
    {
        transform.position = new Vector3(Pin.transform.position.x, 0, Pin.transform.position.z);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
