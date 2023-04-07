using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject[] balls;

    public void PauseStart()
    {
        Time.timeScale = 0.0f;

        if(SceneManager.GetActiveScene().name == "ShopScene")
        {
            foreach(GameObject obj in balls)
            {
                obj.SetActive(false);
            }
        }
    }

    public void PauseCancle()
    {
        Time.timeScale = 1.0f;

        if (SceneManager.GetActiveScene().name == "ShopScene")
        {
            foreach (GameObject obj in balls)
            {
                obj.SetActive(true);
            }
        }
    }
}
