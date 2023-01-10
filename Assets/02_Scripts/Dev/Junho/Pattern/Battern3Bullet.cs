using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battern3Bullet : MonoBehaviour
{
    public float speed = 5f;
    
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);

        if (transform.position.x > 27 || transform.position.x < -27 || transform.position.y > 15.5f || transform.position.y < -15.5f)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
