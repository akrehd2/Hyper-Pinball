using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnOnAlert : MonoBehaviour
{
    public GameObject Alert;
    public void Item100()
    {
        if (PinballController.coin <100)
        {
            Alert.SetActive(true);
        }
        else
        {
            //buy
        }
    }

    public void Item200()
    {
        if (PinballController.coin < 200)
        {
            Alert.SetActive(true);
        }
        else
        {
            //buy
        }
    }

    public void Item300()
    {
        if (PinballController.coin < 300)
        {
            Alert.SetActive(true);
        }
        else
        {
            //buy
        }
    }

    public void Item400()
    {
        if (PinballController.coin < 400)
        {
            Alert.SetActive(true);
        }
        else
        {
            //buy
        }
    }

    public void Item500()
    {
        if (PinballController.coin < 500)
        {
            Alert.SetActive(true);
        }
        else
        {
            //buy
        }
    }
}
