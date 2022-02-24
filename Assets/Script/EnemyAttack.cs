using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform player;
    //  public int damage = 5;
    public float distanceToShoot = 20;
    public float projectileForce = 2;
    public float minCooldown = 2f;
    public float maxCooldown = 4f;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        StartCoroutine(ShootPlayer());

    }
    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(Random.Range(minCooldown, maxCooldown));
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
}
