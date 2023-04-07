using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortLayer : MonoBehaviour
{
    RectTransform sort;

    void Start()
    {
        sort = GetComponent<RectTransform>();

        if (gameObject.name == "SettingImage")
        {
            sort.SetAsLastSibling();
        }
        else if (gameObject.name == "Scroll View")
        {
            sort.SetAsFirstSibling();
        }
    }
}
