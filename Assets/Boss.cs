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
    [Header("Idle")]
    [SerializeField] float idleMoveSpeed;
    [SerializeField] Vector2 idleMoveDirection;
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
    [SerializeField] Transform wallCheckSide;
    [SerializeField] float wallCheckRadius;
    [SerializeField] LayerMask wallLayer;

    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingSide;
    private bool goingUp;
    private bool facingLeft = true;
    protected override void Start()
    {
        base.Start();
        GameManager.instance.bossHealthSlider.gameObject.SetActive(true);
        idleMoveDirection.Normalize();
        attackMoveDirection.Normalize();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
       // base.Update();
        if (canMove==true) animator.SetTrigger("Walk");
        else if (canMove==false) animator.SetTrigger("Idle");
        if(canSpawn)
        {
            StartCoroutine(SpawnEnemy());
        }
        GameManager.instance.bossHealthSlider.maxValue = maxHitpoint;
        GameManager.instance.bossHealthSlider.value = hitpoint;

        //
        isTouchingUp = Physics2D.OverlapCircle(wallCheckUp.position, wallCheckRadius, wallLayer);
        isTouchingDown = Physics2D.OverlapCircle(wallCheckDown.position, wallCheckRadius, wallLayer);
        isTouchingSide = Physics2D.OverlapCircle(wallCheckSide.position, wallCheckRadius, wallLayer);

        IdleState();
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(wallCheckUp.position, wallCheckRadius);
        Gizmos.DrawSphere(wallCheckDown.position, wallCheckRadius);
        Gizmos.DrawSphere(wallCheckSide.position, wallCheckRadius);

    }
    void Flip()
    {
        facingLeft = !facingLeft;
        idleMoveDirection.x *= -1;
        attackMoveDirection *= -1;
        transform.Rotate(0, 180, 0);
    }
    void IdleState()
    {
        if(isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if(isTouchingDown && !goingUp)
        {
            ChangeDirection(); 
        }
        rb.velocity = idleMoveSpeed * idleMoveDirection;
        if (isTouchingSide )
        {
            if (facingLeft) Flip();
            else if (!facingLeft) Flip();
        }


    }
    void ChangeDirection()
    {
        goingUp = !goingUp;
        idleMoveDirection.y *= -1;
        attackMoveDirection.y *= -1;
    }
}
