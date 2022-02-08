using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    GameObject spell;
    public float bulletForce = 20;
    public AudioClip shootAudio;
    Vector2 mousePos;
    Vector2 myPos;
    Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spell = Instantiate(bullet, transform.position, Quaternion.identity);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // lay vi tri chuot
            myPos = transform.position;
            direction = (mousePos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * bulletForce; // velocity - van toc

         //   GameManager.instance.player.audioSource.PlayOneShot(shootAudio);
        }
    }
}
