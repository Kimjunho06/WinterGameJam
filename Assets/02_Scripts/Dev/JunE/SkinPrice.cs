using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SkinPrice : MonoBehaviour
{
    public int price = 200;
    public TextMeshProUGUI priceTxt;
    [SerializeField] int index;
    //private bool isBuy = false;

    private void OnEnable()
    {
        SelectManager.Instance.UpdateBool();
    }

    public void OnClickImage()
    {
        if(SelectManager.Instance.IsBuy(index))
        {
            PlayerPrefs.SetInt("ColorIndex",index);
            SelectManager.Instance.UpdateBool();
        }
        else
        {
            if(PlayerPrefs.GetInt("KaeJewel",0) >= 200)
            {
                PlayerPrefs.SetInt("KaeJewel",PlayerPrefs.GetInt("KaeJewel",0) - 200);
                SelectManager.Instance.UpdateKae();
                PlayerPrefs.SetString($"{index}","삼");
                SelectManager.Instance.UpdateBool();
            }
            else
                Debug.Log("캐가 부족합니다");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("리셋~~~~~~");
            PlayerPrefs.SetString($"{index}","사야댐");
            SelectManager.Instance.UpdateBool();
        }
    }
}
