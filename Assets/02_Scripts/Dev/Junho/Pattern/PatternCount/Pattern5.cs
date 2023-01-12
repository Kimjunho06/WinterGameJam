using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pattern5 : MonoBehaviour
{
    public GameObject _warningArea;

    public GameObject _bullet;

    public GameObject _XboxImage1;
    public GameObject _XboxImage2;
    public GameObject _XboxImage3;
    public GameObject _XboxImage4;

    public bool _isBulletOff = false;
    public bool _isPassPatter6 = false;
    public PlayerMove _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMove>();
    }

    public void Pattern5Process()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-19, 4), new Vector2(13, 18), 0.5f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(-19, -10), new Vector2(13, 9), 0.5f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(0, 12.5f), new Vector2(22, 3), 0.5f)));
        seq.AppendCallback(() => StartCoroutine(CreateWarning(new Vector2(19, 6), new Vector2(13, 13), 0.5f)));

        seq.AppendInterval(0.5f);

        seq.Append(transform.DOScale(new Vector3(1,2f, 1.2f), 0.2f));
        seq.Append(transform.DOScale(new Vector3(0.8f, 0.8f), 0.2f));
        seq.Append(transform.DOScale(new Vector3(1f, 1f), 0.2f));
        seq.AppendCallback(() => _player.CamShakeSet(7, 0.5f));

        seq.AppendInterval(0.2f);

        seq.AppendCallback(RepeatFireBullet);
        seq.AppendInterval(14f);
        seq.AppendCallback(() => _isBulletOff = true);

    }

    private void RepeatFireBullet() // 45 60 90 75
    {
        Sequence seq = DOTween.Sequence();
     
        seq.AppendCallback(() => BulletFire(_XboxImage1, 45));
        seq.AppendCallback(() => BulletFire(_XboxImage2, 60));
        seq.AppendCallback(() => BulletFire(_XboxImage3, 90));
        seq.AppendCallback(() => BulletFire(_XboxImage4, 75));
        
        seq.AppendInterval(1.7f);

        seq.AppendCallback(() => BulletFire(_XboxImage1, 60));
        seq.AppendCallback(() => BulletFire(_XboxImage2, 90));
        seq.AppendCallback(() => BulletFire(_XboxImage3, 75));
        seq.AppendCallback(() => BulletFire(_XboxImage4, 45));

        seq.AppendInterval(1.7f);

        seq.AppendCallback(() => BulletFire(_XboxImage1, 75));
        seq.AppendCallback(() => BulletFire(_XboxImage2, 45));
        seq.AppendCallback(() => BulletFire(_XboxImage3, 60));
        seq.AppendCallback(() => BulletFire(_XboxImage4, 90));

        seq.AppendInterval(1.7f);

        seq.AppendCallback(() => BulletFire(_XboxImage1, 90));
        seq.AppendCallback(() => BulletFire(_XboxImage2, 75));
        seq.AppendCallback(() => BulletFire(_XboxImage3, 45));
        seq.AppendCallback(() => BulletFire(_XboxImage4, 60));

        seq.AppendInterval(1.7f);

        seq.AppendCallback(() => BulletFire(_XboxImage1, 60));
        seq.AppendCallback(() => BulletFire(_XboxImage2, 90));
        seq.AppendCallback(() => BulletFire(_XboxImage3, 75));
        seq.AppendCallback(() => BulletFire(_XboxImage4, 45));

        seq.AppendInterval(1.7f);

        seq.AppendCallback(() => BulletFire(_XboxImage1, 45));
        seq.AppendCallback(() => BulletFire(_XboxImage2, 75));
        seq.AppendCallback(() => BulletFire(_XboxImage3, 90));
        seq.AppendCallback(() => BulletFire(_XboxImage4, 60));

        seq.AppendInterval(1.7f);

        seq.AppendCallback(() => BulletFire(_XboxImage1, 45));
        seq.AppendCallback(() => BulletFire(_XboxImage2, 60));
        seq.AppendCallback(() => BulletFire(_XboxImage3, 90));
        seq.AppendCallback(() => BulletFire(_XboxImage4, 75));

        seq.AppendInterval(1.7f);

        seq.AppendCallback(() => BulletFire(_XboxImage1, 60));
        seq.AppendCallback(() => BulletFire(_XboxImage2, 90));
        seq.AppendCallback(() => BulletFire(_XboxImage3, 75));
        seq.AppendCallback(() => BulletFire(_XboxImage4, 45));

        seq.AppendInterval(1.7f);

        seq.AppendCallback(() => BulletFire(_XboxImage1, 75));
        seq.AppendCallback(() => BulletFire(_XboxImage2, 45));
        seq.AppendCallback(() => BulletFire(_XboxImage3, 60));
        seq.AppendCallback(() => BulletFire(_XboxImage4, 90));

        seq.AppendInterval(1.7f);

        seq.AppendCallback(() => BulletFire(_XboxImage1, 90));
        seq.AppendCallback(() => BulletFire(_XboxImage2, 75));
        seq.AppendCallback(() => BulletFire(_XboxImage3, 45));
        seq.AppendCallback(() => BulletFire(_XboxImage4, 60));

        seq.AppendInterval(1.7f);

    }

    private void BulletFire(GameObject createPos, int angle)
    {
        for (int i = 0; i < 360; i += angle)
        {
            PoolManager.Instance.Pop(_bullet, createPos.transform.position, Quaternion.Euler(0, 0, i));
        }
    }

    IEnumerator CreateWarning(Vector2 createPos, Vector2 scale, float delay)
    {
        GameObject a = PoolManager.Instance.Pop(_warningArea, createPos, Quaternion.identity);
        a.transform.localScale = scale;

        yield return new WaitForSeconds(delay);
        PoolManager.Instance.Push(a);
    }
}
