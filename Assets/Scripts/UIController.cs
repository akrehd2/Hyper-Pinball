using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIController : MonoBehaviour
{
    TextMeshProUGUI pressToStart;

    void Start()
    {
        pressToStart = GetComponent<TextMeshProUGUI>();        
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        for (float i = 0.0f; i <= 1.0f; i += 0.001f)
        {
            for(float j = 1.0f; j > 0.1f; j -= 0.01f)
            {
                pressToStart.color = new Color(255 / 255f, 180 / 255f, 0 / 255f, j);

                //pressToStart.color = new Color(255, 180 / 255f, 0 / 255f, j / 255f);
                yield return null;
            }

            yield return new WaitForSeconds(0.001f); //0.01초마다 실행

            for(float j = 0.1f; j < 1.0f; j += 0.01f)
            {
                pressToStart.color = new Color(255 / 255f, 180 / 255f, 0 / 255f, j);
                //pressToStart.color = new Color(255, 180, 0, j);
                yield return null;
            }

            if(i==1.0f)
                i = 0.0f;
        }
    }
}
