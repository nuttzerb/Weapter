using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : Enemy
{
    bool canDamage = true;
    bool isAlive = true;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
        Destroy(gameObject, 10f);
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
