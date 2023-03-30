using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab; //Prefab을 받을 public 변수
    public GameObject Detector;

    public LayerMask Obstacle;

    void Start()
    {
        //범위내에 인스턴스가 10개 이하면 생성되게
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

        //if (Pinball.transform.position != cameraControllerScript.lastPos) //공이 움직였으면
        //    if (obstacles.Length < 10)
        //        Instantiate(obstaclePrefab, randomSpawnPos, obstaclePrefab.transform.rotation);
    }
}