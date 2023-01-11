using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class IntroImage : MonoBehaviour
{
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        image.DOFade(0,0.6f);
        yield return new WaitForSeconds(0.6f);
        gameObject.SetActive(false);
    }
}
