using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public enum TextNum
{
    H = 1,
    Y = 2,
    P = 3,
    E = 4,
    R = 5
}
public class IntroTextMove : MonoBehaviour
{
    [SerializeField] TextNum textNum = TextNum.H;
    TextMeshProUGUI text;
    [SerializeField] AudioSource audioSource;

    private string all = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVEXYZ";

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    
    void Start()
    {
        StartCoroutine(ShowTxt());
    }

    IEnumerator ShowTxt()
    {
        int i = 0;
        while(i < (int)textNum * 50)
        {
            text.text = all[Random.Range(0,all.Length-1)].ToString();
            i++;
            yield return new WaitForSeconds(0.01f);
        }
        text.text = textNum.ToString();
        audioSource.Play();
        if(textNum == TextNum.H || textNum == TextNum.P || textNum == TextNum.R)
            yield return StartCoroutine(TextSize());
        else
            yield return StartCoroutine(TextSize2());

    }

    IEnumerator TextSize()
    {
        while(true)
        {
            for(int i = 0; i < 50; i++)
            {
                text.fontSize += 1;
                i++;
                yield return new WaitForSeconds(0.015f);
            }
            for(int i = 0; i < 50; i++)
            {
                text.fontSize -= 1;
                i++;
                yield return new WaitForSeconds(0.015f);
            }
        }
    }

    IEnumerator TextSize2()
    {
        while(true)
        {
            for(int i = 0; i < 50; i++)
            {
                text.fontSize -= 1;
                i++;
                yield return new WaitForSeconds(0.015f);
            }
            for(int i = 0; i < 50; i++)
            {
                text.fontSize += 1;
                i++;
                yield return new WaitForSeconds(0.015f);
            }
        }
    }
}
