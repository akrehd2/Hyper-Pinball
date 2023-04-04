using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab; //Prefab을 받을 public 변수
    public GameObject Detector;

    private float xRange = 15;
    private float zRange = 15;
    private float radius = 50.0f;

    public LayerMask Item;
    public LayerMask StarL;

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
        //Vector3 randomSpawnPos = new Vector3(Random.Range(Camera.main.transform.position.x - 9, Camera.main.transform.position.x + 9), 0, Random.Range(Camera.main.transform.position.z - 16, Camera.main.transform.position.z + 16));
        Vector3 randomSpawnPos = new Vector3(Random.Range(transform.position.x - xRange, transform.position.x + xRange), 0, Random.Range(transform.position.z - zRange, transform.position.z + zRange));
        Collider[] colls = Physics.OverlapSphere(transform.position, radius, Item);
        Collider[] Star = Physics.OverlapSphere(transform.position, radius, StarL);


        if (Star.Length < 5)
        {
            Instantiate(itemPrefab[1], randomSpawnPos, itemPrefab[1].transform.rotation);
        }
        else if (colls.Length < 30)
        {
            Instantiate(itemPrefab[0], randomSpawnPos, itemPrefab[0].transform.rotation);
        }

        //if (Pinball.transform.position != cameraControllerScript.lastPos) //공이 움직였으면
        //    if (obstacles.Length < 10)
        //        Instantiate(obstaclePrefab, randomSpawnPos, obstaclePrefab.transform.rotation);
    }
}