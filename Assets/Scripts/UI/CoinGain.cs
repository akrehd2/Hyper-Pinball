using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinGain : MonoBehaviour
{
    public TextMeshProUGUI coingain;

    void Update()
    {
        coingain.text = PinballController.coinGain.ToString();
    }
}
