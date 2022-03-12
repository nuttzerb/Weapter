using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null)
        {
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }

    }
}
