using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponBaseStatus
{
    [SerializeField] private WeaponStatusAttribute[] weaponStatus;

    /// <summary>
    ///  UŒ‚—Íæ“¾—p
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
}
