using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    Player player;
    public GameObject effect;
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
            effect = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 1f);
        }

        if (collision.tag == "Edge")
        {
            Destroy(gameObject);
        }
    }
}
