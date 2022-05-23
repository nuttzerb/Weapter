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
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public virtual void TakeDamage(int damage)
    {
        hitpoint -= damage;
        if(hitpoint<=0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
    
    }
}
