using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseWeapon;

public abstract class BaseWeapon : MonoBehaviour, IBaseWeapon
{
    private bool attackStart;
    private bool isAttack;
    private bool hitAttack;

    public abstract WeaponsManager.WeaponID GetWeaponID();
    public Transform GetWeaponTransform()
    {
        return transform;
    }

    public void InitSetting(int battleID, Vector3 spawnPos)
    {

    }

    public interface IBaseWeapon
    {
        /// <summary>
        /// 武器のトランスフォームデータ
        /// </summary>
        /// <returns></returns>
        abstract Transform GetWeaponTransform();

        /// <summary>
        /// 初期生成時に呼び出すなら使う
        /// </summary>
        /// <param name="battleID"></param>
        /// <param name="spawnPos"></param>
        abstract void InitSetting(int battleID, Vector3 spawnPos);

        /// <summary>
        /// 武器の識別ID
        /// </summary>
        /// <returns></returns>
        abstract WeaponsManager.WeaponID GetWeaponID();
    }
}
