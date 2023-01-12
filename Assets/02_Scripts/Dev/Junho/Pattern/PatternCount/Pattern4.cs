using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pattern4 : MonoBehaviour
{
    public GameObject _warningArea;
    public GameObject _verticalLaser;
    public PlayerMove _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMove>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Pattern4Process();
        }
    }

    public void Pattern4Process()
    {
        Sequence seq = DOTween.Sequence();
        
        seq.Append(transform.DOMove(new Vector2(0, 0), 0.3f));
        seq.AppendCallback(() => _player.CamShakeSet(10, 0.5f));

        seq.AppendInterval(0.5f);

        seq.AppendCallback(RandomLaser); // 이거 개수 늘리면 많아짐
        seq.AppendCallback(RandomLaser);
        seq.AppendCallback(RandomLaser);
        seq.AppendCallback(RandomLaser);
        seq.AppendCallback(RandomLaser);
        seq.AppendCallback(RandomLaser);

        seq.AppendInterval(7.5f);

        seq.Append(transform.DOMove(new Vector2(0, 30), 0.5f));
    }

    private void RandomLaser() //전체 가로 -26 ~ 26, 세로 -14.5 ~ 14.5
    {
        Sequence seq = DOTween.Sequence();
        for (int i = 0; i <8; i++)
        {
            int rand = Random.Range(-26, 27);

            seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(rand, 0), new Vector2(2, 30), 0.2f)));
            seq.AppendInterval(0.4f);
            seq.AppendCallback(() => StartCoroutine(CreateVerticalLaser(new Vector2(rand, 32), new Vector2(2, 30), new Vector3(rand, -32), 0.5f, 0.5f)));
            seq.AppendInterval(0.5f);
        }
    }

    IEnumerator CreateVerticalLaser(Vector2 createPos, Vector2 scale, Vector3 moveVec, float duration, float delay) // 레이져 모이기
    {
        GameObject a = PoolManager.Instance.Pop(_verticalLaser, createPos, Quaternion.identity);
        a.transform.localScale = scale;
        a.transform.DOMove(moveVec, duration);
        yield return new WaitForSeconds(delay);
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
