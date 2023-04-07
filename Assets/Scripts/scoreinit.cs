using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreinit : MonoBehaviour
{
    void Start()
    {
        PinballController.score = 0;
        PinballController.combo = 0;
    }
}
