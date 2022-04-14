using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : Enemy
{
    bool canDamage = true;
    bool isAlive = true;
    BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(isAlive)
        base.Update();
    }
    protected override void Death()
    {
        isAlive = false;
        animator.SetTrigger("Dead");
        boxCollider2D.enabled = false;
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if(canDamage)
            {
                GameManager.instance.player.TakeDamage(1);
                canDamage = false;
            }
            Death();
           
        }
    }
}
