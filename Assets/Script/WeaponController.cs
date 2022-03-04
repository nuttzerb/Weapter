using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        
       float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        

        if(dir.x<0)
        {
            if(GameManager.instance.player.currentWeapon.weaponType == Weapon.WeaponType.Bow)
            {
                angle -= 45;
            }
            player.transform.GetComponent<SpriteRenderer>().flipX = true;
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
        }
        if (dir.x > 0)
        {
            if (GameManager.instance.player.currentWeapon.weaponType == Weapon.WeaponType.Bow)
            {
                angle += 45;
            }

            player.transform.GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = false;
        }

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}
