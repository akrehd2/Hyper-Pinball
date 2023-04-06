using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void PauseStart()
    {
        Time.timeScale = 0.0f;
    }

    public void PauseCancle()
    {
        Time.timeScale = 1.0f;
    }
}
