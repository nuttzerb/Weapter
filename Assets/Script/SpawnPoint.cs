using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] Enemy[] enemyArray;
    [SerializeField] GameObject vfxPrefab;
    private float destroyTime=1f;
    public void Spawn()
    {
        GameObject clone =  Instantiate(vfxPrefab, transform.position, Quaternion.identity);
        Invoke("SpawnEnemy", destroyTime);
        Destroy(clone, destroyTime);
   
    }
    private void SpawnEnemy()
    {
        Instantiate(enemyArray[Random.Range(0, enemyArray.Length)], transform.position, Quaternion.identity);
    }
}
