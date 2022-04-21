using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    bool canDamage = true;
    bool isAlive = true;
    BoxCollider2D boxCollider2D;
    [SerializeField] private float dmgCooldown=1f;
    private float currentCooldown;
    private Vector2 direction;
    [SerializeField] private float pushForce = 1f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        boxCollider2D = GetComponent<BoxCollider2D>();
        currentCooldown = dmgCooldown;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(isAlive)
        base.Update();
        if(canDamage==false)
        {
            currentCooldown -= Time.deltaTime;
            if(currentCooldown<=0)
            {
                canDamage = true;
                currentCooldown = dmgCooldown;
            }
        }
    }
    protected override void Death()
    {
        isAlive = false;
        animator.SetTrigger("Dead");
        boxCollider2D.enabled = false;
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if(canDamage )
            {
                GameManager.instance.player.TakeDamage(1);
                canDamage = false;
                direction = (collision.transform.position - transform.position).normalized;
                collision.transform.position = new Vector2(collision.transform.position.x + direction.x * pushForce, collision.transform.position.y + direction.y * pushForce);

            }
           
        }
    }
}
