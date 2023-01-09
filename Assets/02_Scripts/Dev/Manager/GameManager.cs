using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance = null;
    [SerializeField] GameObject optionPanel;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance =this;
        }
        else
        {
            Debug.LogError($"{transform} : GameManager Multiple");
            Destroy(gameObject);
        }

        if(optionPanel == null)
        {
            Debug.Log($"{transform} : optionPanel이 비어져있음");
            optionPanel = GameObject.Find("OptionPanel");
        }
    }

    void Update()
    {
        Inputkey();    
    }

    private void Inputkey()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(optionPanel.activeSelf)
            {
                optionPanel.SetActive(false);
                Time.timeScale = 1f;
                SoundManager.Instance.SoundContinue();
            }
            else
            {
                Time.timeScale = 0f;
                optionPanel.SetActive(true);
                SoundManager.Instance.SoundStop();
            }
        }
    }
}
