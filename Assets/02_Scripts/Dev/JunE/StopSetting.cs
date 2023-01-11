using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StopSetting : MonoBehaviour
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] GameObject SettingPanel;

    [SerializeField] AudioSource buttonClick;

    PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GameObject.FindObjectOfType<PlayerMove>();
    }

    private void OnEnable()
    {
        BGMSource.Pause();
        Time.timeScale = 0;
        playerMove.cantMove = true;
    }

    public void Continue()
    {
        buttonClick.Play();
        StartCoroutine(StartGame());
    }

    public void RE()
    {
        buttonClick.Play();
        Time.timeScale = 1;
        GameManager.Instance.Change(GameManager.Instance.stageIndex, SelectManager.Instance.images[PlayerPrefs.GetInt("ColorIndex",0)].color);
    }

    public void Robby()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    IEnumerator StartGame()
    {
        yield return null;
        Time.timeScale = 1;
        SettingPanel.transform.DOScale(new Vector3(0f,0f,1f),0.3f);
        if(BGMSource!= null)
            BGMSource.UnPause();
        SettingPanel.gameObject.SetActive(false);
        playerMove.cantMove = false;
    }
}
