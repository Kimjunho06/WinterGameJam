using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class BlackSkinPrice : MonoBehaviour
{
    public int price = 0;
    public TextMeshProUGUI priceTxt;
    [SerializeField] int index;
    [SerializeField] TextMeshProUGUI TribeKae;
    [SerializeField] AudioSource selectSource;

    private void OnEnable()
    {
        SelectManager.Instance.UpdateBool();
    }

    public void UpdateBlackPrice()
    {
        price = 0;
        for(int i = 0; i < index; i++)
        {
            if(!SelectManager.Instance.IsBuy(i))
                price += 200;
        }
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
            if (price == 0)
            {
                BuyClip.Instance.PlaySound();
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
        if(Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetInt("KaeJewel",0);
        }
        UpdateBlackPrice();
        if(!SelectManager.Instance.IsBuy(index))
        {
            priceTxt.text = $"{price}캐";
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
