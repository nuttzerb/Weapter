using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage;
    public float pushForce = 0f;

    public float duration;
    public float magnitude;

    public AudioClip damagedAudio;
    CameraShake cameraShake;
    private void Start()
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

        //   collision.SendMessage("ProjectileDamaged", pDmg);
        //    GameManager.instance.player.audioSource.PlayOneShot(damagedAudio);
        //    GameManager.instance.player.healthBar.SetHealth(GameManager.instance.player.hitpoint);
            StartCoroutine(cameraShake.Shake(duration, magnitude));
            Destroy(gameObject);

        }
        else if (collision.tag == "Edge")
        {
            Destroy(gameObject);
        }
        else return;

    }
}
