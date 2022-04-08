using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    Player player;
    public GameObject effect;
    Vector2 direction;
    [SerializeField] float pushForce = 0.2f;
    //public float pushForce = 2.0f;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag=="Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(player.currentWeapon.damage);    
            direction = (collision.transform.position - transform.position).normalized;
                 collision.transform.position = new Vector2(collision.transform.position.x+ direction.x*pushForce , collision.transform.position.y+direction.y* pushForce);
          //  Debug.Log(direction);
            effect = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 1f);
        }

        if (collision.tag == "Edge")
        {
            Destroy(gameObject);
        }
    }


}
