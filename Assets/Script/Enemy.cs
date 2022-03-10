using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    [SerializeField] protected Transform player;
    [SerializeField] GameObject lootDrop;
    private float timeBtwMoving;
    [SerializeField]  float minTimeBtwMoving;
    [SerializeField] float maxTimeBtwMoving;

    [SerializeField] protected float chaseDisteance;
    [SerializeField] protected float stoppingDistance;

    bool canMove=true;
    Rigidbody2D rb;
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timeBtwMoving = Random.Range(minTimeBtwMoving, maxTimeBtwMoving);
         if (canMove) StartCoroutine(Move());
    }

     IEnumerator Move()
    {
        if(player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3 (1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) // neu xa qua thi lai gan
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            // rb.MovePosition(transform.position);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = this.transform.position; // neu trong khoang cach hop ly thi dung yen
                                                          // rb.MovePosition(transform.position);
        }
        yield return new WaitForSeconds(timeBtwMoving); 
        canMove = false;
        yield return new WaitForSeconds(timeBtwMoving);
        canMove = true;
    }


    public void Spawn()
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }

    protected override void Death()
    {
        Instantiate(lootDrop, transform.position, Quaternion.identity);
        base.Death();
        Destroy(gameObject);
    }

}
