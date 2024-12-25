using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameMei
{
    public class UGuiForm : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        private bool isVisible;
        public Transform cachedTransform;

        private const float DurationTime = 0.3f;

        public string Name   //封装UI对象的名字
        {
            get => gameObject.name;
            set => gameObject.name = value;
        }


        public bool Visible  //对UI可见性的封装
        {
            get => isVisible;
            set
            {
                if(isVisible==value)
                {
                    return;
                }
                isVisible = value;
                gameObject.SetActive(value);
            }
        }

        public virtual void OnInit()
        {
            if(cachedTransform==null)
            {
                cachedTransform = transform;
            }


            canvasGroup = gameObject.GetOrAddComponent<CanvasGroup>();
            gameObject.GetOrAddComponent<GraphicRaycaster>();

            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.localScale = Vector3.one;

            //translata语言




        }
        public virtual void OnOpen() 
        {
            Visible = true;
            canvasGroup.alpha = 0;
            Debug.Log("UI管理器的UI界面打开");

            StartCoroutine(canvasGroup.FadeToAlpha(1f,DurationTime));
        }
        public virtual void OnUpdata() { }
        public virtual void OnClose() { Visible = false; }

        public void PlaySound()
        {

        }


    }
}
