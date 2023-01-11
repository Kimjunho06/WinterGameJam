using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kae : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("KaeJewel",PlayerPrefs.GetInt("KaeJewel") + 1);
            PlayerPrefs.SetInt("KaeCollect",PlayerPrefs.GetInt("KaeCollect",0) + 1);
            PoolManager.Instance.Push(gameObject);
            KaeSpawnManager.Instance.Spawn();
        }

    }
}