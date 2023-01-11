using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class SkinPrice : MonoBehaviour
{
    public int price = 200;
    public TextMeshProUGUI priceTxt;
    [SerializeField] int index;
    [SerializeField] TextMeshProUGUI TribeKae;
    [SerializeField] AudioSource selectSource;

    private void OnEnable()
    {
        SelectManager.Instance.UpdateBool();
    }

    public void OnClickImage()
    {
        if (SelectManager.Instance.IsBuy(index))
        {
            PlayerPrefs.SetInt("ColorIndex", index);
            selectSource.Play();
            SelectManager.Instance.UpdateBool();
        }
        else
        {
            if (PlayerPrefs.GetInt("KaeJewel", 0) >= 200)
            {
                BuyClip.Instance.PlaySound();
                PlayerPrefs.SetInt("KaeJewel", PlayerPrefs.GetInt("KaeJewel", 0) - 200);
                SelectManager.Instance.UpdateKae();
                PlayerPrefs.SetString($"{index}", "삼");
                SelectManager.Instance.UpdateBool();
            }
            else
            {
                if (!TribeKae.gameObject.activeSelf)
                    StartCoroutine(DofadeText(TribeKae));
                SkinSound.Instance.PlaySound();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("리셋~~~~~~");
            PlayerPrefs.SetString($"{index}", "사야댐");
            SelectManager.Instance.UpdateBool();
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
}
