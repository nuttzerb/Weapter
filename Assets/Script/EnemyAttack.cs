using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject[] spell;
    public GameObject projectile;
    public Transform player;
    //  public int damage = 5;
    public float distanceToShoot = 20;
    [SerializeField] int numShootAura = 10;
    public float projectileForce = 2;
    public float minCooldown = 2f;
    public float maxCooldown = 4f;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        StartCoroutine(ShootAura(numShootAura));

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
    IEnumerator ShootAura(int num)
    {
        yield return new WaitForSeconds(Random.Range(minCooldown, maxCooldown));
        if (player != null)
        {
            spell = new GameObject[num];
            for (int i = 0; i < num; i++)
            {
                spell[i] = Instantiate(projectile, transform.position, Quaternion.identity);
                spell[i].GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x, transform.position.y + (i+50)) * projectileForce; // velocity - van toc
                Destroy(spell[i], 1f);
            }

            StartCoroutine(ShootAura(num));
        }
    }
}