using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public LayerMask Pin;
    public LayerMask Ground;
    public GameObject Floor;

    void Start()
    {
        
    }

    void Update()
    {
        Collider[] ball = Physics.OverlapSphere(transform.position, 100.0f, Pin);
        Collider[] colls = Physics.OverlapSphere(transform.position, 5.0f, Ground);

        if (ball.Length < 1)
        {
            Destroy(gameObject);
        }

        if (colls.Length < 1)
        {
            Instantiate(Floor, transform.position, Quaternion.identity);
        }
    }
}
