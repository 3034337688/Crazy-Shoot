using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class PlayerContraller : MonoBehaviour
{
	[Header("player移动")]
	public float _moveSpeed=12.0f;
	private bool _isPlayerWalk;
	private Vector2 _moveDirection;
	private Rigidbody2D _rigibody2d;
	private Animator _playerAnmation;

	[Header("player转向")]
	private Camera _mainCamera;
	public float _offestAngle;

	[Header("PlayerGun的引用")]
	private PlayerGun _playerGun;

	private void Awake()
    {
		_rigibody2d = GetComponent<Rigidbody2D>();
		_playerAnmation = GetComponent<Animator>();
		_playerGun = GetComponent<PlayerGun>();
        if (_playerGun == null) Debug.LogError("not find PlayerGun");

		_mainCamera = Camera.main;
		if (_mainCamera == null) Debug.LogError("not find camera");
	}

	



    void Update()
	{

		//player移动
		_moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		_moveDirection=_moveDirection*_moveSpeed;
		if (Mathf.Abs(_moveDirection.x) > 0 || Mathf.Abs(_moveDirection.y) > 0) _isPlayerWalk = true;
        else
        {
			_isPlayerWalk = false;
        }
		_playerAnmation.SetBool(AnimatorHash.isPlayerWalk, _isPlayerWalk);


		//转向
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 direction = mousePosition - this.transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


		this.transform.rotation = Quaternion.Euler(0, 0, angle + _offestAngle);//使用Eular控制每个轴的旋转


		//控制模式，单发，连发
		if(Input.GetMouseButton(0))
        {
			_playerGun.GunOnTriggerHold();

        }
		if(Input.GetMouseButtonUp(0))
        {
			_playerGun.GunOnTriggerRelease();
        }
		if(Input.GetKeyDown(KeyCode.R))
        {
			_playerGun.GunReload();
        }


	}
	
	void FixedUpdate()
	{
		_rigibody2d.AddForce(_moveDirection,ForceMode2D.Impulse);
	}
	
	

}
