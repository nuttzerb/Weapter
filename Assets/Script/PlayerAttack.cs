using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Player player;

    //GUN
    [Header("GUN")]
    public float bulletForce = 20;
    public float nextTimeOffFire = 0; 
  
    public AudioClip shootAudio;
    Vector2 mousePos;
    Vector2 myPos;
    Vector2 direction;

    //SWORD
    [Header("Sword")] 
    [SerializeField] float startTimeBtwAttack;
    private float timeBtwAttack;
    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask whatIsEnemy;
    [SerializeField] SpriteRenderer swordSlash;
    [SerializeField] float pushForce=0.2f;
    SpriteRenderer playerWeaponSpriteRenderer;
    [Header("BOW")]
    //BOW
/*    [SerializeField] GameObject arrowPrefab;
    [SerializeField] SpriteRenderer arrowGFX;*/
    [SerializeField] Slider bowPowerSlider;
    [SerializeField] Transform bow;
    [SerializeField] Vector3 offsetSlider;
   // [Range(50, 70)]
   // [SerializeField] float bowPower;
    [Range(0, 3)]
    [SerializeField] float maxBowCharge;
    [SerializeField]float arrowSpeed = 50f;
    float bowCharge;
    bool canFire = true;
    private void Start()
    {
        player = GetComponent<Player>();
        playerWeaponSpriteRenderer = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        bowPowerSlider.value = 0;
        bowPowerSlider.maxValue = maxBowCharge;
    }
    // Update is called once per frame
    void Update()
    {
        if(player.isAlive)
        {
            switch (player.currentWeapon.weaponType)
            {
                case (Weapon.WeaponType.Gun):
                    GunAttack();
                    break;
                case (Weapon.WeaponType.Shotgun):
                    ShotgunAttack();
                    break;
                case (Weapon.WeaponType.Sword):
                    SwordAttack();
                    break;
                case (Weapon.WeaponType.Bow):
                    BowAttack();
                    break;
                default: break;
            }
        }

    }

    private  void ShotgunAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= nextTimeOffFire)
            {
                float ran = Random.Range(-.5f, .5f);
                player.currentWeapon.Shoot(3);
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // lay vi tri chuot
                myPos = transform.position;
                direction = (mousePos - myPos).normalized;
                player.currentWeapon.bullet[0].GetComponent<Rigidbody2D>().velocity =  direction* bulletForce; // velocity - van toc
                mousePos += new Vector2(ran, ran);
                direction = (mousePos - myPos).normalized;
                player.currentWeapon.bullet[1].GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y - .3f) * bulletForce; // velocity - van toc
                mousePos += new Vector2(ran, ran);
                direction = (mousePos - myPos).normalized;
                player.currentWeapon.bullet[2].GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y + .3f) * bulletForce; // velocity - van toc
                
                //Debug.Log(direction);

                nextTimeOffFire = Time.time + player.currentWeapon.fireRate; //firerate

                StartCoroutine(GameManager.instance.cameraShake.Shake(.14f, 0.1f));
            }

            //   GameManager.instance.player.audioSource.PlayOneShot(shootAudio);
        }
    }

    //GUN
    private void GunAttack()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextTimeOffFire)
            {
                player.currentWeapon.Shoot(1);
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // lay vi tri chuot
                myPos = transform.position;
                direction = (mousePos - myPos).normalized;
                player.currentWeapon.bullet[0].GetComponent<Rigidbody2D>().velocity = direction * bulletForce; // velocity - van toc

                nextTimeOffFire = Time.time + player.currentWeapon.fireRate; //firerate
             //   bowPowerSlider.value = nextTimeOffFire;

            }

            //   GameManager.instance.player.audioSource.PlayOneShot(shootAudio);
        }
        }
    //SWORD
    private void SwordAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (timeBtwAttack <= 0)
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, player.currentWeapon.attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    direction = (enemiesToDamage[i].transform.position - transform.position).normalized;
                     enemiesToDamage[i].transform.position = new Vector2(enemiesToDamage[i].transform.position.x + direction.x * pushForce, enemiesToDamage[i].transform.position.y + direction.y * pushForce);
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(player.currentWeapon.damage);
                  


                }
                playerWeaponSpriteRenderer.enabled = false;
                swordSlash.enabled = true;
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime * 100;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            swordSlash.enabled = false;
            playerWeaponSpriteRenderer.enabled = true;
        }
    }
    //BOW

    private void BowAttack()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            ChargeBow();
        }
        else if (Input.GetMouseButtonUp(0) && canFire)
        {
            FireBow();
        }
        else
        {
            if (bowCharge > 0f)
            {
                bowCharge -= 1f * Time.deltaTime;
            }
            else
            {
                bowCharge = 0f;
                canFire = true;
            }
            bowPowerSlider.value = bowCharge;
        }
    }
    
    void ChargeBow()
    {
        player.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = player.currentWeapon.bowCharge.sprite;
        player.currentWeapon.arrowGFX.enabled = true;

        bowCharge += Time.deltaTime;
        bowPowerSlider.value = bowCharge;

        if (bowCharge > maxBowCharge)
        {
            bowPowerSlider.value = maxBowCharge;

        }
    }
    void FireBow()
    {
        if (bowCharge > maxBowCharge) bowCharge = maxBowCharge;
        //input mouse rotation
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        myPos = transform.position;
        direction = (mousePos - myPos).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle-90));
        //
        //arrow
        Arrow arrow = Instantiate(player.currentWeapon.arrowPrefab, GameObject.Find("FirePoint").transform.position, rot).GetComponent<Arrow>();
        arrow.arrowVelocity = arrowSpeed; // co dinh
        float bowChargex10 = bowCharge * 10;
        
       // print("float " + (int) bowChargex10);
        arrow.damage = player.currentWeapon.damage * (int)bowChargex10;

        canFire = false;
        player.currentWeapon.arrowGFX.enabled = false;
        player.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = player.currentWeapon.currentWeaponSprite;

    }

    private void OnDrawGizmosSelected()
    {
        if(attackPos==null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,player.currentWeapon.attackRange); // player.currentWeapon.attackRange);
    }
}
