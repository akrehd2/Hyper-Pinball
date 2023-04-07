using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SndCtrl : MonoBehaviour
{
    public static SndCtrl Instance;

    public AudioSource[] Sources;
    public AudioClip[] Clips;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Sources[1].Play();
        }
    }
}
