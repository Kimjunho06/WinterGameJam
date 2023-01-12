using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pattern6 : MonoBehaviour
{
    public GameObject _warningArea;

    public GameObject _XboxImage1;
    public GameObject _XboxImage2;
    public GameObject _XboxImage3;
    public GameObject _XboxImage4;


    private void Awake()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Pattern6Process();
        }
    }

    public void Pattern6Process()
    {
        Sequence seq = DOTween.Sequence();
    
            
            seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 12.15f), new Vector2(21.5f, 5.5f), 0.2f)));
            seq.AppendInterval(0.4f);
            seq.AppendCallback(() => XBoxMove(_XboxImage3, new Vector2(0, 10.5f), 0.3f)); // ╩С
            seq.AppendInterval(0.3f);
            seq.AppendCallback(() => XBoxMove(_XboxImage3, new Vector2(0, 14), 0.1f));
            seq.AppendInterval(0.9f);
    
            seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(18.8f, 6), new Vector2(15.5f, 11.5f), 0.2f)));
            seq.AppendInterval(0.4f);
            seq.AppendCallback(() => XBoxMove(_XboxImage4, new Vector2(17, 6), 0.3f)); // ©Л
            seq.AppendInterval(0.3f);
            seq.AppendCallback(() => XBoxMove(_XboxImage4, new Vector2(20.5f, 6), 0.1f));
            seq.AppendInterval(1.1f);
    
            seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-18.8f, 4), new Vector2(15.5f, 16.5f), 0.2f)));
            seq.AppendInterval(0.4f);
            seq.AppendCallback(() => XBoxMove(_XboxImage1, new Vector2(-17, 4), 0.3f)); // аб 1
            seq.AppendInterval(0.3f);
            seq.AppendCallback(() => XBoxMove(_XboxImage1, new Vector2(-20.5f, 4), 0.1f));
            seq.AppendInterval(1.1f);
    
            seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-18.8f, -10), new Vector2(15.5f, 8f), 0.2f)));
            seq.AppendInterval(0.4f);
            seq.AppendCallback(() => XBoxMove(_XboxImage2, new Vector2(-17, -10), 0.3f)); // аб 2
            seq.AppendInterval(0.3f);
            seq.AppendCallback(() => XBoxMove(_XboxImage2, new Vector2(-20.5f, -10), 0.1f));
               
            seq.AppendInterval(0.8f);
    
            seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(21f, 30f), 0.2f)));
            seq.AppendInterval(1f);
            seq.AppendCallback(() => XBoxMove(_XboxImage3, new Vector2(0, -16), 0.3f));
            seq.AppendInterval(1f);
    
            seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, -10), new Vector2(53, 8f), 0.2f)));
            seq.AppendInterval(1f);
            seq.AppendCallback(() => XBoxMove(_XboxImage2, new Vector2(33, -10), 0.3f));
            seq.AppendInterval(1f);
    
            seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-20.5f, 0), new Vector2(12f, 30f), 0.2f)));
            seq.AppendInterval(1f);
            seq.AppendCallback(() => XBoxMove(_XboxImage1, new Vector2(-20.5f, -24), 0.3f));
            seq.AppendInterval(1f);
    
            seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 6), new Vector2(53f, 11f), 0.2f)));
            seq.AppendInterval(1f);
            seq.AppendCallback(() => XBoxMove(_XboxImage4, new Vector2(-33f, 6), 0.3f));
            
    }

    private void XBoxMove(GameObject moveObj, Vector2 movePos, float duration)
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(moveObj.transform.DOMove(movePos, duration));
    }

    IEnumerator CreateWarning(Vector2 createPos, Vector2 scale, float delay)
    {
        GameObject a = PoolManager.Instance.Pop(_warningArea, createPos, Quaternion.identity);
        a.transform.localScale = scale;

        yield return new WaitForSeconds(delay);
        PoolManager.Instance.Push(a);
    }
}
