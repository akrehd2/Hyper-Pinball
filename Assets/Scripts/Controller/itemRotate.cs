using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class itemRotate : MonoBehaviour
{
    public ParticleSystem PS;

    public LayerMask Pin;

    public bool rot = true;

    void Start()
    {
        if(rot == false && gameObject.name != "Dollar")
        {
            transform.Rotate(0, Random.Range(0f,180f), 0);
        }
    }
    void Update()
    {
        Collider[] ball = Physics.OverlapSphere(transform.position, 200.0f, Pin);

        if (rot == true)
        {
            transform.Rotate(0, 1, 0);
        }

        if(ball.Length < 1)
        {
            Destroy(gameObject);
        }
    }
}
