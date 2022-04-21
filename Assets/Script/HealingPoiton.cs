using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPoiton : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" && GameManager.instance.player.hitpoint< GameManager.instance.player.maxHitpoint)
        {
            GameManager.instance.player.Heal(1);
            Destroy(gameObject);
        }
    }
}
