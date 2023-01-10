using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        Sequence seq = DOTween.Sequence();

        _warningImage.color = new Color(_warningImage.color.r, _warningImage.color.g, _warningImage.color.b, 0);
        seq.Append(_warningImage.DOFade(1, 0.2f));
        seq.Append(_warningImage.DOFade(0, 0.2f));

    }

    private void OnDisable()
    {
    }

}
