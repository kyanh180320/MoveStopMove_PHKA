using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    // Start is called before the first frame update
    Axe = 0,
    Knife = 1,
    Boomerang = 2,
}

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponScriptableObject", order = 1)]
public class WeaponData : ScriptableObject
{
    // Start is called before the first frame update
    public WeaponType weaponType;
    public new string name;
    public Projectile modelProjectile;
    public WeaponManager weaponManager;
    public Sprite icon;

    public Vector3 posWeaponManager;
    public Vector3 rotationWeaponManager;
    public int price;
    public float speedFly;
    public float range;
    public float rotateSpeed;

    
}
