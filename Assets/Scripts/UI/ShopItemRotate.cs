using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemRotate : MonoBehaviour
{
    private float speed = 50;

    void Update()
    {
        transform.Rotate(0, 0, -speed * Time.deltaTime);
    }
}
