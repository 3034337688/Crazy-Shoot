using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ShowWava : MonoBehaviour
{


    [Header("״̬����ȡ")]
    private TextMeshProUGUI _showGameStartText;

    [SerializeField] private WavesManage _wavesManage;

    
    //�����ı���ɫ
    private Color _textColor;



    //��ʧ����ʱ��
    //[SerializeField] private float disapperTime;
    private void Start()
    {
       
        _showGameStartText = GetComponent<TextMeshProUGUI>();
        if (_wavesManage == null) Debug.Log("_wavesManage�ű�Ϊ��");
        _textColor = _showGameStartText.color;
        if (_showGameStartText == null) Debug.Log("û���õ�UI���");
        _showGameStartText.text = "Game start!!!!";
        Invoke("DisapperText", 1f);
    
    }

    //������Ϯ�ı���ʧ
    void DisapperText()
    {
        StartCoroutine(AColorCourition(2f));
        //_showGameStartText.text = "";

        

    }


    /// <summary>
    /// ����updata����ֱ����Я���д�����ɫ�仯
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
            _showGameStartText.color = _textColor;    //ע�������޸�color�������Ҫ��ֵ�������
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


    //����ʱ��˸Ч��
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
