using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    [SerializeField] Transform player;
    [SerializeField] float timeBtwMoving;

    [SerializeField] float chaseDisteance;
    [SerializeField] float stoppingDistance;

    bool canMove=true;
    Rigidbody2D rb;
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
         if(canMove) StartCoroutine(Move());
    }
     IEnumerator Move()
    {
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
    protected override void Death()
    {
        base.Death();
        Destroy(gameObject);
    }
}
