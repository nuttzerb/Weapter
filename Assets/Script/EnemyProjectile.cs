using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage=1;
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
            //player get hit
            GameManager.instance.player.TakeDamage(damage);
      //      GameManager.instance.playerHealth.SetHealth(GameManager.instance.player.hitpoint);


            //    GameManager.instance.player.audioSource.PlayOneShot(damagedAudio);
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
