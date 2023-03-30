using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyer : MonoBehaviour
{
    public LayerMask Pin;

    void Start()
    {

    }

    void Update()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, 50.0f, Pin);

        if (colls.Length < 1)
        {
            Destroy(gameObject);
        }
    }
}
