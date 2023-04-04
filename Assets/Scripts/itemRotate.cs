using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class itemRotate : MonoBehaviour
{
    public ParticleSystem PS;

    void Update()
    {
        transform.Rotate(0,1,0);
    }
}
