using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class detectorRot : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 200 * Time.deltaTime);
    }
}
