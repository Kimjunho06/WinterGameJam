using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pattern2 : MonoBehaviour
{
    public GameObject _warningArea;

    public GameObject _horizontalLaser;
    public GameObject _verticalLaser;

    public bool _passPattern3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Pattern2Process();
        }        
    }

    private void Pattern2Process()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(19, 10), new Vector3(0, 0, 0), 1)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 0), 1)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 0), 1)));
        seq.AppendInterval(0.8f);
        seq.Append(transform.DOScale(new Vector3(1,1,1), 0.4f));
        seq.AppendCallback(() => _horizontalLaser.transform.DOScale(new Vector3(70, 2), 0.2f));
        seq.AppendCallback(() => _verticalLaser.transform.DOScale(new Vector3(2, 70), 0.2f)); // 가운데 크롬과 레이저 생성

        for (int i = 0; i < 4; i++)
        {
            seq.AppendCallback(RotateLaser);
            seq.AppendInterval(8.6f); 
        }

        seq.AppendCallback(() => _horizontalLaser.transform.DOScale(new Vector3(0, 0), 0.2f));
        seq.AppendCallback(() => _verticalLaser.transform.DOScale(new Vector3(0, 0), 0.2f));

        seq.AppendCallback(() => _passPattern3 = true);

    }

    private void RotateLaser()
    {
        Sequence seq = DOTween.Sequence();

        //반시계 회전
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 35), 0.65f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 35), 0.65f)));
        seq.AppendInterval(0.3f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 35), 0.3f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 35), 0.3f));
        seq.AppendInterval(0.2f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 65), 0.65f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 65), 0.65f)));
        seq.AppendInterval(0.3f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 65), 0.3f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 65), 0.3f));
        seq.AppendInterval(0.2f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 100), 0.65f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 100), 0.65f)));
        seq.AppendInterval(0.3f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 100), 0.3f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 100), 0.3f));
        seq.AppendInterval(0.2f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 130), 0.65f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 130), 0.65f)));
        seq.AppendInterval(0.3f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 130), 0.3f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 130), 0.3f));

        seq.AppendInterval(0.3f);

        // 시계회전
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 110), 0.65f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 110), 0.65f)));
        seq.AppendInterval(0.3f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 110), 0.3f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 110), 0.3f));
        seq.AppendInterval(0.2f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 80), 0.65f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 80), 0.65f)));
        seq.AppendInterval(0.3f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 80), 0.3f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 80), 0.3f));
        seq.AppendInterval(0.2f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 45), 0.65f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 45), 0.65f)));
        seq.AppendInterval(0.3f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 45), 0.3f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 45), 0.3f));
        seq.AppendInterval(0.2f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 10), 0.65f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 10), 0.65f)));
        seq.AppendInterval(0.3f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 10), 0.3f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 10), 0.3f));
    }

    IEnumerator CreateWarning(Vector2 createPos, Vector2 scale, Vector3 rotation, float delay)
    {
        GameObject a = PoolManager.Instance.Pop(_warningArea, createPos, Quaternion.identity);
        a.transform.localScale = scale;
        a.transform.rotation = Quaternion.Euler(rotation);
        yield return new WaitForSeconds(delay);
        PoolManager.Instance.Push(a);
    }
}
