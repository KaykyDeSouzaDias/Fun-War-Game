using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFader : MonoBehaviour
{
    bool isFaded = false;
    int duration = 3;

    void Start()
    {
        var canvGroup = GetComponent<CanvasGroup>();

        StartCoroutine(Fade(canvGroup, canvGroup.alpha, isFaded ? 1 : 0));

        isFaded = !isFaded;
    }

    //Fade functionality
    IEnumerator Fade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        yield return new WaitForSeconds(5);
        while(counter < duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);

            yield return null;
        }
    }
}
