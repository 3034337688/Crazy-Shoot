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

    public event Action OnDeath;//�����¼��ļ�������,���ڻص�

    [Header("������Ч")]
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
        Debug.Log("ʵ�����˺��Ľӿ�");
        currentHealth -= damage;
        Debug.Log(currentHealth);
        
        if(currentHealth<=0)
        {
            Debug.Log("�����Ѿ�����");
            isDie = true;

            OnDeath?.Invoke();//������������¼��ʹ���
            
            Destroy(gameObject);
            DieEffective();



        }



    }
}
