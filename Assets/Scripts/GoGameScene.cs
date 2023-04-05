using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoGameScene : MonoBehaviour
{
    public GameObject touchToStartPanel;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(touchToStartPanel);

            if (EventSystem.current.IsPointerOverGameObject() == true) //UI À§¶ó¸é
            {

            }
        }
    }
}