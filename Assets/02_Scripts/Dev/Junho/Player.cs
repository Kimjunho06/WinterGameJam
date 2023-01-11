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
    [SerializeField] AudioSource DieAudio;
    private void Awake()
    {
        playerMove = FindObjectOfType<PlayerMove>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pattern"))
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        Time.timeScale = 1;
        audioSource.Pause();
        DieAudio.Play();
        playerMove.cantMove = true;
        CameraManager.Instance.ScaleCam(-5f,0.5f);
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                SpriteRenderer particle = PoolManager.Instance.Pop(Dieparticle, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360))).GetComponent<SpriteRenderer>();
                if (transform.GetComponent<SpriteRenderer>().color == Color.black)
                {
                    particle.color = new Color(0.16f,0.16f,0.15f,1);
                }
                else
                {
                    particle.color = transform.GetComponent<SpriteRenderer>().color;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
        GameManager.Instance.Change(GameManager.Instance.stageIndex, transform.GetComponent<SpriteRenderer>().color);
    }
}
