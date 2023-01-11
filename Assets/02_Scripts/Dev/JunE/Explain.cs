using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Explain : MonoBehaviour
{
    private int nowIndex = 1;
    [SerializeField] Image explainImage;
    [SerializeField] TextMeshProUGUI nameTxt;
    [SerializeField] TextMeshProUGUI levelTxt;
    [SerializeField] TextMeshProUGUI timeTxt;

    [SerializeField] GameObject developingText;

    [SerializeField] AudioSource errorSource;
    public void UpdateExplain(int level, Sprite image, string name, string levelS, string time)
    {
        nowIndex = level;
        explainImage.sprite = image;
        nameTxt.text = "제목: " + name;
        levelTxt.text = "레벨: " + levelS;
        timeTxt.text = "시간: " + time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (nowIndex != 0)
                GameManager.Instance.Change(nowIndex, SelectManager.Instance.images[PlayerPrefs.GetInt("ColorIndex",0)].color);
            else
            {
                errorSource.Play();
                StageManager.Instance.CilckDevelopingStage();
            }
        }
    }

    
}
