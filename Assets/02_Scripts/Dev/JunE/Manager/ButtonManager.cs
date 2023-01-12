using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance = null;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject stageSelcetPanel;
    [SerializeField] GameObject explainPanel;
    [SerializeField] GameObject[] titleText;
    [SerializeField] GameObject gamePower;
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject explainArrow;
    [SerializeField] GameObject paperPanel;

    [SerializeField] AudioSource audioSource;

    private bool isCo = false;
    public bool isMax = false;
    private bool isOnPower = false;
    private bool isMemo = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError($"{transform} : ButtonManager Multiple");
            Destroy(gameObject);
        }
    }

    public void SoundListen()
    {
        audioSource.Play();
    }
    public void WindowKey()
    {
        SoundListen();
        if (!startPanel.activeSelf)
        {
            if (explainArrow != null)
                Destroy(explainArrow);
            startPanel.SetActive(true);
            startPanel.transform.DOScaleX(1f, 0.05f);
            startPanel.transform.DOScaleY(1f, 0.08f);
        }
        else
        {
            startPanel.transform.DOScaleX(0f, 0.05f);
            startPanel.transform.DOScaleY(0f, 0.08f);
            startPanel.SetActive(false);
        }
    }

    public void StartKey()
    {
        SoundListen();
        if (!isCo)
            if (!stageSelcetPanel.activeSelf)
            {
                StartCoroutine(trueStageSelect());
            }
            else
            {
                StartCoroutine(falseStageSelect());
            }
    }

    IEnumerator trueStageSelect()
    {
        isCo = true;
        stageSelcetPanel.SetActive(true);
        for(int i = 0; i < titleText.Length; i++)
        {
            titleText[i].transform.DOMoveY(350, 1f);
            i++;
        }
        stageSelcetPanel.transform.DOMoveY(1080, 1f);
        yield return new WaitForSeconds(1f);
        isCo = false;
    }

    IEnumerator falseStageSelect()
    {
        isCo = true;
        for(int i = 0; i < titleText.Length; i++)
        {
            titleText[i].transform.DOMoveY(500, 1f);
            i++;
        }
        stageSelcetPanel.transform.DOMoveY(1360, 1f);
        yield return new WaitForSeconds(1f);
        stageSelcetPanel.SetActive(false);
        isCo = false;
    }

    public void XButton()
    {
        SoundListen();
        explainPanel.SetActive(false);
        explainPanel.transform.localScale = new Vector3(0, 0, 1);

        isMax = false;
    }

    public void MaxButton()
    {
        SoundListen();
        if (!isMax)
        {
            explainPanel.transform.DOMove(new Vector3(960, 540, 0), 0.05f);
            explainPanel.transform.DOScale(new Vector3(2.4f, 2, 1), 0.05f);
            isMax = true;
        }
        else
        {
            explainPanel.transform.DOMove(new Vector3(1450, 335, 0), 0.05f);
            explainPanel.transform.DOScale(new Vector3(1, 1, 1), 0.05f);
            isMax = false;
        }
    }

    public void MinButton()
    {
        SoundListen();
        explainPanel.transform.DOMove(new Vector3(500, 50, 0), 0.3f);
        explainPanel.transform.DOScale(new Vector3(0, 0, 1), 0.4f);
    }

    public void ClickPower()
    {
        SoundListen();
        if (isOnPower)
        {
            gamePower.SetActive(false);
            isOnPower = false;
        }
        else
        {
            gamePower.transform.position = new Vector3(152, 100, 0);
            gamePower.SetActive(true);
            gamePower.transform.DOMove(new Vector3(152, 135, 0), 0.35f);
            isOnPower = true;
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void ClickSetting()
    {
        SoundListen();
        if (!settingPanel.activeSelf)
        {
            //StartPanel.transform.DOScaleX(0f, 0.05f);
            //StartPanel.transform.DOScaleY(0f, 0.08f);
            //StartPanel.SetActive(false);

            settingPanel.SetActive(true);
        }
        else
            CloseSetting();
    }

    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }

    public void ClickPaper()
    {
        SoundListen();
        if (!isMemo)
        {
            if (!paperPanel.activeSelf)
            {
                StartCoroutine(OpenMemo());
            }
            else
            {
                StartCoroutine(ClosePaper());
            }
        }
    }

    IEnumerator OpenMemo()
    {
        isMemo = true;
        paperPanel.SetActive(true);
        paperPanel.transform.position = new Vector3(100, 200);
        paperPanel.transform.localScale = new Vector3(0, 0);
        paperPanel.transform.DOScale(new Vector3(1, 1, 1), 0.4f);
        paperPanel.transform.DOMove(new Vector3(1000, 500), 0.4f);
        yield return new WaitForSeconds(0.4f);
        isMemo = false;
    }

    IEnumerator ClosePaper()
    {
        isMemo = true;
        paperPanel.transform.DOScale(new Vector3(0, 0, 1), 0.4f);
        paperPanel.transform.DOMove(new Vector3(100, 200), 0.4f);
        yield return new WaitForSeconds(0.4f);
        paperPanel.SetActive(false);
        isMemo = false;
    }

    public void ClickPaperX()
    {
        paperPanel.transform.position = new Vector3(100, 200);
        paperPanel.transform.localScale = new Vector3(0, 0);
        paperPanel.SetActive(false);
    }

}
