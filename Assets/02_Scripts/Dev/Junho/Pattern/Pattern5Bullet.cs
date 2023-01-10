using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern5Bullet : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
