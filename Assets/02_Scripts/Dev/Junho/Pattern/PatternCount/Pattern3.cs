using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Pattern3 : MonoBehaviour
{
    public GameObject _bullet;

    private Pattern2 _p2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Pattern3Process();
        }

        GameObject a = PoolManager.Instance.Pop(_bullet, transform.position, Quaternion.identity);
    }

    private void Pattern3Process()
    {
        if (_p2._passPattern3)
        {

        }
    }
}
