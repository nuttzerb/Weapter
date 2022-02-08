using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    // public Weapon weapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            // collision.GetComponent<Player>().currentWeapon = weapon;
            // collision.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = Weapon.currentWeaponSpr;

        //    collision.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gameObject.spr
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
