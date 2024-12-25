using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int Vitality { get; set; }
    public int Agility { get; set; }

    public int Accuracy { get; set; }

    public WeaponData weaponData { get; set; }

    public float AimOffest => 1f / Accuracy * 8.0f;
    public float MoveSpeed => 2f * Agility / 30.0f;
    public float Health => Vitality;

    public PlayerData()
    {
        Vitality = 40;
        Agility = 80;
        Accuracy = 50;

        weaponData = new WeaponData(5, 20, 5, 7);//ʵ����
    }

    //���������ݽṹ�ķ�װ
    public int Damage
    {
        get => weaponData.Damage;
        set => weaponData.Damage = value;
    }

    public int ClipSize
    {
        get => weaponData.ClipSize;
        set => weaponData.ClipSize = value;
    }

    public int FireRate
    {
        get => weaponData.FireRate;
        set => weaponData.FireRate = value;
    }
    public float ReloadTime
    {
        get => weaponData.ReloadTime;
        set
        {
            if (value < 0) Debug.Log("װ��ʱ�䲻��С��0");
            else
            {
                weaponData.ReloadTime = value;
            }
        }
    }
}
