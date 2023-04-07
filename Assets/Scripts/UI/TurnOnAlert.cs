using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnOnAlert : MonoBehaviour
{
    public GameObject Alert;
    public GameObject[] buybtn;
    public GameObject[] Equipbtn;
    public TextMeshProUGUI [] EquipText;

    public void Item100()
    {
        if (PinballController.coin <100)
        {
            Alert.SetActive(true);
        }
        else
        {
            //buy
            buybtn[0].SetActive(false);
            Equipbtn[0].SetActive(true);

            PinballController.coin -= 100;
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
            buybtn[1].SetActive(false);
            Equipbtn[1].SetActive(true);

            PinballController.coin -= 200;
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
            buybtn[2].SetActive(false);
            Equipbtn[2].SetActive(true);

            PinballController.coin -= 300;
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
            buybtn[3].SetActive(false);
            Equipbtn[3].SetActive(true);

            PinballController.coin -= 400;
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
            buybtn[4].SetActive(false);
            Equipbtn[4].SetActive(true);

            PinballController.coin -= 500;
        }
    }

    public void Equip100()
    {
        if (EquipText[0].color == new Color(255 / 255f, 207 / 255f, 37 / 255f, 255 / 255f))
        {
            EquipText[0].color = new Color(142 / 255f, 88 / 255f, 33 / 255f, 255 / 255f);
            EquipText[1].color = new Color(255 / 255f, 207 / 255f, 37 / 255f, 255 / 255f);
            EquipText[2].color = new Color(255 / 255f, 207 / 255f, 37 / 255f, 255 / 255f);
            EquipText[3].color = new Color(255 / 255f, 207 / 255f, 37 / 255f, 255 / 255f);
            EquipText[4].color = new Color(255 / 255f, 207 / 255f, 37 / 255f, 255 / 255f);
            PinballController.skin1 = true;
            PinballController.skin2 = false;
            PinballController.skin3 = false;
            PinballController.skin4 = false;
            PinballController.skin5 = false;
        }
    }
}
