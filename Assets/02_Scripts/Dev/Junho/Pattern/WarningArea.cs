using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WarningArea : MonoBehaviour
{
    private SpriteRenderer _warningImage;

    private void Awake()
    {
        _warningImage = GetComponent<SpriteRenderer>();
    }


    private void OnEnable()
    {
        _warningImage.color = new Color(_warningImage.color.r, _warningImage.color.g, _warningImage.color.b, 0);
        StartCoroutine(SplashImage());
    }
    
    private void OnDisable()
    {
        StopCoroutine(SplashImage());    
    }

    IEnumerator SplashImage()
    {
        Sequence seq = DOTween.Sequence();

        while (true)
        {
            seq.Append(_warningImage.DOFade(0, 0.4f));
            yield return new WaitForSeconds(0.2f);
            seq.Append(_warningImage.DOFade(1, 0.4f));
            yield return new WaitForSeconds(0.2f);
        }
    }
}
