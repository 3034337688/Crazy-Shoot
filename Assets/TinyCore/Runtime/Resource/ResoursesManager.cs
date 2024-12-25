
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using GameMei;

[DefaultExecutionOrder(-100)]
public class ResoursesManager : MonoSingle<ResoursesManager>//继承了父类的单例模式
{
    //public static ResoursesManager Instance;   
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("resourcem首先被实例化出来了");
    }

    public PopupText popupText;

    public T Load<T>(string assetName) where T:Object
    {
        T resource = Resources.Load<T>(assetName);

        return resource is GameObject ? Instantiate(resource) : resource;

    }

    //开启异步加载协程
    public void LoadAsync<T>(string assetName, UnityAction<T> callBack) where T:Object
    {
        StartCoroutine(LoadAsyncInternal(assetName, callBack));
    }

    private IEnumerator LoadAsyncInternal<T>(string assetName, UnityAction<T> callBack)where T:Object
    {
        ResourceRequest resourceRequest = Resources.LoadAsync<T>(assetName);
        yield return resourceRequest;

        if(resourceRequest.asset is GameObject)
        {
            callBack(Instantiate(resourceRequest.asset) as T);
        }
        else
        {
            callBack(resourceRequest.asset as T);
        }

    }

}
