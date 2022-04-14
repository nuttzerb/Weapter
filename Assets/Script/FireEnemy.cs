using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : Enemy
{
    private GameObject[] spell;
    public Transform[] firePoints;
    public GameObject projectile;

    Vector2 direction;

    public float distanceToShoot = 20;
    [SerializeField] int numShootAura = 10;
    public float projectileForce = 2;
    public float minCooldown = 2f;
    public float maxCooldown = 4f;
    protected override void Start()
    {
        base.Start();
        player = GameObject.Find("Player").transform;
        StartCoroutine(ShootAura(firePoints.Length));
        StartCoroutine(ShootPlayer());
    }

    protected override void Update()
    {
        base.Update();
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
        yield return new WaitForSeconds(Random.Range(minCooldown*2, maxCooldown*2));
        if (player != null)
        {
            spell = new GameObject[num];
            for (int i = 0; i < num; i++)
            {
                spell[i] = Instantiate(projectile, transform.position, Quaternion.identity);
                direction = (firePoints[i].position - spell[i].transform.position).normalized;
                spell[i].GetComponent<Rigidbody2D>().velocity = direction * projectileForce/2; // velocity - van toc
                Destroy(spell[i], 2f);
            }
            StartCoroutine(ShootAura(num));

        }
    }
}