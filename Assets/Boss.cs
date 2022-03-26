using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss : Enemy
{
    [SerializeField] float minTimeBtwSpawn=2f;
    [SerializeField] float maxTimebtwSpawn = 3f;
    [SerializeField] GameObject enemyObject;
    [SerializeField] Slider healthBar;
    private Vector3 pos = new Vector3(1, 1, 0);
    private bool canSpawn=true;
    protected override void Start()
    {
        base.Start();
        healthBar.enabled = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (canMove==true) animator.SetTrigger("Walk");
        else if (canMove==false) animator.SetTrigger("Idle");
        if(canSpawn)
        {
            StartCoroutine(SpawnEnemy());
        }
        healthBar.maxValue = maxHitpoint;
        healthBar.value = hitpoint;
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemyObject, transform.position +pos , Quaternion.identity);
        canSpawn = false;
        yield return new WaitForSeconds(Random.Range(minTimeBtwSpawn,maxTimebtwSpawn));
        canSpawn = true;

    }
}
