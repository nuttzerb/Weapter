using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    //public
    public int hitpoint;
    public int maxHitpoint = 10;
    public float speed = 10f;

    //immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //push
    protected Vector3 pushDirection;

    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        hitpoint = maxHitpoint;
     //   GameManager.instance.player.healthBar.SetMaxHealth(GameManager.instance.player.maxHitpoint);
    }
/*    protected virtual void Damaged(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);
            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }
    protected virtual void ProjectileDamaged(Damage dmg)
    {

        hitpoint -= dmg.damageAmount;
        //   pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

        GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

        if (hitpoint <= 0)
        {
            hitpoint = 0;
            Death();
        }

    }*/

    protected virtual void Death()
    {
    }
}
