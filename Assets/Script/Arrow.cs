using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Player player;
    PlayerAttack playerAttack;
    //public float pushForce = 2.0f;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        //if(player.currentWeapon.weaponType)
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(player.currentWeapon.damage  );
            Destroy(gameObject);
        }

        if (collision.tag == "Edge")
        {
            Destroy(gameObject);
        }
    }
}
