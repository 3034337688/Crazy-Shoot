using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMei
{
    //这个是一个单例模式的管理鸡肋，但是我们资源管理器和声音管理器可能存在脚本执行的先后顺序
    //我们用过两个实例化不同的start和awake去区分时间，因为我们即便加上标签还是不可以自定义脚本的执行顺序
    //或者是脚本按照顺序执行，但是实例化的时间太短了

    public class MonoSingle<T> : MonoBehaviour where T:MonoSingle<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if(Instance==null)
            {
                Instance = this as T;
                Debug.Log("得到了游戏对象");
            }
            else
            {
                Debug.Log("获取了两个单例模式的类");
            }
            
        }
        protected virtual void Start()
        {
            if (Instance == null)
            {
                Instance = this as T;
                Debug.Log("得到了游戏对象");
            }
            else
            {
                Debug.Log("获取了两个单例模式的类");
            }

        }

    }
}
