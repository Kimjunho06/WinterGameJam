using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopSetting : MonoBehaviour
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] GameObject SettingPanel;

    PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GameObject.FindObjectOfType<PlayerMove>();
    }

    private void OnEnable()
    {
        playerMove.cantMove = true;
        BGMSource.Pause();
        Time.timeScale = 0;
    }

    public void Continue()
    {
        SettingPanel.gameObject.SetActive(false);
    }

    public void RE()
    {
        Time.timeScale = 1;
        GameManager.Instance.Change(GameManager.Instance.stageIndex, SelectManager.Instance.images[PlayerPrefs.GetInt("ColorIndex",0)].color);
    }

    public void Robby()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        if(BGMSource!= null)
            BGMSource.UnPause();
        Time.timeScale = 1;
        playerMove.cantMove = false;
    }
}
