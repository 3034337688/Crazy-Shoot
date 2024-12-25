using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ShowWava : MonoBehaviour
{


    [Header("状态机获取")]
    private TextMeshProUGUI _showGameStartText;

    [SerializeField] private WavesManage _wavesManage;

    
    //定义文本颜色
    private Color _textColor;



    //消失持续时间
    //[SerializeField] private float disapperTime;
    private void Start()
    {
       
        _showGameStartText = GetComponent<TextMeshProUGUI>();
        if (_wavesManage == null) Debug.Log("_wavesManage脚本为空");
        _textColor = _showGameStartText.color;
        if (_showGameStartText == null) Debug.Log("没有拿到UI面板");
        _showGameStartText.text = "Game start!!!!";
        Invoke("DisapperText", 1f);
    
    }

    //怪物来袭文本消失
    void DisapperText()
    {
        StartCoroutine(AColorCourition(2f));
        //_showGameStartText.text = "";

        

    }


    /// <summary>
    /// 不用updata处理，直接在携程中处理颜色变化
    /// </summary>
    /// <param name="disapperTime"></param>
    /// <returns></returns>
    IEnumerator AColorCourition(float disapperTime)
    {
        float nowTime=0f;
        nowTime += Time.deltaTime;
        while(nowTime<disapperTime)
        {
            float a = Mathf.Lerp(_textColor.a, 0, Time.deltaTime*5);
            if (a < 0.1) a = 0;
            _textColor = new Vector4(_textColor.r, _textColor.g, _textColor.b, a);
            _showGameStartText.color = _textColor;    //注意我们修改color，最后需要赋值给到组件
            //Debug.Log(_textColor.a);
            yield return null;
        }

    }

    private void Update()
    {
        _wavesManage.OnWhatWavas += ShowWhatWavas;
    }
    public void ShowWhatWavas()
    {
        _showGameStartText.text = _wavesManage.enemyWaves.ToString()+"  "+"waves";
        
        _textColor = new Vector4(_textColor.r, _textColor.g, _textColor.b, 1);
        _showGameStartText.color = _textColor;

        //StartCoroutine(FlashText(3));
    }


    //倒计时闪烁效果
/*    IEnumerator FlashText(int flashNumber)
    {
        for (int i = 0; i < flashNumber; i++)
        {
            _showGameStartText.color = new Vector4(_showGameStartText.color.r, _showGameStartText.color.g, _showGameStartText.color.b, 1);
            _showGameStartText.text = "3";

            yield return new WaitForSeconds(1f);
            _showGameStartText.color = new Vector4(_showGameStartText.color.r, _showGameStartText.color.g, _showGameStartText.color.b, 0);
            _showGameStartText.text = "2";

            yield return new WaitForSeconds(1f);
            _showGameStartText.color = new Vector4(_showGameStartText.color.r, _showGameStartText.color.g, _showGameStartText.color.b, 1);
            _showGameStartText.text = "1";
        }
    }*/




}
