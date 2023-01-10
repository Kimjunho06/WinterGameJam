using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pattern1 : MonoBehaviour
{
    public GameObject _warningArea;

    public GameObject _horizontalLaser;
    public GameObject _verticalLaser;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChromeMove();
        }
    }

    private void ChromeMove() // ���� ����
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 9), new Vector2(19, 10))));
        seq.AppendInterval(0.8f);
        seq.Append(transform.DOMove(new Vector3(0, 9, 0), 0.8f)); // ������� ũ�� �������� ����
        seq.AppendCallback(() => StartCoroutine(ChromeBounce()));

        seq.AppendCallback(RepeatHorizontalLaser);
        seq.AppendInterval(24f); // ���� ���� ���� �� ���� ��� ��
        
        seq.AppendCallback(RepeatLeftLaser);
        seq.AppendCallback(RepeatRightLaser);
        seq.AppendInterval(7.4f); // ���� ���� ���� �� ���� ��� ��
        
        seq.AppendInterval(2f); // ������ �� �κ�
        seq.AppendCallback(Pattern1Last);

        seq.Append(transform.DOMove(new Vector3(0, 21, 0), 0.8f));
    }

    private void DownLaserWarning() // ������ ��������
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 10), new Vector2(53, 2))));
        seq.AppendInterval(0.5f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 3), new Vector2(53, 2))));
        seq.AppendInterval(0.5f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, -3), new Vector2(53, 2))));
        seq.AppendInterval(0.5f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, -10), new Vector2(53, 2))));
    }

    private void RepeatHorizontalLaser()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(DownLaserWarning)
        .AppendInterval(2f)
        .AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(0, 15.5f), new Vector2(53, 2))))
        .AppendInterval(1f);// ������� �� ��ƾ

        seq.AppendCallback(DownLaserWarning)
        .AppendInterval(2f)
        .AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(0, 15.5f), new Vector2(53, 2))))
        .AppendInterval(1f);

        seq.AppendCallback(DownLaserWarning)
        .AppendInterval(2f)
        .AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(0, 15.5f), new Vector2(53, 2))))
        .AppendInterval(1f);
        
        seq.AppendCallback(DownLaserWarning)
        .AppendInterval(2f)
        .AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(0, 15.5f), new Vector2(53, 2))))
        .AppendInterval(1f);
        
        seq.AppendCallback(DownLaserWarning)
        .AppendInterval(2f)
        .AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(0, 15.5f), new Vector2(53, 2))))
        .AppendInterval(1f);
        
        seq.AppendCallback(DownLaserWarning)
        .AppendInterval(2f)
        .AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(0, 15.5f), new Vector2(53, 2))))
        .AppendInterval(1f);
        
        seq.AppendCallback(DownLaserWarning)
        .AppendInterval(2f)
        .AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(0, 15.5f), new Vector2(53, 2))))
        .AppendInterval(1f);
        
        seq.AppendCallback(DownLaserWarning)
        .AppendInterval(2f)
        .AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(0, 10), new Vector2(53, 2))))
        .AppendInterval(1f);

    }

    private void RepeatRightLaser()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(RightInnerLaserWarning)
            .AppendInterval(1.2f)
            .AppendCallback(RightouterLaserWarning)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(27, 0), new Vector2(2, 30), new Vector3(0,0), 0.8f)))
            .AppendInterval(1.2f)
            //.AppendInterval(1f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(27, 0), 0.8f)));

        seq.AppendCallback(RightInnerLaserWarning)
            .AppendInterval(1.2f)
            .AppendCallback(RightouterLaserWarning)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(27, 0), new Vector2(2, 30), new Vector3(0, 0), 0.8f)))
            .AppendInterval(1.2f)
            //.AppendInterval(1f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(27, 0), 0.8f)));

        seq.AppendCallback(RightInnerLaserWarning)
            .AppendInterval(1.2f)
            .AppendCallback(RightouterLaserWarning)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(27, 0), new Vector2(2, 30), new Vector3(0, 0), 0.8f)))
            .AppendInterval(1.2f)
            //.AppendInterval(1f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(27, 0), 0.8f)));

    }

    private void RepeatLeftLaser()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(LeftInnerLaserWarning)
            .AppendInterval(1.2f)
            .AppendCallback(LeftouterLaserWarning)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(-27, 0), new Vector2(2, 30), new Vector3(0, 0), 0.8f)))
            .AppendInterval(1.2f)
            //.AppendInterval(1f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(-27, 0), 0.8f)));

        seq.AppendCallback(LeftInnerLaserWarning)
            .AppendInterval(1.2f)
            .AppendCallback(LeftouterLaserWarning)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(-27, 0), new Vector2(2, 30), new Vector3(0, 0), 0.8f)))
            .AppendInterval(1.2f)
            //.AppendInterval(1f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(-27, 0), 0.8f)));
        
        seq.AppendCallback(LeftInnerLaserWarning)
            .AppendInterval(1.2f)
            .AppendCallback(LeftouterLaserWarning)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(-27, 0), new Vector2(2, 30), new Vector3(0, 0), 0.8f)))
            .AppendInterval(1.2f)
            //.AppendInterval(1f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(-27, 0), 0.8f)));
    }

    private void RightInnerLaserWarning()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(23, 0), new Vector2(2, 30)))); //right
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(17, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(11, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(5, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 30))));
    }

    private void RightouterLaserWarning()
    {
        Sequence seq = DOTween.Sequence();

        /*seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);*/
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(5, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(11, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(17, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(23, 0), new Vector2(2, 30)))); //right

    }

    private void LeftInnerLaserWarning()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-23, 0), new Vector2(2, 30)))); //left
        seq.AppendInterval(0.2f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-17, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-11, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-5, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 30))));
    }

    private void LeftouterLaserWarning()
    {
        Sequence seq = DOTween.Sequence();

        /*seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);*/
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-5, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-11, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-17, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-23, 0), new Vector2(2, 30)))); //left
    }

    private void Pattern1Last()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(RightouterLaserWarning)
            .AppendCallback(LeftouterLaserWarning)
            .AppendInterval(1.2f)
            //.AppendInterval(1f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(27, 0), 0.2f)))
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(-27, 0), 0.2f)));

        
    }

    IEnumerator CreateWarning(Vector2 createPos, Vector2 scale)
    {
        GameObject a = PoolManager.Instance.Pop(_warningArea, createPos, Quaternion.identity);
        a.transform.localScale = scale;
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(a);
    }

    IEnumerator CreateHorizontalLaser(Vector2 createPos, Vector2 scale) // ������ ��������
    {
        GameObject a = PoolManager.Instance.Pop(_horizontalLaser, createPos, Quaternion.identity);
        a.transform.localScale = scale;
        a.transform.DOMove(new Vector3(0, -16), 0.8f);
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(a);
    }

    IEnumerator CreateVerticalLaser(Vector2 createPos, Vector2 scale, Vector3 moveVec, float duration) // ������ ���̱�
    {
        GameObject a = PoolManager.Instance.Pop(_verticalLaser, createPos, Quaternion.identity);
        a.transform.localScale = scale;
        a.transform.DOMove(moveVec, duration);
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(a);
    }

    IEnumerator ChromeBounce()
    {
        while (true)
        {
            transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.8f);
            yield return new WaitForSeconds(0.1f);
            transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
