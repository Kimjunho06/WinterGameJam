using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    public Scrollbar _backGroundBgmScroll;
    public Scrollbar _interacSoundScroll;

    public List<AudioSource> _backGroundBgm;
    public List<AudioSource> _interacSoundList;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log($"{transform} : SoundManager Multiple");
            Destroy(gameObject);
        }
        _backGroundBgmScroll.value = PlayerPrefs.GetFloat("BackBgmSave");
        _interacSoundScroll.value = PlayerPrefs.GetFloat("InteracSoundSave");
    }

    private void Update()
    {
        ChangeBgm();
        ChangeInteracSound();
    }

    private void ChangeBgm()
    {
        for (int i = 0; i < _backGroundBgm.Count; i++)
        {
            _backGroundBgm[i].volume = _backGroundBgmScroll.value;
        }

        PlayerPrefs.SetFloat("BackBgmSave", _backGroundBgmScroll.value);
    }

    private void ChangeInteracSound()
    {
        for (int i = 0; i < _interacSoundList.Count; i++)
        {
            _interacSoundList[i].volume = _interacSoundScroll.value;
        }

        PlayerPrefs.SetFloat("InteracSoundSave", _interacSoundScroll.value);
    }

    public void SoundStop()
    {
        for(int i = 0; i < _backGroundBgm.Count; i++)
        {
            _backGroundBgm[i].Pause();
        }
        for(int i = 0; i < _interacSoundList.Count; i++)
        {
            _interacSoundList[i].Pause();
        }
    }

    public void SoundContinue()
    {
        for(int i = 0; i < _backGroundBgm.Count; i++)
        {
            _backGroundBgm[i].UnPause();
        }
        for(int i = 0; i < _interacSoundList.Count; i++)
        {
            _interacSoundList[i].UnPause();
        }
    }
}
