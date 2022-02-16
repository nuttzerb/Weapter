using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Gun WP", menuName ="Weapon/Gun")]
public class Weapon : ScriptableObject
{
    public Sprite currentWeaponSprite;
    public GameObject bulletPrefab;
    public GameObject bullet;
    public float fireRate = 1;
    public int damage = 20;

    public void Shoot()
    {
        bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        
    }



}
