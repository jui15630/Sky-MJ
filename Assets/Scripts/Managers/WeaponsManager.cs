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
    /// ����̔F��ID�Ƃ��Ďg�p
    /// </summary>
    public enum WeaponID
    {
        sampleWeapon, AR, SG, SMG
    }

}
