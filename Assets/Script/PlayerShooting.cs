using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Player player;

    public float bulletForce = 20;
    public float nextTimeOffFire = 0; 
    public AudioClip shootAudio;
    Vector2 mousePos;
    Vector2 myPos;
    Vector2 direction;

    private void Start()
    {
        player = GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0))
       {
            if(Time.time >= nextTimeOffFire)
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
}
