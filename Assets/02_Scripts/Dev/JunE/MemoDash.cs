using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MemoDash : MonoBehaviour
{
    [SerializeField] GameObject dashParticle;
    private void OnEnable()
    {
        StartCoroutine(StartTuto());
    }

    IEnumerator StartTuto()
    {
        yield return new WaitForSeconds(0.5f);
        while(true)
        {
            transform.position = new Vector2(920,340);
            yield return new WaitForSeconds(1f);
            transform.position = new Vector2(1100,280);
            yield return new WaitForSeconds(2F);
        }
    }

    private void OnDisable()
    {
        DOTween.KillAll();
        StopAllCoroutines();
    }
}
