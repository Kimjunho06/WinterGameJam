using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance = null;
    public int maxStage = 0;
    public int stageIndex = 0;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance =this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Change(int nowIndex, Color color)
    {
        stageIndex = nowIndex;
        StartCoroutine(ChageScene(nowIndex, color));
    }
    
    IEnumerator ChageScene(int nowIndex, Color color)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nowIndex);
        while (!op.isDone)
        {
            yield return null;
        }
        SpriteRenderer player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        player.color = color;
        if(color == Color.black)
        {
            player.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
