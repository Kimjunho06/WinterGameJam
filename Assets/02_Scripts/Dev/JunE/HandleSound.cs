using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            audioSource.Play();
        }
    }
}
