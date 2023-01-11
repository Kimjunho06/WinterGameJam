using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pattern3Bullet : MonoBehaviour
{
    public float speed = 5f;

    private SpriteRenderer _sprite;

    Pattern5 _p5;

    private void Awake()
    {
        _p5 = FindObjectOfType<Pattern5>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);

        if (transform.position.x > 27 || transform.position.x < -27 || transform.position.y > 15.5f || transform.position.y < -15.5f)
        {
            PoolManager.Instance.Push(gameObject);
        }

        if (_p5._isBulletOff && gameObject.activeSelf)
        {
            StartCoroutine(FadePush());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PoolManager.Instance.Push(gameObject);
        }
    }

    IEnumerator FadePush()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOScale(new Vector3(1.5f, 1.5f), 0.3f));
        seq.Append(_sprite.DOFade(0, 0.2f));
        yield return new WaitForSeconds(0.5f);
        PoolManager.Instance.Push(gameObject);
    }
}
