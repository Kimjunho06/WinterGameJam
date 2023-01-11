using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TwinkleImage : MonoBehaviour
{
    Image image;
    [SerializeField] float time;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    
    void Start()
    {
        StartCoroutine(StartTwinkle());
    }

    IEnumerator StartTwinkle()
    {
        while(true)
        {
            image.DOFade(0,time);
            yield return new WaitForSeconds(time);
            image.DOFade(1,time);
            yield return new WaitForSeconds(time);
        }
    }
}
