using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowDamage : MonoBehaviour
{
    [SerializeField] private GameObject _damageUI;
    [SerializeField] private Transform _player;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = new Vector3(_player.transform.position.x, _player.transform.position.y, -1);
            Instantiate(_damageUI,pos,Quaternion.identity);

        }

    }

}
