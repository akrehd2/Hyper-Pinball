using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    public GameObject[] skinPrefabs;
    public GameObject player;

    void Start()
    {
        player = Instantiate(skinPrefabs[(int)DataManager.Instance.currentSkin]);
        player.transform.position = transform.position;
    }

    void Update()
    {
        
    }
}
