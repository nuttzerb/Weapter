using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : Enemy
{
    [HideInInspector] public float attackDistance;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        attackDistance = base.stoppingDistance + 1.5f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(Vector2.Distance(transform.position, base.player.position) <= attackDistance)
        {
            Attack();
        }
        else if(Vector2.Distance(transform.position, base.player.position) >= attackDistance)
        {
            StopAttack();
          
        }

    }
    void Attack()
    {
            animator.SetBool("Attack", true);
            animator.SetBool("Walk", false);
    }
    void StopAttack()
    {
        animator.SetBool("Attack", false);
        animator.SetBool("Walk", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            GameManager.instance.player.TakeDamage(1);
        }
    }

}
