using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SelectManager : MonoBehaviour
{
    public static SelectManager Instance = null;

    public int nowKae = 0;

    [SerializeField] GameObject parent;
    public Image[] images;
    List<int> price = new List<int>();

    [SerializeField] TextMeshProUGUI text;
    BlackSkinPrice blackSkinPrice;
    //public int NowIndex;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError($"{transform} : SelectManager Multiple");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        images = parent.GetComponentsInChildren<Image>();
        for (int i = 0; i < parent.transform.childCount - 1; i++)
        {
            price.Add(parent.transform.GetChild(i).GetComponent<SkinPrice>().price);
        }
    }

    private void OnEnable()
    {
        UpdateKae();
    }
    public void UpdateKae()
    {
        nowKae = PlayerPrefs.GetInt("KaeJewel", 0);
        text.text = $"보유 캐: {PlayerPrefs.GetInt("KaeJewel", 0)}";
    }

    public void UpdateBool()
    {
        blackSkinPrice = GameObject.FindObjectOfType<BlackSkinPrice>();
        for (int index = 0; index < parent.transform.childCount - 1; index++)
        {
            bool isBuy = (PlayerPrefs.GetString($"{index}", "사야댐") == "삼") ? true : false;
            if (isBuy)
            {
                parent.transform.GetChild(index).GetComponent<SkinPrice>().priceTxt.text = $"구매";
                if (PlayerPrefs.GetInt("ColorIndex", 0) == index)
                    parent.transform.GetChild(index).GetComponent<SkinPrice>().priceTxt.text = $"선택";
            }
            else
                parent.transform.GetChild(index).GetComponent<SkinPrice>().priceTxt.text
                 = $"{parent.transform.GetChild(index).GetComponent<SkinPrice>().price}캐";
        }
        bool blackBuy = (PlayerPrefs.GetString($"{parent.transform.childCount - 1}", "사야댐") == "삼") ? true : false;
        if (blackBuy)
        {
            blackSkinPrice.priceTxt.text = $"구매";
            if (PlayerPrefs.GetInt("ColorIndex", 0) == parent.transform.childCount - 1)
                blackSkinPrice.priceTxt.text = $"선택";
        }
        else
            blackSkinPrice.priceTxt.text
             = $"{blackSkinPrice.price}캐";
    }

    public bool IsBuy(int index)
    {
        if ((PlayerPrefs.GetString($"{index}", "사야댐") == "삼") ? true : false)
            return true;
        return false;
    }
}
