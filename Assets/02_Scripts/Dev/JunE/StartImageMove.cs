using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartImageMove : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(StartMove());
    }

    IEnumerator StartMove()
    {
        while(true)
        {
            //float randomtime = Random.Range(2,5);
            transform.DOScale(new Vector2(Random.Range(1,1.5f),Random.Range(1,1.5f)),2f);
            yield return new WaitForSeconds(2f);
        }
    }
}
