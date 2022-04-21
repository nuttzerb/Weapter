using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss : Enemy
{
    [Header("SlimeSpawn")]
    [SerializeField] float minTimeBtwSpawn=2f;
    [SerializeField] float maxTimebtwSpawn = 3f;
    [SerializeField] GameObject enemyObject;
    private Vector3 pos = new Vector3(1, 1, 0);
    private bool canSpawn=true;
   
    //Idle
    [Header("Spin")]
    [SerializeField] float SpinMoveSpeed;
    [SerializeField] Vector2 spinMoveDirection;
    //Attack Up N Down
    [Header("AttackUpNDown")]
    [SerializeField] float attackMoveSpeed;
    [SerializeField] Vector2 attackMoveDirection;
    //Attack Player
    [Header("AttackPlayer")]
    [SerializeField] float attackPlayerSpeed;
    // Other
    [Header("Other")]
    [SerializeField] Transform wallCheckUp;
    [SerializeField] Transform wallCheckDown;
    [SerializeField] Transform wallCheckLeft;
    [SerializeField] Transform wallCheckRight;
    [SerializeField] float wallCheckRadius;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] float pushForce = 5f;

    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingLeft;
    private bool isTouchingRight;

    private bool goingUp =true;
    private bool facingLeft = true;
    private bool isSpining = false;
    Vector2 direction;

    [Header("Shot")]
    public int projectileForce = 10;
    private GameObject[] spellCircle;
    private GameObject[] spellToward;

    public Transform[] firePointsCirle;
    public Transform[] firePointsToward;
    public GameObject projectile;

    protected override void Start()
    {
        base.Start();
        GameManager.instance.bossHealthSlider.gameObject.SetActive(true);
        spinMoveDirection.Normalize();
        attackMoveDirection.Normalize();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ShootCircle(firePointsCirle.Length));
        StartCoroutine(ShootToward(firePointsToward.Length));
        StartCoroutine(ShootPlayer());

    }

    // Update is called once per frame
    protected override void Update()
    {
        
        GameManager.instance.bossHealthSlider.maxValue = maxHitpoint;
        GameManager.instance.bossHealthSlider.value = hitpoint;
        //
        if (transform.localScale.x == -1) facingLeft = false;
        else if (transform.localScale.x == 1) facingLeft = true;

        //
        isTouchingUp = Physics2D.OverlapCircle(wallCheckUp.position, wallCheckRadius, wallLayer);
        isTouchingDown = Physics2D.OverlapCircle(wallCheckDown.position, wallCheckRadius, wallLayer);
        isTouchingLeft = Physics2D.OverlapCircle(wallCheckLeft.position, wallCheckRadius, wallLayer);
        isTouchingRight = Physics2D.OverlapCircle(wallCheckRight.position, wallCheckRadius, wallLayer);


        BossMechanic();



    }
    IEnumerator ShootCircle(int num)
    {
        yield return new WaitForSeconds(Random.Range(4, 6));
        if (player != null)
        {
            spellCircle = new GameObject[num];
            for (int i = 0; i < num; i++)
            {
                spellCircle[i] = Instantiate(projectile, transform.position, Quaternion.identity);
                direction = (firePointsCirle[i].position - spellCircle[i].transform.position).normalized;
                spellCircle[i].GetComponent<Rigidbody2D>().velocity = direction * projectileForce ; // velocity - van toc
                Destroy(spellCircle[i], 2f);
            }
            StartCoroutine(ShootCircle(num));

        }
    }
    IEnumerator ShootToward(int num)
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        if (player != null)
        {
            spellToward = new GameObject[num];
            for (int i = 0; i < num; i++)
            {
                spellToward[i] = Instantiate(projectile, transform.position, Quaternion.identity);
                direction = (firePointsToward[i].position - spellToward[i].transform.position).normalized;
                spellToward[i].GetComponent<Rigidbody2D>().velocity = direction * projectileForce ; // velocity - van toc
                Destroy(spellToward[i], 2f);
            }
            StartCoroutine(ShootToward(num));

        }
    }
    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        if (player != null)
        {

            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 playerPos = player.position;
            Vector2 direction = (playerPos - myPos).normalized; // lay gia tri
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce; // van toc
            StartCoroutine(ShootPlayer());
        }
    }
    private void BossMechanic()
    {
        float firstHealth = maxHitpoint*2/3;
        float secondHealth = maxHitpoint*1/5;
        if (canMove == true) animator.SetTrigger("Walk");

        if (hitpoint <= secondHealth)
        {
            facingLeft = true;
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            animator.SetTrigger("Spin");
            SpinState();

        }
        else if(hitpoint<= firstHealth && hitpoint > secondHealth)
        {
            if (canSpawn)
            {
                StartCoroutine(SpawnEnemy());
            }
            base.Update();
        }
        else
        {
            base.Update();
        }
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemyObject, transform.position +pos , Quaternion.identity);
        canSpawn = false;
        yield return new WaitForSeconds(Random.Range(minTimeBtwSpawn,maxTimebtwSpawn));
        canSpawn = true;

    }
    protected override void Death()
    {
        base.Death();
        GameManager.instance.bossHealthSlider.gameObject.SetActive(false);

    }

    void Flip()
    {
        facingLeft = !facingLeft;
        spinMoveDirection.x *= -1;
        attackMoveDirection.x *= -1;
        transform.Rotate(0, 180, 0);
    }
    void SpinState()
    {
        isSpining = true;
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if(isTouchingDown && !goingUp)
        {
            ChangeDirection(); 
        }
        
       else if (isTouchingLeft || isTouchingRight )
        {
            if (facingLeft) Flip();
            else if (!facingLeft) Flip();
        }
        rb.velocity = SpinMoveSpeed * spinMoveDirection;

    }
    void ChangeDirection()
    {
        goingUp = !goingUp;
        spinMoveDirection.y *= -1;
        attackMoveDirection.y *= -1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(wallCheckUp.position, wallCheckRadius);
        Gizmos.DrawSphere(wallCheckDown.position, wallCheckRadius);
        Gizmos.DrawSphere(wallCheckLeft.position, wallCheckRadius);
        Gizmos.DrawSphere(wallCheckRight.position, wallCheckRadius);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" && isSpining)
        {
            collision.GetComponent<Player>().TakeDamage(2);

            direction = (collision.transform.position - transform.position).normalized;
            collision.transform.position = new Vector2(collision.transform.position.x - direction.x * pushForce, collision.transform.position.y - direction.y * pushForce);

        }
    }

}
