using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pattern : MonoBehaviour
{
    public Pattern1 _pattern1;
    public Pattern2 _pattern2;
    public Pattern3 _pattern3;
    public Pattern4 _pattern4;
    public Pattern5 _pattern5;
    public Pattern6 _pattern6;
    public Pattern7 _pattern7;
    public Pattern8 _pattern8;

    public GameObject _gameEndPanel;

    bool _isOne;

    private void Awake()
    {
        _isOne = false;
    }

    private void Start()
    {
        PatternProcess();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !_isOne)
        {
            _isOne = true;
        }
    }

    private void PatternProcess()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(6f);
        seq.AppendCallback(() => _pattern1.Pattern1Process());
        seq.AppendInterval(7.5f);
        seq.AppendCallback(() => _pattern2.Pattern2Process());
        seq.AppendInterval(15.5f);
        seq.AppendCallback(() => _pattern3.Pattern3Process());
        seq.AppendInterval(7.5f);
        seq.AppendCallback(() => _pattern4.Pattern4Process()); 
        seq.AppendInterval(14.2f);
        seq.AppendCallback(() => _pattern5.Pattern5Process());
        seq.AppendInterval(17f);
        seq.AppendCallback(() => _pattern6.Pattern6Process());
        seq.AppendInterval(19.55f);
        seq.AppendCallback(() => _pattern7.Pattern7Process());
        seq.AppendInterval(30f);
        seq.AppendCallback(() => _pattern8.Pattern8Process());
        seq.AppendCallback(() => {
            _gameEndPanel.SetActive(true);
        });
    }
}
