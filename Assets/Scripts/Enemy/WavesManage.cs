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

    [Header("��������")]
    public int count;

    //�������Ԥ�����ʱ�򣬻ᶪʧ�볡���ϵ���������ã����ʱ����һЩ��ķ������Ұ��ϼ���

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

            //������������
            beetle.GetComponent<Enemy>().OnDeath += calcuBeetleCounts;

            yield return new WaitForSeconds(0.5f);

        }
        yield return new WaitForSeconds(1);


        

    }

    void calcuBeetleCounts()
    {
        count++;
        Debug.Log("������" + count + "����");


        if (count == MaxBeetleCount)
        {
            StartCoroutine(NextBeetleCorcutine());
            enemyWaves++;
            Debug.Log("������һ��");
            count = 0;

            OnWhatWavas?.Invoke();
        }


    }


}
