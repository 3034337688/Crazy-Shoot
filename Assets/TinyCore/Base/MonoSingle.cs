using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMei
{
    //�����һ������ģʽ�Ĺ����ߣ�����������Դ���������������������ܴ��ڽű�ִ�е��Ⱥ�˳��
    //�����ù�����ʵ������ͬ��start��awakeȥ����ʱ�䣬��Ϊ���Ǽ�����ϱ�ǩ���ǲ������Զ���ű���ִ��˳��
    //�����ǽű�����˳��ִ�У�����ʵ������ʱ��̫����

    public class MonoSingle<T> : MonoBehaviour where T:MonoSingle<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if(Instance==null)
            {
                Instance = this as T;
                Debug.Log("�õ�����Ϸ����");
            }
            else
            {
                Debug.Log("��ȡ����������ģʽ����");
            }
            
        }
        protected virtual void Start()
        {
            if (Instance == null)
            {
                Instance = this as T;
                Debug.Log("�õ�����Ϸ����");
            }
            else
            {
                Debug.Log("��ȡ����������ģʽ����");
            }

        }

    }
}
