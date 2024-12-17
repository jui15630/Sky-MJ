using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : BaseWeapon
{
    public override WeaponsManager.WeaponID GetWeaponID()
    {
        return WeaponsManager.WeaponID.SMG;
    }
}