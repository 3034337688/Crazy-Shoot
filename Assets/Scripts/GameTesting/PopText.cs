using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopText : MonoBehaviour
{
    [SerializeField] private float speed;
    private TextMeshPro _text;
    [SerializeField] private float disapperTime;


    [SerializeField] private Vector3 downDirection;
    [SerializeField] private Vector3 upDirection;
    private float _time=0f;
    private Color _color;
    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
        _color = _text.color;
    }
    private void Update()
    {
        

        _time += Time.deltaTime;
        if(_time<=disapperTime*0.5f)
        {
            Debug.Log("进入上升阶段");
            this.transform.position += Time.deltaTime * upDirection * speed;
            _color.a -= Time.deltaTime;
            _text.color = _color;


            _text.transform.localScale -= Vector3.one * Time.deltaTime*0.5f;
            
        }
        if(_time > disapperTime * 0.5f&&_time<disapperTime)
        {
            this.transform.position += Time.deltaTime * downDirection * 2f;
            Debug.Log("进入下降阶段");
            _color.a -= Time.deltaTime * speed;
            _text.color = _color;
            //_text.transform.localScale -= downDirection * Time.deltaTime;
            
        }

        Destroy(this.gameObject, 2f);

    }
}
