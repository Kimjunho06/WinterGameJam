using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPattern : MonoBehaviour
{
    public GameObject _warningArea;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(CreateWarning());
        }
        
    }

    IEnumerator CreateWarning()
    {
        GameObject a = PoolManager.Instance.Pop(_warningArea, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(a);
    }
}
