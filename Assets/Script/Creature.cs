using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    //public
    public int hitpoint;
    public int maxHitpoint = 10;
    public float speed = 7f;
    public SpriteRenderer spriteRenderer;
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
    public void TakeDamage(int dmg)
    {
        hitpoint -= dmg;
        if(hitpoint<=0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
    
    }
}
