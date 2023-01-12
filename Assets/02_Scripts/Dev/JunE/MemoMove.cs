using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MemoMove : MonoBehaviour
{
    [SerializeField] GameObject moveParticle;
    private void OnEnable()
    {
        StartCoroutine(StartTuto());
    }

    IEnumerator StartTuto()
    {
        yield return new WaitForSeconds(0.5f);
        while(true)
        {
            transform.position = new Vector2(920,540);
            transform.DOMove(new Vector2(1100,480),2f);
            //StartCoroutine("SParticle");
            yield return new WaitForSeconds(2f);
            //StopCoroutine("SParticle");
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator SParticle()
    {
        while(true)
        {
            ParticleSystem particleSystem = PoolManager.Instance.Pop(moveParticle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            if(particleSystem.GetComponent<RectTransform>() != null)
                particleSystem.gameObject.AddComponent<RectTransform>();
            particleSystem.transform.parent = GameObject.Find("OutLine(Move)").transform;
            //particleSystem.startColor = new Color(0.16f,0.16f,0.15f,1);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnDisable()
    {
        DOTween.KillAll();
        StopAllCoroutines();
    }
}
