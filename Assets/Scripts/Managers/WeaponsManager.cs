using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : Singleton<WeaponsManager>
{
    public WeaponBaseStatus _weaponBaseStatus = new WeaponBaseStatus();

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// 武器の認識IDとして使用
    /// </summary>
    public enum WeaponID
    {
        sampleWeapon, AR, SG, SMG
    }

}
