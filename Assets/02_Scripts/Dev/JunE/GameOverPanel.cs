using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI explainTxt;
    [SerializeField] TextMeshProUGUI collectKae;
    [SerializeField] TextMeshProUGUI errorTxt;

    [SerializeField] Text showContext;
    [SerializeField] string ContextA;
    [SerializeField] string ContextB;
    [SerializeField] string ContextC;

    int selectIndex = 0;

    private void OnEnable()
    {
        collectKae.text = $"얻은 캐: {PlayerPrefs.GetInt("KaeCollect", 0)}";
    }
    public void CheckButton()
    {
        Debug.Log("123");
        if (selectIndex == 0)
        {
            SceneManager.LoadScene(0);
        }
        else if (selectIndex == 1)
        {
            SceneManager.LoadScene(GameManager.Instance.stageIndex);
        }
        else
        {
            if (GameManager.Instance.stageIndex + 1 > GameManager.Instance.maxStage)
            {
                if (!errorTxt.gameObject.activeSelf)
                    StartCoroutine(DofadeText(errorTxt));
            }
            else
            {

                SceneManager.LoadScene(GameManager.Instance.stageIndex + 1);
            }

        }
    }

    IEnumerator DofadeText(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(true);
        Sequence seq = DOTween.Sequence();
        seq.Append(text.DOFade(1, 0.6f));
        seq.Append(text.DOFade(0, 0.6f));
        yield return new WaitForSeconds(1.2f);
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (showContext.text == ContextA)
        {
            explainTxt.text = "로비 화면으로 돌아갑니다.";
            selectIndex = 0;
        }
        else if (showContext.text == ContextB)
        {
            explainTxt.text = "현재 스테이지를 다시 플레이합니다.";
            selectIndex = 1;
        }
        else
        {
            explainTxt.text = "다음 스테이지를 플레이합니다.";
            selectIndex = 2;
        }
    }
}
