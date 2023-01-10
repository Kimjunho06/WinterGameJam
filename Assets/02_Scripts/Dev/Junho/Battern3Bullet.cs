using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battern3Bullet : MonoBehaviour
{
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
