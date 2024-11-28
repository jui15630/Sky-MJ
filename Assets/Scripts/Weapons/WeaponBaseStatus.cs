using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStatus",menuName = "SKYMJ_Game / Weapon Status")]
public class WeaponBaseStatus : ScriptableObject
{
    [SerializeField] private WeaponsManager.WeaponID weaponID;
    [SerializeField] private int numberBullet;      //�����e��
    [SerializeField] private int maxBullets;        //�ő及���e��  
    [SerializeField] private int magazineCapacity;�@//�}�K�W����ŕ�[�����e��
    [SerializeField] private int maxMagazine;       //�����ł���}�K�W����
    [SerializeField] private int currentMagazin;    //���݂̃}�K�W����
    [SerializeField] private int attack;            //�G�ɗ^����_���[�W��
    [SerializeField] private int rapidFire;�@�@�@�@ //�A�˗�
    [SerializeField] private float range;           //�˒�����

    public WeaponsManager.WeaponID WeaponID { get { return WeaponID; } }
    public int _numberBullet { get { return numberBullet; } }
    public int _maxBullets {  get { return maxBullets; } }
    public int _magazinCapacity {  get { return magazineCapacity; } }
    public int _maxMagazine {  get { return maxMagazine; } }
    public int _currentMagazin {  get { return currentMagazin; } }
    public int _attack { get { return attack; } }
    public int _rapidFire { get { return rapidFire; } }
    public float _range { get { return range; } }
}
