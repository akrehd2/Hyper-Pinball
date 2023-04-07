using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIxArea : MonoBehaviour
{
    public GameObject Pin;

    void Update()
    {
        transform.position = new Vector3(Pin.transform.position.x - 2.05f, 0, Pin.transform.position.z + 4.66f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
