using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameMei;
using System;

public class GameLoading : MonoBehaviour
{
    //��Ҫ���ڸ��£����س�����Դ�ȣ���Ϊ��Ϸ����ڳ���
    void Awake()
    {
        DontDestroyOnLoad(this);

        SceneManager.LoadScene("Main");

        SceneManager.activeSceneChanged += OnActiveSceneChanged;

    }
    private void OnActiveSceneChanged(Scene previousActiveScene,Scene newActiveScene)
    {
        Debug.Log("�Ѿ��л��˳���"+newActiveScene.name);
        /*switch (newActiveScene.name)
        {
            case "Game":
                SoundManager.Instance.PlayMusic("Main");
                Debug.Log("������Main��Ч");
                break;
            case "Main":
                SoundManager.Instance.PlayMusic("Menu");
                break;
            default:
                Debug.Log("������Ч");
                break;


        }*/
        

        SoundManager.Instance.PlayMusic(newActiveScene.name);
        if(newActiveScene.name=="Main")
        {
            Debug.Log("���Բ��Ų˵�������");
            SoundManager.Instance.PlayMusic(newActiveScene.name);
        }

        //����UI�������򿪽���
        switch(newActiveScene.name)
        {
            case "Main":
                Debug.Log("������Main������UIͨ��UI������");
                UIManager.Instance.Open("MeauForm");
                break;
            case "Game":
                Debug.Log("���Լ���Game������UIͨ��UI������");
                if (UIManager.Instance != null)
                {
                    try
                    {
                        UIManager.Instance.Open("PlayerHealthMenu");
                        Debug.Log("�ѵ��ô�PlayerHealthMenu�ķ���");
                        Debug.Log("UI·��: Assets/Prefabs/UI/PlayerHealthMenu.prefab");
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"��PlayerHealthMenuʱ��������: {e.Message}");
                    }
                }
                else
                {
                    Debug.LogError("UIManagerʵ��Ϊ�գ���ȷ��UIManager����ȷ��ʼ��");
                }
                break;
            default:
                Debug.Log("UI������û��");
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
