using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParticle : MonoBehaviour
{
    [SerializeField] float time = 0.4f;
    private float yieldTime = 0f;

    private void OnEnable()
    {
        yieldTime = 0;
    }

    private void Update()
    {
        yieldTime += Time.deltaTime;
        if(yieldTime > time)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
