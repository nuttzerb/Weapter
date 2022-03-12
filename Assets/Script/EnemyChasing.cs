using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : Enemy
{
    bool canDamage = true;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
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
            base.Death();
        }
    }
}
