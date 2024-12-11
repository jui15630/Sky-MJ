using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponBaseStatus
{
    [SerializeField] private WeaponStatusAttribute[] weaponStatus;

    /// <summary>
    /// 武器の初期弾数取得用
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetNumberBullet(WeaponsManager.WeaponID id)
    {
        foreach(var status in weaponStatus)
        {
            if (id == status.WeaponID)
            {
                return status._numberBullet;
            }
        }
        return 0;
    }

    /// <summary>
    /// 武器の最大所持弾数取得用
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetMaxBullet(WeaponsManager.WeaponID id) 
    {
        foreach (var status in weaponStatus)
        {
            if (id == status.WeaponID)
            {
                return status._maxBullets;
            }
        }
        return 0;
    }

    /// <summary>
    /// リロードで補充される弾数の数取得用
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetMagazineCapacity(WeaponsManager.WeaponID id)
    {
        foreach (var status in weaponStatus)
        {
            if (id == status.WeaponID)
            {
                return status._magazinCapacity;
            }
        }
        return 0;
    }

    /// <summary>
    /// 所持できるマガジンの最大数の取得用
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetMaxMagazine(WeaponsManager.WeaponID id)
    {
        foreach (var status in weaponStatus)
        {
            if(id == status.WeaponID)
            {
                return status._maxMagazine;
            }
        }
        return 0;
    }


    /// <summary>
    /// 現在のマガジン数の取得用
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetCurrentMagazine(WeaponsManager.WeaponID id)
    {
        foreach (var status in weaponStatus)
        {
            if(id == status.WeaponID)
            {
                return status._currentMagazin;
            }
        }
        return 0;
    }

    /// <summary>
    ///  攻撃力取得用
    /// </summary>
    /// <param attack ="id"></param>
    /// <returns></returns>
    public int GetAttack(WeaponsManager.WeaponID id)
    {
        foreach (var status  in weaponStatus)
        {
            if(id == status.WeaponID)
            {
                return status._attack;
            }
        }
        return 0;
    }

    /// <summary>
    /// 武器の連射力の取得用
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetRapidFire(WeaponsManager.WeaponID id)
    {
        foreach (var status in weaponStatus)
        {
            if (id == status.WeaponID)
            {
                return status._rapidFire;
            }
        }
        return 0;
    }

    /// <summary>
    /// 武器のsy低距離の取得用
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public float GetRange(WeaponsManager.WeaponID id)
    {
        foreach(var status in weaponStatus)
        {
            if(id == status.WeaponID)
            {
                return status._range;
            }
        }
        return 0f;
    }
}
