using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleWeapon : BaseWeapon
{
    public override WeaponsManager.WeaponID GetWeaponID()
    {
        return WeaponsManager.WeaponID.sampleWeapon;
    }
}
