using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    Player player;
    //public float pushForce = 2.0f;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(player.currentWeapon.damage);
            Destroy(gameObject);
        }

        if (collision.tag == "Edge")
        {
            Destroy(gameObject);
        }
    }
}
