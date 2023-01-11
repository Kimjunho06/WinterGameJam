using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSound : MonoBehaviour
{
    public static SkinSound Instance = null;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError($"{transform} : SkinSound Multiple");
            Destroy(gameObject);
        }
    }
    [SerializeField] AudioSource audioSource;

    public void PlaySound()
    {
        audioSource.Play();
    }
}
