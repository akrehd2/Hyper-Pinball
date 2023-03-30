using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab; //Prefab�� ���� public ����
    public GameObject Detector;

    public LayerMask Obstacle;

    void Start()
    {
        //�������� �ν��Ͻ��� 10�� ���ϸ� �����ǰ�
        //SpawnRandomThings();
    }

    void Update()
    {
        SpawnRandomThings();
        transform.position = Detector.transform.position;
    }

    void SpawnRandomThings()
    {
        Vector3 randomSpawnPos = new Vector3(Random.Range(Camera.main.transform.position.x - 9, Camera.main.transform.position.x + 9), 0, Random.Range(Camera.main.transform.position.z - 16, Camera.main.transform.position.z + 16));
        Collider[] colls = Physics.OverlapSphere(transform.position, 50.0f, Obstacle);

        if (colls.Length < 10)
        {
            Instantiate(obstaclePrefab, randomSpawnPos, obstaclePrefab.transform.rotation);
        }

        //if (Pinball.transform.position != cameraControllerScript.lastPos) //���� ����������
        //    if (obstacles.Length < 10)
        //        Instantiate(obstaclePrefab, randomSpawnPos, obstaclePrefab.transform.rotation);
    }
}