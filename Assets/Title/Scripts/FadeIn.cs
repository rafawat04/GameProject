using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    float fadeSpeed = 0.01f;
    float alfa;

    public bool isFadeOut = false;
    public float keep;
    Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        alfa = fadeImage.color.a;
        
    }

    void Update()
    {
        if(isFadeOut)
        {
            Invoke("StartFadeOut",keep);
            //StartFadeOut();
        }
    }



    void StartFadeOut()
    {
        alfa += fadeSpeed;
        SetAlpha();
        if(alfa == 255)
        {
            isFadeOut = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(255,255,255,alfa);
    }
}
