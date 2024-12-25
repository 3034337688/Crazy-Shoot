using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LiveDamage : MonoBehaviour,IDamage
{
    //[SerializeField]private float damageNumber;
    [SerializeField]protected bool isDie;
    protected float currentHealth;
    public float maxHealth;

    public event Action OnDeath;//死亡事件的监听函数,用于回调

    [Header("死亡特效")]
    public GameObject _dieEffectPrefabs;


    public virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void DieEffective()
    {
        GameObject dieEffect=Instantiate(_dieEffectPrefabs, transform.position, Quaternion.identity);
        Destroy(dieEffect, 0.5f);
    }


    public virtual void TakeDamage(float damage)
    {
        Debug.Log("实现了伤害的接口");
        currentHealth -= damage;
        Debug.Log(currentHealth);
        
        if(currentHealth<=0)
        {
            Debug.Log("物体已经死亡");
            isDie = true;

            OnDeath?.Invoke();//如果触发订阅事件就触发
            
            Destroy(gameObject);
            DieEffective();



        }



    }
}
