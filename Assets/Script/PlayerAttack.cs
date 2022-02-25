using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Player player;
    [SerializeField] WeaponController weaponController;
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

    SpriteRenderer playerWeaponSpriteRenderer;
    [Header("BOW")]
    //BOW
/*    [SerializeField] GameObject arrowPrefab;
    [SerializeField] SpriteRenderer arrowGFX;*/
    [SerializeField] Slider bowPowerSlider;
    [SerializeField] Transform bow;

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
        weaponController = transform.GetChild(0).GetComponent<WeaponController>();
    }
    // Update is called once per frame
    void Update()
    {

        switch (player.currentWeapon.weaponType)
        {
            case (Weapon.WeaponType.Gun): 
                GunAttack(); 
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
    //GUN
    private void GunAttack()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextTimeOffFire)
            {
                player.currentWeapon.Shoot();
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // lay vi tri chuot
                myPos = transform.position;
                direction = (mousePos - myPos).normalized;
                player.currentWeapon.bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletForce; // velocity - van toc

                nextTimeOffFire = Time.time + player.currentWeapon.fireRate; //firerate

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
      //  transform.GetChild(0).rotation = Quaternion.
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

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // lay vi tri chuot
        myPos = transform.position;
        direction = (mousePos - myPos).normalized;

        Arrow arrow = Instantiate(player.currentWeapon.arrowPrefab, bow.position, Quaternion.identity).GetComponent<Arrow>();
        // arrow.arrowVelocity = arrowSpeed;

        arrow.GetComponent<Rigidbody2D>().velocity = direction * arrowSpeed;

        canFire = false;
        player.currentWeapon.arrowGFX.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, player.currentWeapon.attackRange);
    }
}
