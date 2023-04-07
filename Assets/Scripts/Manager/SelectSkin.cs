using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectSkin : MonoBehaviour
{
    public Skin skin;
    MeshRenderer MeshRenderer;
    public SelectSkin[] skins;

    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnMouseUpAsButton()
    {
        DataManager.Instance.currentSkin = skin;
        //OnSelect();
        //for(int i= 0; i < skins.Length; i++)
        //{
        //    if (skins[i] != this) skins[i].OnDeSelect();
        //}
    }

    //void OnDeSelect()
    //{

    //}

    //void OnSelect()
    //{

    //}
}