using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weapon;
    SpriteRenderer spriteRenderer;

    Weapon tempWeapon;
    SpriteRenderer tempSpriteWeapon;
    SpriteRenderer playerWeaponSpriteRenderer;
    bool pickupAllowed;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
         playerWeaponSpriteRenderer = GetComponent<SpriteRenderer>();
        tempSpriteWeapon = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = weapon.currentWeaponSprite;
    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Pickup(collision);
        }
    }

    private void Pickup(Collider2D collision)
    {
        GameManager.instance.ShowText(weapon.name, 20, Color.white, transform.position, Vector3.one, 1f);
        playerWeaponSpriteRenderer = collision.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        //bien tam
        tempWeapon = collision.GetComponent<Player>().currentWeapon;
        tempSpriteWeapon.sprite = playerWeaponSpriteRenderer.sprite;
        // nhat vu khi len
        collision.GetComponent<Player>().currentWeapon = weapon;
        playerWeaponSpriteRenderer.sprite = weapon.currentWeaponSprite;
        // bo vu khi xuong
        weapon = tempWeapon;
        spriteRenderer.sprite = tempSpriteWeapon.sprite;
    }


}
