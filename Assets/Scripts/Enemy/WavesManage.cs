using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WavesManage : MonoBehaviour
{


    //[SerializeField] private LiveDamage _liveDamage;
    [SerializeField] private Transform[] showBeetlePosition;
    public int MaxBeetleCount;
    [SerializeField] private GameObject beetlePrefab;
    [SerializeField] public int enemyWaves;

    [Header("怪物死亡")]
    public int count;

    //这个就是预制体的时候，会丢失与场景上的物体的引用，这个时候用一些别的方法查找绑定上即可

    public event Action OnWhatWavas;

    private void Start()
    {

        StartCoroutine(NextBeetleCorcutine());


    }

    IEnumerator NextBeetleCorcutine()
    {

        int beetleCounts = UnityEngine.Random.Range(1,MaxBeetleCount);
        for(int i=0;i<MaxBeetleCount;i++)
        {
            Vector3 pos = new Vector3(showBeetlePosition[UnityEngine.Random.Range(1, showBeetlePosition.Length)].position.x, showBeetlePosition[UnityEngine.Random.Range(1, showBeetlePosition.Length)].position.y, -1);
            GameObject beetle=Instantiate(beetlePrefab, pos, Quaternion.identity);

            //监听怪物死亡
            beetle.GetComponent<Enemy>().OnDeath += calcuBeetleCounts;

            yield return new WaitForSeconds(0.5f);

        }
        yield return new WaitForSeconds(1);


        

    }

    void calcuBeetleCounts()
    {
        count++;
        Debug.Log("死亡了" + count + "怪物");


        if (count == MaxBeetleCount)
        {
            StartCoroutine(NextBeetleCorcutine());
            enemyWaves++;
            Debug.Log("开启下一波");
            count = 0;

            OnWhatWavas?.Invoke();
        }


    }


}
