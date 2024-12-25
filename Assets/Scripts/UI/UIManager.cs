using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameMei
{
    public class UIManager : MonoSingle<UIManager>
    {
        private readonly Dictionary<string, UGuiForm> allOpenedForm = new();
        [SerializeField] private Transform formParent;//父节点的位置

        public void Init()
        {
            //处理层级相关的
        }


        //UI管理器
        public void Open(string formName,object userData=null)
        {
            if(allOpenedForm.TryGetValue(formName,out UGuiForm openedForm))
            {
                openedForm.OnOpen();
                return;
            }

            ResoursesManager.Instance.LoadAsync<GameObject>($"Form /{ formName}", openedForm => 
            {
                openedForm.transform.SetParent(formParent);

                UGuiForm _uiform = openedForm.GetComponent<UGuiForm>();
                _uiform.OnInit();
                _uiform.OnOpen();

                allOpenedForm.Add(formName, _uiform);

            });
        }


        //UI管理器界面关闭相关
        public void Close(string formName,bool isDestroy=false)
        {
            if (!allOpenedForm.TryGetValue(formName, out UGuiForm openedForm))
            {
                return;
            }

            openedForm.OnClose();

            if(!isDestroy)
            {
                return;
            }

            allOpenedForm.Remove(formName);
        }

        private void Update()
        {
            foreach (KeyValuePair<string,UGuiForm> keyValuePair in allOpenedForm)
            {
                keyValuePair.Value.OnUpdata();

            }
        }

        public void CloseAllUIForms()
        {
        }

    }
}


