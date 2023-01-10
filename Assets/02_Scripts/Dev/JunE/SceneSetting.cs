using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSetting : MonoBehaviour
{
    public int nowIndex = 1;
    [SerializeField] Sprite image;
    [SerializeField] string nameTxt;
    [SerializeField] string levelTxt;
    [SerializeField] string timeTxt;
    [SerializeField] GameObject ExplainPanel;
    public void OnClick()
    {
        ExplainPanel.SetActive(true);
        Explain explain = GameObject.Find("ExplainPanel").GetComponent<Explain>();
        explain.UpdateExplain(nowIndex, image, nameTxt, levelTxt, timeTxt);
    }
}
