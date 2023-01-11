using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pattern7 : MonoBehaviour
{
    public GameObject _chrome;
    public GameObject _Edge;
    
    public GameObject _chromeLaser;
    public GameObject _EdgeLaser;
    
    public GameObject _warningArea;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Pattern7Process();
        }
    }
    

    private void Pattern7Process()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(_chrome.transform.DOMove(new Vector2(-19.5f, 0), 0.5f));
        seq.Join(_Edge.transform.DOMove(new Vector2(19.5f, 0), 0.5f));

        seq.AppendInterval(0.7f);

        seq.AppendCallback(RandomTwistLaser);
        seq.AppendCallback(RandomTwistLaser);
        seq.AppendCallback(RandomTwistLaser);

        seq.AppendInterval(1.5f);

        seq.AppendCallback(RandomStraightLaser);
        seq.AppendCallback(RandomStraightLaser);
        seq.AppendCallback(RandomStraightLaser);
        seq.AppendCallback(RandomStraightLaser);
        
        seq.AppendInterval(1.5f);

        seq.Append(_chrome.transform.DOMove(new Vector2(-35f, 0), 0.5f));
        seq.Join(_Edge.transform.DOMove(new Vector2(35f, 0), 0.5f));
    }

    private void RandomStraightLaser() //전체 가로 -26 ~ 26, 세로 -14.5 ~ 14.5
    {
        Sequence seq = DOTween.Sequence();
        
        int rand = Random.Range(-14, 15);

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, rand), new Vector2(53, 1), 0.2f)));
        seq.AppendInterval(0.3f);
        seq.AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(-16.5f, rand), new Vector2(8, 1), new Vector3(16.5f, rand), 0.5f, _chromeLaser))); // 크롬 레이져 소환
        seq.AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(16.5f, rand), new Vector2(8, 1), new Vector3(-16.5f, rand), 0.5f, _EdgeLaser))); // 크롬 레이져 소환

    }

    private void RandomTwistLaser() //전체 가로 -26 ~ 26, 세로 -14.5 ~ 14.5
    {
        Sequence seq = DOTween.Sequence();

        int randChrome = Random.Range(-14, 15);
        int randEdge = Random.Range(-14, 15);
        float randdelay = Random.Range(0.2f, 0.6f);


        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, randChrome), new Vector2(53, 1), 0.2f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, randEdge), new Vector2(53, 1), 0.2f)));
        seq.AppendInterval(0.3f);

        seq.AppendInterval(randdelay);
        seq.AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(-16.5f, randChrome), new Vector2(8, 1), new Vector3(16.5f, randChrome), 0.5f, _chromeLaser))); // 크롬 레이져 소환
        seq.AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(16.5f, randEdge), new Vector2(8, 1), new Vector3(-16.5f, randEdge), 0.5f, _EdgeLaser))); // 크롬 레이져 소환
    }

    IEnumerator CreateHorizontalLaser(Vector2 createPos, Vector2 scale, Vector3 moveVec, float duration, GameObject createObj) // 레이져 모이기
    {
        GameObject a = PoolManager.Instance.Pop(createObj, createPos, Quaternion.identity);
        a.transform.localScale = scale;
        a.transform.DOMove(moveVec, duration);
        yield return new WaitForSeconds(0.7f);
        PoolManager.Instance.Push(a);
    }

    IEnumerator CreateWarning(Vector2 createPos, Vector2 scale, float delay)
    {
        GameObject a = PoolManager.Instance.Pop(_warningArea, createPos, Quaternion.identity);
        a.transform.localScale = scale;

        yield return new WaitForSeconds(delay);
        PoolManager.Instance.Push(a);
    }
}
