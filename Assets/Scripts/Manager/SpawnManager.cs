using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab; //Prefab을 받을 public 변수
    public GameObject Detector;

    private float xRange = 10;
    private float zRange = 10;
    private float radius = 50.0f;

    public LayerMask Item;
    public LayerMask StarL;
    public LayerMask PowerL;
    public LayerMask BarrelL;
    public LayerMask RockL;
    public LayerMask DollarL;

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
        Collider[] Power = Physics.OverlapSphere(transform.position, radius * 3f, PowerL);
        Collider[] Barrel = Physics.OverlapSphere(transform.position, radius * 2f, BarrelL);
        Collider[] Rock = Physics.OverlapSphere(transform.position, radius * 2f, RockL);
        Collider[] Daller = Physics.OverlapSphere(transform.position, radius * 2f, DollarL);

        if (Daller.Length < 2)
        {
            Instantiate(itemPrefab[5], randomSpawnPos, itemPrefab[5].transform.rotation);
        }
        else if (Rock.Length < 1)
        {
            Instantiate(itemPrefab[4], randomSpawnPos + new Vector3(0,1,0), itemPrefab[4].transform.rotation);
        }
        else if (Barrel.Length < 3)
        {
            Instantiate(itemPrefab[3], randomSpawnPos - new Vector3(0, 0.5f, 0), itemPrefab[3].transform.rotation);
        }
        else if (Power.Length < 1)
        {
            Instantiate(itemPrefab[2], randomSpawnPos, itemPrefab[2].transform.rotation);
        }
        else if (Star.Length < 5)
        {
            Instantiate(itemPrefab[1], randomSpawnPos, itemPrefab[1].transform.rotation);
        }
        else if (colls.Length < 40)
        {
            Instantiate(itemPrefab[0], randomSpawnPos, itemPrefab[0].transform.rotation);
        }

        //if (Pinball.transform.position != cameraControllerScript.lastPos) //공이 움직였으면
        //    if (obstacles.Length < 10)
        //        Instantiate(obstaclePrefab, randomSpawnPos, obstaclePrefab.transform.rotation);
    }
}