using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IntroTalkScale : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(StartTweeing());   
    }

    IEnumerator StartTweeing()
    {
        while(true)
        {
            transform.DOScale(new Vector2(1.1f,1.1f),1f);
            yield return new WaitForSeconds(1f);
            transform.DOScale(new Vector2(1f,1f),1f);
            yield return new WaitForSeconds(1f);
        }
    }
}
