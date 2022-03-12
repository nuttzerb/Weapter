using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    bool canDamage = true;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            animator.SetTrigger("Bum");
            Destroy(gameObject,.3f);
        }
    }
}
