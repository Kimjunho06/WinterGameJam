using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TwinkleText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    private void OnEnable()
    {
        StartCoroutine(TwinkleStart());
    }

    IEnumerator TwinkleStart()
    {
        while (true)
        {
            text.DOFade(0, 0.45f);
            yield return new WaitForSeconds(0.5f);
            text.DOFade(1, 0.45f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
