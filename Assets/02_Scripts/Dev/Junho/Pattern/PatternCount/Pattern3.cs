using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Tilemaps;

public class Pattern3 : MonoBehaviour
{
    public GameObject _bullet;
    
    public GameObject leftup;
    public GameObject leftmiddle;
    public GameObject leftdown;
    public GameObject rightup;
    public GameObject rightmiddle;
    public GameObject rightdown;
    public GameObject middleup;
    public GameObject middledown;

    private Pattern2 _p2;
    private bool _isBounce = false;

    private void Awake()
    {
        _p2= GetComponent<Pattern2>();
    }

    private void Start()
    {
        StartCoroutine(ChromeBounce());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Pattern3Process();
        }


        //GameObject a = PoolManager.Instance.Pop(_bullet, transform.position, Quaternion.identity);
    }

    private void Pattern3Process()
    {
        Sequence seq = DOTween.Sequence();

        if (_p2._passPattern3)
        {
            seq.AppendCallback(() => _isBounce = true);
            seq.AppendCallback(RotateChrome);
            seq.AppendInterval(3.5f);
            seq.AppendCallback(() => _isBounce = false);
            seq.Append(transform.DOScale(new Vector3(0,0,0), 0.5f));
        }
    }

    private void RotateChrome()
    {
        Sequence seq = DOTween.Sequence();

        for (int i = 0; i < 7; i++)
        {
            int rand = Random.Range(0, 361);

            seq.Append(transform.DORotate(new Vector3(0, 0, rand), 0.42f));
            seq.AppendCallback(BulletFire);
        }
        seq.Append(transform.DORotate(Vector3.zero, 0.42f));
    }

    private void BulletFire()
    {
        Quaternion dir = Quaternion.Euler(new Vector3(0,0,0));
        PoolManager.Instance.Pop(_bullet, transform.position, dir);
    }

    IEnumerator ChromeBounce()
    {
        while (_isBounce)
        {
            transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.8f);
            yield return new WaitForSeconds(0.21f);
            transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f);
            yield return new WaitForSeconds(0.21f);
        }
    }
}
