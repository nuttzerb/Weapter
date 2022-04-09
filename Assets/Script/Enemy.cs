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
    protected Animator animator;

    protected bool canMove =true;
    protected Rigidbody2D rb;

    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
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
            canMove = true;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            // rb.MovePosition(transform.position);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            canMove = false;
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
        if(lootDrop!=null)
        {
            Instantiate(lootDrop, transform.position, Quaternion.identity);

        }
        base.Death();
        animator.SetTrigger("Dead");
        Destroy(gameObject, .3f);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        GameManager.instance.ShowText("" + damage + "", 24, Color.red, transform.position, Vector3.one, .3f);

    }
}
