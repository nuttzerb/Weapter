using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null)
        {
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }

    }
}
