using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShowVoulmValue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    Scrollbar scrollbar;
    private void Awake()
    {
        scrollbar = GetComponent<Scrollbar>();
    }

    void Update()
    {
        text.text = (Mathf.Abs(Mathf.Round(scrollbar.value * 100))).ToString();
    }
}
