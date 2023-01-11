using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashParticle : MonoBehaviour
{
    private void Destroy()
    {
        PoolManager.Instance.Push(gameObject);
    }
}
