using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public int damagePoint;
    //public float pushForce = 2.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
/*        if (collision.tag == "Enemy")
        {
            Damage pDmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce

            };
            collision.SendMessage("ProjectileDamaged", pDmg);
            Destroy(gameObject);
        }*/
        if (collision.tag == "Edge")
        {
            Destroy(gameObject);
        }
    }
}
