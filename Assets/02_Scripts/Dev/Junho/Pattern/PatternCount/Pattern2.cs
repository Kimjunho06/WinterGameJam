using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pattern2 : MonoBehaviour
{
    public float CurrentTime;

    public GameObject _warningArea;

    public GameObject _horizontalLaser;
    public GameObject _verticalLaser;


    private void Update()
    {
        CurrentTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Pattern2Process();
        }        
    }

    public void Pattern2Process()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(19, 10), new Vector3(0, 0, 0), 0.5f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 0), 0.5f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 0), 0.5f)));
        seq.AppendInterval(0.5f);
        seq.Append(transform.DOScale(new Vector3(1,1,1), 0.4f));
        seq.AppendCallback(() => _horizontalLaser.transform.DOScale(new Vector3(70, 2), 0.2f));
        seq.AppendCallback(() => _verticalLaser.transform.DOScale(new Vector3(2, 70), 0.2f)); // 가운데 크롬과 레이저 생성

        
        seq.AppendInterval(0.2f);
        seq.AppendCallback(RotateLaser);
        seq.AppendInterval(4.1f);
        seq.AppendCallback(RotateLaser);
        seq.AppendInterval(3.6f);
        seq.AppendCallback(RotateLaser);
        seq.AppendInterval(3.7f);
        seq.AppendCallback(RotateLaser);
        seq.AppendInterval(3.3f);


        seq.AppendCallback(() => _horizontalLaser.transform.DOScale(new Vector3(0, 0), 0.1f));
        seq.AppendCallback(() => _verticalLaser.transform.DOScale(new Vector3(0, 0), 0.1f));
        seq.AppendCallback(() => transform.DOScale(new Vector2(0, 0), 0.1f));
        print(CurrentTime);
    }

    private void RotateLaser()
    {
        Sequence seq = DOTween.Sequence();

        //반시계 회전
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 35), 0.3f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 35), 0.3f)));
        seq.AppendInterval(0.2f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 35), 0.1f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 35), 0.1f));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 65), 0.3f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 65), 0.3f)));
        seq.AppendInterval(0.2f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 65), 0.1f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 65), 0.1f));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 100), 0.3f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 100), 0.3f)));
        seq.AppendInterval(0.2f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 100), 0.1f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 100), 0.1f));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 130), 0.3f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 130), 0.3f)));
        seq.AppendInterval(0.2f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 130), 0.1f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 130), 0.1f));

        seq.AppendInterval(0.25f);

        // 시계회전
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 110), 0.3f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 110), 0.3f)));
        seq.AppendInterval(0.2f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 110), 0.1f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 110), 0.1f));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 80), 0.3f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 80), 0.3f)));
        seq.AppendInterval(0.2f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 80), 0.1f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 80), 0.1f));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 45), 0.3f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 45), 0.3f)));
        seq.AppendInterval(0.2f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 45), 0.1f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 45), 0.1f));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(70, 2), new Vector3(0, 0, 10), 0.3f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 70), new Vector3(0, 0, 10), 0.3f)));
        seq.AppendInterval(0.2f);
        seq.Append(_horizontalLaser.transform.DORotate(new Vector3(0, 0, 10), 0.1f));
        seq.Join(_verticalLaser.transform.DORotate(new Vector3(0, 0, 10), 0.1f));
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
