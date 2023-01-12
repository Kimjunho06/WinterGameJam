using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError($"{transform} : CameraManager Multiples");
            Destroy(gameObject);
        }

        cam.transform.rotation = Quaternion.Euler(0,0,0);
        cam.m_Lens.OrthographicSize = 12f;
    }

    [SerializeField] CinemachineVirtualCamera cam;
    float ranges= 0;

    public void ShackCam(float range, float duration)//흔들림
    {
        Invoke("StopShake", duration);
        ranges = range;
        InvokeRepeating("StartShake",0f,0.005f);
        Invoke("StopShake",duration);
    }

    void StartShake()
    {
        float cameraRotX = Random.value * ranges * 2 - ranges;
        float cameraRotY = Random.value * ranges * 2 - ranges;
        cam.transform.rotation = Quaternion.Euler(cameraRotX,cameraRotY,0);
        //cam.transform.rotation = Quaternion.Euler(0,0,0);
    }

    void StopShake()
    {
        CancelInvoke("StartShake");
        cam.transform.rotation = Quaternion.Euler(0,0,0);
    }

    public void ScaleCam(float changevalue = 0, float time = 0)//크기조정
    {
        StartCoroutine(CoScaleCam(changevalue,time));
    }
    IEnumerator CoScaleCam(float changevalue, float time)
    {
        if(time != 0)
        {
            float playTime = 0;
            while(playTime < time)
            {
                cam.m_Lens.OrthographicSize += (changevalue / time) * Time.deltaTime;
                playTime += Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            cam.m_Lens.OrthographicSize = changevalue;
            yield return null;   
        }
    }

    public void RotationCam(float changevalue = 0, float time = 0)//로테이션
    {
        StartCoroutine(CoRotationCam(changevalue, time));
    }

    IEnumerator CoRotationCam(float changevalue, float time)
    {
        if(time != 0)
        {
            float playTime = 0;
            while(playTime < time)
            {
                cam.m_Lens.Dutch += (changevalue / time) * Time.deltaTime;
                playTime += Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            cam.m_Lens.Dutch = changevalue;
            yield return null;   
        }
    }
}
