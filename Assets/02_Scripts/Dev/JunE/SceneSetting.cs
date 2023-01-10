using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        if (!ExplainPanel.activeSelf)
        {
            ExplainPanel.SetActive(true);
            ExplainPanel.transform.localPosition = new Vector2(transform.localPosition.x , transform.localPosition.y + 500);
        }

        if(ButtonManager.Instance.isMax)
        {
            ExplainPanel.transform.DOScale(new Vector3(2.4f,2,1),0.7f);
            ExplainPanel.transform.DOMove(new Vector3(960,540,0), 0.8f);
        }
        else
        {
            ExplainPanel.transform.DOScale(new Vector3(1, 1, 1),0.7f);
            ExplainPanel.transform.DOMove(new Vector3(1450, 335, 0), 0.8f);
        }
        Explain explain = GameObject.Find("ExplainPanel").GetComponent<Explain>();
        explain.UpdateExplain(nowIndex, image, nameTxt, levelTxt, timeTxt);
    }
}
