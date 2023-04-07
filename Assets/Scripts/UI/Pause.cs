using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject[] balls;
    public GameObject Pin;

    public Vector3 lastVel;
    bool move = false;

    void Update()
    {
        if (lastVel != Vector3.zero) //공이 움직였으면
        {
            move = true;
        }

        else //공이 안움직였으면
        {
            move = false;
        }

        lastVel = Pin.GetComponent<Rigidbody>().velocity;
    }

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

    public void ChanceUp()
    {
        if (move == false)
        {
            PinballController.chance += 1;
            Pin.GetComponent<PinballController>().targetPoint = Pin.GetComponent<PinballController>().startPoint;
        }
    }

    public void CoinUp()
    {
        PinballController.coin += 1000;
    }
}
