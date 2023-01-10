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
        stageButton = GetComponentsInChildren<Button>();
    }
    private void Start()
    {
        MaxClear = PlayerPrefs.GetInt("ClearStage", 1);
        for(int i = 0; i < MaxClear; i++)
        {
            stageButton[i].interactable = true;
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.R))
            PlayerPrefs.SetInt("ClearStage", 2);
    }

    public void CilckDevelopingStage()
    {
        StartCoroutine(DofadeText(developingText));
    }

    IEnumerator DofadeText(TextMeshProUGUI text)
    {
        developingText.gameObject.SetActive(true);
        Sequence seq = DOTween.Sequence();
        seq.Append(developingText.DOFade(1,0.6f));
        seq.Append(developingText.DOFade(0,0.6f));
        yield return new WaitForSeconds(1.2f);
        developingText.gameObject.SetActive(false);
    }
}
