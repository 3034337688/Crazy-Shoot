using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData
{
    public int Damage { get; set; }
    public int ClipSize { get; set; }
    public int FireRate { get; set; }
    public float ReloadTime { get; set; }


    public WeaponData(int damage,int clipSize,int fireRate,float reloadTime)
    {
        Damage = damage;
        ClipSize = clipSize;
        FireRate = fireRate;
        ReloadTime = reloadTime;
    }

}
