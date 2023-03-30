using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Pinball;
    public Vector3 lastPos;
    //private Vector3 zoomIn = new Vector3(Camera.main.transform.position.x, 10, Camera.main.transform.position.z);
    //private Vector3 zoomOut = new Vector3(Camera.main.transform.position.x, 30, Camera.main.transform.position.z);

    void Start()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 10, Camera.main.transform.position.z);
    }

    void FixedUpdate()
    {
        transform.position = Pinball.transform.position;
        CheckMovement();
    }

    void CheckMovement()
    {
        if (Pinball.transform.position != lastPos) //���� ����������
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 30, Camera.main.transform.position.z);
        }

        else //���� �ȿ���������
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 10, Camera.main.transform.position.z);
        }

        lastPos = Pinball.transform.position;
    }
}