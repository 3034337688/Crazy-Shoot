using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameMei;
using System;

public class GameLoading : MonoBehaviour
{
    //主要用于更新，加载场景资源等，作为游戏的入口场景
    void Awake()
    {
        DontDestroyOnLoad(this);

        SceneManager.LoadScene("Main");

        SceneManager.activeSceneChanged += OnActiveSceneChanged;

    }
    private void OnActiveSceneChanged(Scene previousActiveScene,Scene newActiveScene)
    {
        Debug.Log("已经切换了场景"+newActiveScene.name);
        /*switch (newActiveScene.name)
        {
            case "Game":
                SoundManager.Instance.PlayMusic("Main");
                Debug.Log("播放了Main音效");
                break;
            case "Main":
                SoundManager.Instance.PlayMusic("Menu");
                break;
            default:
                Debug.Log("名字无效");
                break;


        }*/
        

        SoundManager.Instance.PlayMusic(newActiveScene.name);
        if(newActiveScene.name=="Main")
        {
            Debug.Log("可以播放菜单音乐了");
            SoundManager.Instance.PlayMusic(newActiveScene.name);
        }

        //调用UI管理器打开界面
        switch(newActiveScene.name)
        {
            case "Main":
                Debug.Log("加载了Main场景的UI通过UI管理器");
                UIManager.Instance.Open("MeauForm");
                break;
            case "Game":
                Debug.Log("尝试加载Game场景的UI通过UI管理器");
                if (UIManager.Instance != null)
                {
                    try
                    {
                        UIManager.Instance.Open("PlayerHealthMenu");
                        Debug.Log("已调用打开PlayerHealthMenu的方法");
                        Debug.Log("UI路径: Assets/Prefabs/UI/PlayerHealthMenu.prefab");
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"打开PlayerHealthMenu时发生错误: {e.Message}");
                    }
                }
                else
                {
                    Debug.LogError("UIManager实例为空，请确保UIManager已正确初始化");
                }
                break;
            default:
                Debug.Log("UI管理器没有");
                break;

        }

    }


    [RuntimeInitializeOnLoadMethod]
    public static void OnGameLoading()
    {
        if(SceneManager.GetActiveScene().name=="GameLoading")
        {
            return;
        }

        SceneManager.LoadScene("GameLoading");
    }

}
