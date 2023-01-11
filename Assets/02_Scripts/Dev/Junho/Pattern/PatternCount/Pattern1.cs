using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pattern1 : MonoBehaviour
{
    public GameObject _warningArea;

    public GameObject _horizontalLaser;
    public GameObject _verticalLaser;

    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pattern1Process();
        }
    }

    public void Pattern1Process() // 메인 과정
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 9), new Vector2(19, 10),0.3f)));
        seq.AppendInterval(0.6f);
        seq.Append(transform.DOMove(new Vector3(0, 9, 0), 0.8f)); // 여기까지 크롬 내려오는 과정
        seq.AppendCallback(() => StartCoroutine(ChromeBounce()));
        
        seq.AppendInterval(0.05f);

        seq.AppendCallback(RepeatHorizontalLaser);
        seq.AppendInterval(3.3f); // 가로 패턴 끝날 떄 까지 대기 초
        
        seq.AppendCallback(() => 
        {
            RepeatLeftLaser();
            RepeatRightLaser();
        });

        seq.AppendInterval(2.5f); // 세로 패턴 끝날 때 까지 대기 초
        
        seq.AppendCallback(Pattern1Last);

        seq.Append(transform.DOMove(new Vector3(0, 21, 0), 0.8f));
    }

    private void DownLaserWarning() // 워닝이 내려오기
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 10), new Vector2(53, 2),0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 3), new Vector2(53, 2),0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, -3), new Vector2(53, 2),0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, -10), new Vector2(53, 2),0.1f)));
    }

    private void RepeatHorizontalLaser()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(DownLaserWarning)
        .AppendInterval(0.6f)
        .AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(0, 15.5f), new Vector2(53, 2), 0.3f)))
        .AppendInterval(0.5f);// 여기까지 한 루틴

        seq.AppendCallback(DownLaserWarning)
         .AppendInterval(0.6f)
         .AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(0, 15.5f), new Vector2(53, 2), 0.4f)))
         .AppendInterval(0.5f);// 여기까지 한 루틴

        seq.AppendCallback(DownLaserWarning)
        .AppendInterval(0.9f)
        .AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(0, 15.5f), new Vector2(53, 2), 0.3f)))
        .AppendInterval(0.5f);// 여기까지 한 루틴
    }
    /*-----------------------------------------------------------------------------------------------------------------*/
    private void RepeatRightLaser()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(RightInnerLaserWarning)
            .AppendInterval(0.5f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(27, 0), new Vector2(2, 30), new Vector3(0, 0), 0.3f)))
            .AppendCallback(RightouterLaserWarning)
            .AppendInterval(0.4f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(27, 0), 0.3f)));

        seq.AppendCallback(RightInnerLaserWarning)
            .AppendInterval(0.5f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(27, 0), new Vector2(2, 30), new Vector3(0, 0), 0.3f)))
            .AppendCallback(RightouterLaserWarning)
            .AppendInterval(0.4f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(27, 0), 0.3f)));

        seq.AppendCallback(RightInnerLaserWarning)
            .AppendInterval(0.5f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(27, 0), new Vector2(2, 30), new Vector3(0, 0), 0.3f)));
            
    }

    private void RepeatLeftLaser()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(LeftInnerLaserWarning)
            .AppendInterval(0.5f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(-27, 0), new Vector2(2, 30), new Vector3(0, 0), 0.3f)))
            .AppendCallback(LeftouterLaserWarning)
            .AppendInterval(0.4f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(-27, 0), 0.3f)));

        seq.AppendCallback(LeftInnerLaserWarning)
            .AppendInterval(0.5f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(-27, 0), new Vector2(2, 30), new Vector3(0, 0), 0.3f)))
            .AppendCallback(LeftouterLaserWarning)
            .AppendInterval(0.4f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(-27, 0), 0.3f)));

        seq.AppendCallback(LeftInnerLaserWarning)
            .AppendInterval(0.5f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(-27, 0), new Vector2(2, 30), new Vector3(0, 0), 0.3f)));            

    }

    private void RightInnerLaserWarning()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(23, 0), new Vector2(2, 30),0.1f))); //right
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(17, 0), new Vector2(2, 30),0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(11, 0), new Vector2(2, 30),0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(5, 0), new Vector2(2, 30),0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 30),0.1f)));
    }

    private void RightouterLaserWarning()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(5, 0), new Vector2(2, 30),0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(11, 0), new Vector2(2, 30),0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(17, 0), new Vector2(2, 30),0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(23, 0), new Vector2(2, 30),0.1f))); //right

    }

    private void LeftInnerLaserWarning()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-23, 0), new Vector2(2, 30), 0.1f))); //left
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-17, 0), new Vector2(2, 30), 0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-11, 0), new Vector2(2, 30), 0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-5, 0), new Vector2(2, 30), 0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 30),0.1f)));
    }

    private void LeftouterLaserWarning()
    {
        Sequence seq = DOTween.Sequence();

        /*seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 0), new Vector2(2, 30))));
        seq.AppendInterval(0.25f);*/
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-5, 0), new Vector2(2, 30), 0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-11, 0), new Vector2(2, 30), 0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-17, 0), new Vector2(2, 30), 0.1f)));
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-23, 0), new Vector2(2, 30), 0.1f))); //left
    }

    private void Pattern1Last()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(0.2f)
            .AppendCallback(RightouterLaserWarning)
            .AppendCallback(LeftouterLaserWarning)
            .AppendInterval(0.9f)
            //.AppendInterval(1f)
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(27, 0), 0.2f)))
            .AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(0, 0), new Vector2(2, 30), new Vector3(-27, 0), 0.2f)));

        
    }

    IEnumerator CreateWarning(Vector2 createPos, Vector2 scale, float delay)
    {
        GameObject a = PoolManager.Instance.Pop(_warningArea, createPos, Quaternion.identity);
        a.transform.localScale = scale;
        yield return new WaitForSeconds(delay);
        PoolManager.Instance.Push(a);
    }

    IEnumerator CreateHorizontalLaser(Vector2 createPos, Vector2 scale, float duration) // 레이져 내려오기
    {
        GameObject a = PoolManager.Instance.Pop(_horizontalLaser, createPos, Quaternion.identity);
        a.transform.localScale = scale;
        a.transform.DOMove(new Vector3(0, -16), duration);
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(a);
    }

    IEnumerator CreateVerticalLaser(Vector2 createPos, Vector2 scale, Vector3 moveVec, float duration) // 레이져 모이기
    {
        GameObject a = PoolManager.Instance.Pop(_verticalLaser, createPos, Quaternion.identity);
        a.transform.localScale = scale;
        a.transform.DOMove(moveVec, duration);
        yield return new WaitForSeconds(duration + 0.1f);
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
