using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyClip : MonoBehaviour
{
    public static BuyClip Instance = null;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError($"{transform} : BuyClip Multiple");
            Destroy(gameObject);
        }
    }
    [SerializeField] AudioSource audioSource;

    public void PlaySound()
    {
        audioSource.Play();
    }
}
