using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDie : LiveDamage
{
    public override void TakeDamage(float damage)
    {


      
        Debug.Log("ľ���Ѿ�����");
        OnDeath += () => { Debug.Log("ľ��ע��������¼��ɹ�"); };
            


        base.TakeDamage(damage);
    }

}
