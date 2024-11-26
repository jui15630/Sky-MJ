using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStatus",menuName = "SKYMJ_Game / Weapon Status")]
public class WeaponBaseStatus : ScriptableObject
{
    [SerializeField] private WeaponsManager.WeaponID weaponID;
    [SerializeField] private int numberBullet;      //‰Šú’e”
    [SerializeField] private int maxBullets;        //Å‘åŠ’e”  
    [SerializeField] private int magazineCapacity;@//ƒ}ƒKƒWƒ“ˆê‚Â‚Å•â[‚³‚ê‚é’e”
    [SerializeField] private int maxMagazine;       //Š‚Å‚«‚éƒ}ƒKƒWƒ“”
    [SerializeField] private int currentMagazin;    //Œ»İ‚Ìƒ}ƒKƒWƒ“”
    [SerializeField] private int attack;            //“G‚É—^‚¦‚éƒ_ƒ[ƒW—Ê
    [SerializeField] private int rapidFire;@@@@ //˜AË—Í
    [SerializeField] private float range;           //Ë’ö‹——£

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
