using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int currentHP = 1;

    PlayerMove playerMove;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject Dieparticle;

    [SerializeField] GameObject GameOverPanel;
    private void Awake()
    {
        playerMove = FindObjectOfType<PlayerMove>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pattern"))
        {
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 0;
        audioSource.Pause();
        playerMove.cantMove = true;
        ParticleSystem particle = PoolManager.Instance.Pop(Dieparticle,transform.position,Quaternion.identity).GetComponent<ParticleSystem>();
        particle.startColor = transform.GetComponent<SpriteRenderer>().color;
    }
}
