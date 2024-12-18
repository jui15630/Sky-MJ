using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStatus",menuName = "SKYMJ_Game / Weapon Status")]
public class WeaponStatusAttribute : ScriptableObject
{
    [SerializeField] private WeaponsManager.WeaponID weaponID;
    [SerializeField] private int numberBullet;      //初期弾数
    [SerializeField] private int maxBullets;        //最大所持弾数  
    [SerializeField] private int magazineCapacity;　//マガジン一つで補充される弾数
    [SerializeField] private int maxMagazine;       //所持できるマガジン数
    [SerializeField] private int currentMagazin;    //現在のマガジン数
    [SerializeField] private int attack;            //敵に与えるダメージ量
    [SerializeField] private int rapidFire;　　　　 //連射力
    [SerializeField] private float range;           //射程距離

    public WeaponsManager.WeaponID WeaponID { get { return weaponID; } }
    public int _numberBullet { get { return numberBullet; } }
    public int _maxBullets {  get { return maxBullets; } }
    public int _magazinCapacity {  get { return magazineCapacity; } }
    public int _maxMagazine {  get { return maxMagazine; } }
    public int _currentMagazin {  get { return currentMagazin; } }
    public int _attack { get { return attack; } }
    public int _rapidFire { get { return rapidFire; } }
    public float _range { get { return range; } }
}
