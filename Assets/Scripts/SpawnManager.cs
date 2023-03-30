using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab; //Prefab�� ���� public ����
    public GameObject Detector;

    private float xRange = 9;
    private float zRange = 16;
    private float radius = 50.0f;

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
        //Vector3 randomSpawnPos = new Vector3(Random.Range(Camera.main.transform.position.x - 9, Camera.main.transform.position.x + 9), 0, Random.Range(Camera.main.transform.position.z - 16, Camera.main.transform.position.z + 16));
        Vector3 randomSpawnPos = new Vector3(Random.Range(transform.position.x - xRange, transform.position.x + xRange), 0, Random.Range(transform.position.z - zRange, transform.position.z + zRange));
        Collider[] colls = Physics.OverlapSphere(transform.position, radius, Obstacle);

        if (colls.Length < 10)
        {
            Instantiate(obstaclePrefab[0], randomSpawnPos, obstaclePrefab[0].transform.rotation);
        }

        //if (Pinball.transform.position != cameraControllerScript.lastPos) //���� ����������
        //    if (obstacles.Length < 10)
        //        Instantiate(obstaclePrefab, randomSpawnPos, obstaclePrefab.transform.rotation);
    }
}