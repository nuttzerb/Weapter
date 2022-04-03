using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public GameObject floatingTextPrefab;

    //public
    public int hitpoint;
    public int maxHitpoint = 10;
    public float speed = 7f;
    public SpriteRenderer spriteRenderer;
    //immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //push
    protected Vector3 pushDirection;

    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        hitpoint = maxHitpoint;
        spriteRenderer = GetComponent<SpriteRenderer>();
     //   GameManager.instance.player.healthBar.SetMaxHealth(GameManager.instance.player.maxHitpoint);
    }
    public virtual void TakeDamage(int damage)
    {
        ShowDamage(damage.ToString());
        hitpoint -= damage;
        if(hitpoint<=0)
        {
            Death();
        }
    }
    public void ShowDamage(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponent<TextMesh>().text = text;
        }
    }
    protected virtual void Death()
    {
    
    }
}
