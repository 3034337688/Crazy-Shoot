using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[System.Serializable]
public struct CameraBound  //����߽�����
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

}

public class CameraTarget : MonoBehaviour
{

    [SerializeField]private Transform _player;
    public float offest;
    [SerializeField] private float smoothTime;
    private Vector3 velocity = Vector3.zero; // ���� SmoothDamp ����ʱ����
    private Vector3 targetPlayer;
    public CameraBound cameraBound;

    
    

    void Start()
    {
        if (_player == null) Debug.Log("ȱʧplayer");



    }

    //�����������ʱ��ע�������Z����ֵ
    private void LateUpdate()
    {

        targetPlayer = new Vector3(targetPlayer.x, targetPlayer.y, -10);
        
        transform.position = Vector3.SmoothDamp(this.transform.position, targetPlayer, ref velocity, smoothTime);
        targetPlayer.x = Mathf.Clamp(_player.position.x, cameraBound.xMin, cameraBound.xMax);
        targetPlayer.y = Mathf.Clamp(_player.position.y, cameraBound.yMin, cameraBound.yMax);
    }
}
