using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pattern3 : MonoBehaviour
{
    public GameObject _bullet;
    public GameObject _warningArea;
    
    public GameObject leftup;
    public GameObject leftmiddle;
    public GameObject leftdown;
    public GameObject rightup;
    public GameObject rightmiddle;
    public GameObject rightdown;
    public GameObject middleup;
    public GameObject middledown;

    private bool _isBounce = false;
    public PlayerMove _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMove>();
    }

    private void Start()
    {
        StartCoroutine(ChromeBounce());
    }

    public void Pattern3Process()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOScale(new Vector2(2, 2), 0.1f));
        seq.AppendCallback(() => _player.CamShakeSet(7, 0.5f));
        seq.AppendInterval(0.1f);

        seq.AppendCallback(() => _isBounce = true);

        seq.AppendInterval(0.6f);

        seq.AppendCallback(RotateChrome);
        
    }

    private void RotateChrome() // 여기 고치기
    {
        Sequence seq = DOTween.Sequence();

        for (int i = 0; i < 2; i++)
        {
            int rand = Random.Range(-90, 90);

            seq.Append(transform.DORotate(new Vector3(0, 0, rand), 0.2f));
            seq.AppendCallback(() => StartCoroutine(CreateWarning(transform.position, new Vector2(55, 30), Vector3.zero, 0.2f)));

            seq.AppendInterval(0.8f);

            for (int j = 0; j < 5; j++)
            {
                seq.AppendCallback(() => BulletFire(leftup));
                seq.AppendCallback(() => BulletFire(leftmiddle));
                seq.AppendCallback(() => BulletFire(leftdown));
                seq.AppendCallback(() => BulletFire(rightup));
                seq.AppendCallback(() => BulletFire(rightmiddle));
                seq.AppendCallback(() => BulletFire(rightdown));
                seq.AppendCallback(() => BulletFire(middleup));
                seq.AppendCallback(() => BulletFire(middledown));
                seq.AppendInterval(0.08f);

            }

            seq.AppendInterval(0.34f);
        }

        seq.Append(transform.DORotate(Vector3.zero, 0.2f));
        for (int i = 0; i < 2; i++)
        {
            seq.AppendCallback(() => StartCoroutine(CreateWarning(transform.position, new Vector2(55, 30), Vector3.zero, 0.2f)));
            
            seq.AppendInterval(1f);
            
            for (int j = 0; j < 4; j++)
            {
                seq.AppendCallback(() => BulletFire(leftup));
                seq.AppendCallback(() => BulletFire(leftmiddle));
                seq.AppendCallback(() => BulletFire(leftdown));
                seq.AppendCallback(() => BulletFire(rightup));
                seq.AppendCallback(() => BulletFire(rightmiddle));
                seq.AppendCallback(() => BulletFire(rightdown));
                seq.AppendCallback(() => BulletFire(middleup));
                seq.AppendCallback(() => BulletFire(middledown));
                seq.AppendInterval(0.2f);
            }
        }

        seq.AppendCallback(() => _isBounce = false);
        seq.Join(transform.DOScale(new Vector3(0, 0, 0), 0.1f));
    }

    private void BulletFire(GameObject firePos)
    {
        Vector2 dir = new Vector2(firePos.transform.position.x - transform.position.x, firePos.transform.position.y - transform.position.y);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        GameObject a = PoolManager.Instance.Pop(_bullet, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
    }

    IEnumerator ChromeBounce()
    {
        while (_isBounce)
        {
            transform.DOScale(new Vector3(1.7f, 1.7f, 1.7f), 0.8f);
            yield return new WaitForSeconds(0.21f);
            transform.DOScale(new Vector3(2.2f, 2.2f, 2.2f), 0.5f);
            yield return new WaitForSeconds(0.21f);
        }
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
