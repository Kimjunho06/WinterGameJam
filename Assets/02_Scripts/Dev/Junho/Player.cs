using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHp = 3;
    private int currentHP;

    private void Start()
    {
        currentHP = maxHp;
    }

    private void Update()
    {
        Mathf.Clamp(currentHP, 0, maxHp);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pattern"))
        {
            currentHP--;
        }
    }
}
