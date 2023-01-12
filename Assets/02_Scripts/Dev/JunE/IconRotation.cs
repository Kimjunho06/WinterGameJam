using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconRotation : MonoBehaviour
{
    float rot = 0;
    private void OnEnable()
    {
        StartCoroutine(Rotting());
    }

    IEnumerator Rotting()
    {
        rot = transform.rotation.z;
        while(true)
        {
            transform.rotation = Quaternion.Euler(0,0,rot);
            rot++;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
