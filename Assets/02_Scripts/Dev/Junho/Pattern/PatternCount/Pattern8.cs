using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern8 : MonoBehaviour
{
    public GameObject _painterLaser;
    public GameObject _warningArea;

    public PlayerMove _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMove>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pattern8Process();
        }
    }

    public void Pattern8Process()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOScale(new Vector2(2.8f, 2.95f), 0.5f));
        seq.AppendCallback(() => _player.CamShakeSet(10, 0.5f));
        seq.AppendInterval(0.07f);
        seq.AppendCallback(() => _player._isMoveLimit = true);

        for (int i = 0; i < 56; i++)
        {
            seq.AppendCallback(CreateRandomLaser);
            seq.AppendCallback(CreateRandomLaser);
            seq.AppendCallback(CreateRandomLaser);
            seq.AppendInterval(0.4f);
        }
    }

    private void CreateRandomLaser()
    {
        Sequence seq = DOTween.Sequence();

        int randX = Random.Range(-11, 12);
        int randY = Random.Range(-5, 6);
        int randAngle = Random.Range(0, 361);

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(randX, randY), new Vector2(100, 1), randAngle, 0.2f)));
        seq.AppendInterval(0.2f);
        seq.AppendCallback(() => StartCoroutine(CreateHorizontalLaser(new Vector2(randX, randY), new Vector2(100, 1), randAngle)));
    }

    IEnumerator CreateHorizontalLaser(Vector2 createPos, Vector2 scale, float angle) // 레이져 모이기
    {
        GameObject a = PoolManager.Instance.Pop(_painterLaser, createPos, Quaternion.Euler(new Vector3(0,0,angle)));
        a.transform.localScale = scale;
        yield return new WaitForSeconds(0.25f);
        PoolManager.Instance.Push(a);
    }

    IEnumerator CreateWarning(Vector2 createPos, Vector2 scale, float angle ,float delay)
    {
        GameObject a = PoolManager.Instance.Pop(_warningArea, createPos, Quaternion.Euler(new Vector3(0, 0, angle)));
        a.transform.localScale = scale;

        yield return new WaitForSeconds(delay);
        PoolManager.Instance.Push(a);
    }
}
