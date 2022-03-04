using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public int damage=1;
    [HideInInspector] public float arrowVelocity;
    [SerializeField] Rigidbody2D rb;
    //public float pushForce = 2.0f;
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
            Destroy(gameObject);
        }

        if (collision.tag == "Edge")
        {
            Destroy(gameObject);
        }
    }
}
