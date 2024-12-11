using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponBaseStatus
{
    [SerializeField] private WeaponStatusAttribute[] weaponStatus;

    /// <summary>
    /// ����̏����e���擾�p
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
    /// ����̍ő及���e���擾�p
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
    /// �����[�h�ŕ�[�����e���̐��擾�p
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
    /// �����ł���}�K�W���̍ő吔�̎擾�p
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
    /// ���݂̃}�K�W�����̎擾�p
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
    ///  �U���͎擾�p
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
    /// ����̘A�˗͂̎擾�p
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
    /// �����sy�዗���̎擾�p
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
