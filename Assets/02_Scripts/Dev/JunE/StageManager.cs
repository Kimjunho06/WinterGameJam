using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    Button[] stageButton;

    [SerializeField]TextMeshProUGUI developingText;

    [SerializeField] GameObject ExplainPanel;

    [SerializeField] AudioSource audioSource;

    int MaxClear = 0;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError($"{transform} : StageManager Multiple");
        }
        stageButton = GameObject.Find("StageSelectPanel").GetComponentsInChildren<Button>();
    }
    private void Start()
    {
        MaxClear = PlayerPrefs.GetInt("ClearStage", 1);
        for(int i = 0; i < MaxClear; i++)
        {
            stageButton[i].interactable = true;
        }
    }

    public void SelectAudio()
    {
        audioSource.Play();
    }

    public void CilckDevelopingStage()
    {
        if(!developingText.gameObject.activeSelf)
        StartCoroutine(DofadeText(developingText));
    }

    IEnumerator DofadeText(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(true);
        Sequence seq = DOTween.Sequence();
        seq.Append(text.DOFade(1,0.6f));
        seq.Append(text.DOFade(0,0.6f));
        yield return new WaitForSeconds(1.2f);
        text.gameObject.SetActive(false);
    }
}
