using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseWeapon;

public class sampleWeapon : IBaseWeapon
{
    public override WeaponsManager.WeaponID GetWeaponID()
    {
        return WeaponsManager.WeaponID.sampleWeapon;
    }
}
