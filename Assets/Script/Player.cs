using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public PlayerHealthUI playerHealthUI;
    [Header("Dash")]
    public float dashRange = 50f;
    public float timeBetweenDash = 1f;
    private bool dashKey;
    private bool canDash = true;
    private bool isDashing = false;
    private Vector2 dashDir;

    public bool isAlive = true;

    public Weapon currentWeapon;
    private Vector3 movement;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;
    public Animator animator;
    [SerializeField] FlashEffect flashEffect;

    //audio
    public AudioSource audioSource;
    public AudioClip deadAudio;
    public AudioClip dashAudio;
    public AudioClip healAudio;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        playerHealthUI.SetMaxHealth(maxHitpoint);
        transform.position = GameObject.FindGameObjectWithTag("StartPoint").transform.position;
        //  DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if(isAlive) TakeInput();

    }
    void FixedUpdate() // co dinh
    {
        if (isAlive)
        {
            Move();
            if (canDash && dashKey)
            {
                animator.SetTrigger("Dash");

                isDashing = true;
                canDash = false;
                dashDir = new Vector2(movement.x, movement.y);
                if (dashDir == Vector2.zero)
                {
                    dashDir = new Vector2(transform.localScale.x, transform.localScale.y);
                }
                StartCoroutine(StopDashing());

            }
            if (isDashing)
            {
                rb.velocity = dashDir.normalized * dashRange;
                return;
            }
        }
    }

    
    private void TakeInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = new Vector3(movement.x, movement.y).normalized; // do lon cua vector = 1 
        dashKey = Input.GetButton("Jump");
        animator.SetFloat("Walk", Mathf.Abs(movement.x + movement.y));

    }
    IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(timeBetweenDash);
        isDashing = false;
        canDash = true;
    }
    private void Move()
    {
        //di chuyen
        rb.velocity = new Vector3(movement.x * speed, movement.y * speed);

    }
/*    public void SwapSprite(int skinId)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinId];
    }
*/
    protected override void Death()
    {
        //   audioSource.PlayOneShot(deadAudio);
        Invoke("ShowDeathMenu", 1f);

    }

    private void ShowDeathMenu()
    {
        isAlive = false;
        //  spriteRenderer.color = Color.black;

        GameManager.instance.menuCanvas.transform.GetChild(3).gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    /*    public void Respawn()   
   {
       isAlive = true;
       lastImmune = Time.time;
       pushDirection = Vector3.zero;
       boxCollider2D.enabled = true;

   }*/
    public void Heal(int healingAmount)
    {
        if (hitpoint == maxHitpoint)
        {
            return;
        }
        hitpoint += healingAmount;
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }
        playerHealthUI.SetHealth(hitpoint);
        GameManager.instance.ShowText("+" + healingAmount.ToString() + "hp", 25, Color.red, transform.position, Vector3.up * 30, 0.7f);


        //  audioSource.PlayOneShot(healAudio);
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        playerHealthUI.SetHealth(hitpoint); // xem lai sau
        flashEffect.Flash();
    }
}
