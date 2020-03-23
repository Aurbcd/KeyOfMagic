using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingImage : MonoBehaviour
{
    public CanvasGroup imgCGroup;

    // Start is called before the first frame update
    void Start()
    {
        imgCGroup.alpha = 1f;
        StartBlinking();
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch (imgCGroup.alpha.ToString())
            {
                case "0":
                    imgCGroup.alpha = 1f;
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    imgCGroup.alpha =  0f;
                    yield return new WaitForSeconds(0.5f);
                    break;

            }
        }
    }
    
    void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    public void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
