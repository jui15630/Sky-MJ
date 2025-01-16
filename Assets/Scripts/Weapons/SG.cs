using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG : BaseWeapon
{
    public override WeaponsManager.WeaponID GetWeaponID()
    {
        return WeaponsManager.WeaponID.SG;
    }
}