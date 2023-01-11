using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaeSpawnManager : MonoBehaviour
{
    public static KaeSpawnManager Instance;
    [SerializeField] GameObject Kae;
    [SerializeField] float xIndex;
    [SerializeField] float yIndex;
    [SerializeField] int maxKae;
    [SerializeField] float startDelay;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError($"{transform} : KaeSpawnManger Multiple");
            Destroy(gameObject);
        } 
    }

    private void Start()
    {
        StartCoroutine(StartCreateKae());
    }
    public void Spawn()
    {
        Vector2 randomPos = new Vector2(Random.Range(-xIndex,xIndex),Random.Range(-yIndex,yIndex));
        PoolManager.Instance.Pop(Kae,randomPos,Quaternion.identity);
    }

    IEnumerator StartCreateKae()
    {
        yield return new WaitForSeconds(startDelay);
        for(int i = 0; i < maxKae; i++)
        {
            Spawn();
        }
    }
}
