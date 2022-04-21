using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] enum PickupObject { Coin, Key, Somthing };
    [SerializeField] PickupObject currentObject;
    [SerializeField] int pickupQuantity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if(currentObject == PickupObject.Coin)
            {
                GameManager.instance.coins += pickupQuantity;
            }
            if (currentObject == PickupObject.Key)
            {
                GameManager.instance.haveKey =true;
            }
            Destroy(gameObject);
        }
    }
}