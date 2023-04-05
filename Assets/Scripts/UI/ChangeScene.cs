using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void GoShopScene()
    {
        SceneManager.LoadScene("ShopScene");
    }
}