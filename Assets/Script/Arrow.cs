using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public int damage=1;
    [HideInInspector] public float arrowVelocity;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float pushForce;
    Vector2 direction;
    BoxCollider2D boxCollider2D;
    private void Start()
    {

    }
    public void FixedUpdate()
    {
        rb.velocity = transform.up * arrowVelocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if(damage==0)
            {
                collision.GetComponent<Enemy>().TakeDamage(1);
            }
            else
            {
               collision.GetComponent<Enemy>().TakeDamage(damage);
            }
            direction = (collision.transform.position - transform.position).normalized;
            collision.transform.position = new Vector2(collision.transform.position.x + direction.x * pushForce, collision.transform.position.y + direction.y * pushForce);
            
            this.transform.parent = collision.transform;
            arrowVelocity = 0;
         //   boxCollider2D.enabled = false;
            Destroy(gameObject,15f);

        }

        if (collision.tag == "Edge")
        {
            this.transform.parent = collision.transform;
            arrowVelocity = 0;
            Destroy(gameObject, 15f);
        }
    }
}
