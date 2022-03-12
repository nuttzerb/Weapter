using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    [Header("General")]
    public Sprite currentWeaponSprite;
    public WeaponType weaponType;
    public int damage = 20;   

    [Header("Gun")]
    public GameObject bulletPrefab;
    [HideInInspector] public GameObject bullet;
    public float fireRate = 1;

    [Header("Sword")]
    public float attackRange;

    [Header("BOW")]
    public GameObject arrowPrefab;
    public SpriteRenderer arrowGFX;
    public SpriteRenderer bowCharge;
    public void Shoot()
    {
        bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        
    }
    public enum WeaponType
    {
        Sword,
        Bow,
        Gun,
        Shotgun,
    }



}
