using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[System.Serializable]
public struct CameraBound  //相机边界限制
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
    private Vector3 velocity = Vector3.zero; // 用于 SmoothDamp 的临时变量
    private Vector3 targetPlayer;
    public CameraBound cameraBound;

    
    

    void Start()
    {
        if (_player == null) Debug.Log("缺失player");



    }

    //这个相机跟随的时候注意相机的Z轴数值
    private void LateUpdate()
    {

        targetPlayer = new Vector3(targetPlayer.x, targetPlayer.y, -10);
        
        transform.position = Vector3.SmoothDamp(this.transform.position, targetPlayer, ref velocity, smoothTime);
        targetPlayer.x = Mathf.Clamp(_player.position.x, cameraBound.xMin, cameraBound.xMax);
        targetPlayer.y = Mathf.Clamp(_player.position.y, cameraBound.yMin, cameraBound.yMax);
    }
}
