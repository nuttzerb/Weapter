using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{   

    public float dashRange = 50f;
    public float timeBetweenDash = 1f;
    private bool dashKey;
    private bool canDash = true;
    public bool isAlive = true;

    public Weapon currentWeapon;
    private Vector3 movement;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;
 //   public SpriteRenderer playerSprite;
/*    public PlayerProjectile playerProjectile;
    public HealthBar healthBar;*/
    //audio
    public AudioSource audioSource;
    public AudioClip deadAudio;
    public AudioClip dashAudio;
    public AudioClip healAudio;
    protected override void Start()
    {
        base.Start();
        // healthBar.SetMaxHealth(maxHitpoint);
   //     playerProjectile.damagePoint = 1;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        TakeInput();
    }
    void FixedUpdate()
    {
        if (isAlive)
        {
            Move();
            if (canDash && dashKey) StartCoroutine(Dash());
        }
    }
    private void TakeInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = new Vector3(movement.x, movement.y).normalized; // do lon cua vector = 1 
        dashKey = Input.GetButton("Jump");
    }
    IEnumerator Dash()
    {
        canDash = false;
        rb.velocity = new Vector2(movement.x * dashRange, movement.y * dashRange);
       // audioSource.PlayOneShot(dashAudio);
        yield return new WaitForSeconds(timeBetweenDash);
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
        isAlive = false;
      //  spriteRenderer.color = Color.black;
 //     GameManager.instance.deadMenuAnimator.SetTrigger("show");
 //   audioSource.PlayOneShot(deadAudio);
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
//        GameManager.instance.ShowText("+" + healingAmount.ToString() + "hp", 25, Color.red, transform.position, Vector3.up * 30, 1.0f);
      //  audioSource.PlayOneShot(healAudio);

    }
}
