using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance = null;

    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject StageSelcetPanel;
    [SerializeField] GameObject ExplainPanel;
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject GamePower;
    [SerializeField] GameObject SettingPanel;
    [SerializeField] GameObject ExplainArrow;

    [SerializeField] AudioSource audioSource;

    private bool isCo = false;
    public bool isMax = false;
    private bool isOnPower = false;

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
        if (!StartPanel.activeSelf)
        {
            if(ExplainArrow!= null)
                Destroy(ExplainArrow);
            StartPanel.SetActive(true);
            StartPanel.transform.DOScaleX(1f, 0.05f);
            StartPanel.transform.DOScaleY(1f, 0.08f);
        }
        else
        {
            StartPanel.transform.DOScaleX(0f, 0.05f);
            StartPanel.transform.DOScaleY(0f, 0.08f);
            StartPanel.SetActive(false);
        }
    }

    public void StartKey()
    {
        SoundListen();
        if (!isCo)
            if (!StageSelcetPanel.activeSelf)
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
        StageSelcetPanel.SetActive(true);
        titleText.transform.DOMoveY(350, 1f);
        StageSelcetPanel.transform.DOMoveY(1080, 1f);
        yield return new WaitForSeconds(1f);
        isCo = false;
    }

    IEnumerator falseStageSelect()
    {
        isCo = true;
        titleText.transform.DOMoveY(500, 1f);
        StageSelcetPanel.transform.DOMoveY(1360, 1f);
        yield return new WaitForSeconds(1f);
        StageSelcetPanel.SetActive(false);
        isCo = false;
    }

    public void XButton()
    {
        SoundListen();
        ExplainPanel.SetActive(false);
        ExplainPanel.transform.localScale = new Vector3(0, 0, 1);

        isMax = false;
    }

    public void MaxButton()
    {
        SoundListen();
        if (!isMax)
        {
            ExplainPanel.transform.DOMove(new Vector3(960, 540, 0), 0.05f);
            ExplainPanel.transform.DOScale(new Vector3(2.4f, 2, 1), 0.05f);
            isMax = true;
        }
        else
        {
            ExplainPanel.transform.DOMove(new Vector3(1450, 335, 0), 0.05f);
            ExplainPanel.transform.DOScale(new Vector3(1, 1, 1), 0.05f);
            isMax = false;
        }
    }

    public void MinButton()
    {
        SoundListen();
        ExplainPanel.transform.DOMove(new Vector3(500, 50, 0), 0.3f);
        ExplainPanel.transform.DOScale(new Vector3(0, 0, 1), 0.4f);
    }

    public void ClickPower()
    {
        SoundListen();
        if (isOnPower)
        {
            GamePower.SetActive(false);
            isOnPower = false;
        }
        else
        {
            GamePower.transform.position = new Vector3(152, 100, 0);
            GamePower.SetActive(true);
            GamePower.transform.DOMove(new Vector3(152, 135, 0), 0.35f);
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
        if (!SettingPanel.activeSelf)
        {
            //StartPanel.transform.DOScaleX(0f, 0.05f);
            //StartPanel.transform.DOScaleY(0f, 0.08f);
            //StartPanel.SetActive(false);

            SettingPanel.SetActive(true);
        }
        else
            CloseSetting();
    }

    public void CloseSetting()
    {
        SettingPanel.SetActive(false);
    }
}
