using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballTransform : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z); //y√‡ ∞Ì¡§Ω√≈¥
        //transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}