using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Tilemaps;

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

    private Pattern2 _p2;
    private bool _isBounce = true;

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
    }

    private void Pattern3Process()
    {
        Sequence seq = DOTween.Sequence();

        if (_p2._passPattern3)
        {
            seq.AppendCallback(() => _isBounce = true);
            seq.AppendCallback(RotateChrome);
            seq.AppendInterval(3.5f);
            //seq.AppendCallback(() => _isBounce = false);
            //seq.Append(transform.DOScale(new Vector3(0,0,0), 0.5f));
        }
    }

    private void RotateChrome() // 여기 고치기
    {
        Sequence seq = DOTween.Sequence();

        for (int i = 0; i < 7; i++)
        {
            int rand = Random.Range(-90, 90);

            seq.Append(transform.DORotate(new Vector3(0, 0, rand), 0.42f));
            seq.AppendCallback(() => StartCoroutine(CreateWarning(transform.position, new Vector2(55, 30), Vector3.zero, 0.3f)));

            seq.AppendInterval(1f);

            for (int j = 0; j < 5; j++)
            {
                seq.AppendCallback(() => BulletFire(leftup.transform, (leftup.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z)*-1));
                seq.AppendCallback(() => BulletFire(leftmiddle.transform, (leftmiddle.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z)*-1));
                seq.AppendCallback(() => BulletFire(leftdown.transform, (leftdown.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z)*-1));
                seq.AppendCallback(() => BulletFire(rightup.transform, (rightup.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z)*-1));
                seq.AppendCallback(() => BulletFire(rightmiddle.transform, (rightmiddle.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z)*-1));
                seq.AppendCallback(() => BulletFire(rightdown.transform, (rightdown.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z)*-1));
                seq.AppendCallback(() => BulletFire(middleup.transform, (middleup.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z)*-1));
                seq.AppendCallback(() => BulletFire(middledown.transform, (middledown.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z)*-1));
                seq.AppendInterval(0.2f);

            }

            seq.AppendInterval(1f);
        }
        seq.Append(transform.DORotate(Vector3.zero, 0.42f));
    }

    private void BulletFire(Transform position, float rotation)
    {
        GameObject a = PoolManager.Instance.Pop(_bullet, position.position, Quaternion.Euler(0, 0, rotation));
        print(a.transform.rotation);
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

    IEnumerator CreateWarning(Vector2 createPos, Vector2 scale, Vector3 rotation, float delay)
    {
        GameObject a = PoolManager.Instance.Pop(_warningArea, createPos, Quaternion.identity);
        a.transform.localScale = scale;
        a.transform.rotation = Quaternion.Euler(rotation);
        
        yield return new WaitForSeconds(delay);
        PoolManager.Instance.Push(a);
    }
}
