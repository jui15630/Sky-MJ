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
        /// ����̃g�����X�t�H�[���f�[�^
        /// </summary>
        /// <returns></returns>
        abstract Transform GetWeaponTransform();

        /// <summary>
        /// �����������ɌĂяo���Ȃ�g��
        /// </summary>
        /// <param name="battleID"></param>
        /// <param name="spawnPos"></param>
        abstract void InitSetting(int battleID, Vector3 spawnPos);

        /// <summary>
        /// ����̎���ID
        /// </summary>
        /// <returns></returns>
        abstract WeaponsManager.WeaponID GetWeaponID();
    }
}
