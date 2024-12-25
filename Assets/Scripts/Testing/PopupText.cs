using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupText : MonoBehaviour
{

	public void Create(Vector3 position,int damageAmount,bool boomHit)
    {
		PopupText text = Instantiate(ResoursesManager.Instance.popupText, position, Quaternion.identity);
		text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y, -1);
		text.SetUp(damageAmount, boomHit);
	}

	private const float DisapperTimeMax=1f;
	private float _disapperTimer;
	private TextMeshPro _textMeshPro;
	private Color _textColor;
	
	[Header("move up")]
	[SerializeField]private float speed;
	public Vector3 moveUpVector=new Vector3(0,1,0);
	public Vector3 moveDownVector = new Vector3(-0.7f, 1, 0);

	// Awake is called when the script instance is being loaded.

	public Color normalColor;
	public Color boomColor;
	protected void Awake()
	{
		_textMeshPro=GetComponent<TextMeshPro>();

	}

	public void SetUp(int damageAmount,bool isBoomHit)
    {
		_textMeshPro.text = damageAmount.ToString();

		if(isBoomHit)
        {
			_textColor = boomColor;
			_textMeshPro.fontSize = 5;
        }
        else
        {
			_textMeshPro.fontSize = 4;
			_textColor = normalColor;
        }
		_textMeshPro.color = _textColor;
		_disapperTimer = DisapperTimeMax;
    }
	protected void Update()
	{

		if(_disapperTimer>0.5f*DisapperTimeMax)
        {

			//text move up
			transform.position += Vector3.up * Time.deltaTime * speed;
			moveUpVector += moveUpVector * (Time.deltaTime * speed);
			transform.localScale += Vector3.one * Time.deltaTime;

		}
		else
        {
			//text move down
			transform.position -= Vector3.up * Time.deltaTime * speed;
			moveDownVector += moveDownVector * (Time.deltaTime * speed);
		}



		
		_disapperTimer-=Time.deltaTime;
		if(_disapperTimer<0f)
		{
			_textColor.a -= 3 * Time.deltaTime;
			_textMeshPro.color = _textColor;
			if(_textColor.a<0f)
            {
				Destroy(this.gameObject, 1.0f);
            }
		}
		
	}


}
