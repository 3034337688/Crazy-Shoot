using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDie : LiveDamage
{
    public override void TakeDamage(float damage)
    {


      
        Debug.Log("木箱已经死亡");
        OnDeath += () => { Debug.Log("木箱注册的死亡事件成功"); };
            


        base.TakeDamage(damage);
    }

}
