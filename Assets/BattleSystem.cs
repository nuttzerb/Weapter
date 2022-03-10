using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private enum State
    {
        Idle,
        Active,
    }
    [SerializeField] private Enemy[] enemyArray;
    [SerializeField] BattleColliderTrigger colliderTrigger;

    private State state;
    private void Awake()
    {
        state = State.Idle;
    }

    // Start is called before the first frame update
    void Start()
    {
        colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
      
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if(state == State.Idle)
        {
            StartBattle();
            colliderTrigger.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartBattle()
    {
        Debug.Log("Start Battle");
        foreach (Enemy enemy in enemyArray)
        {
            enemy.GetComponent<Enemy>().Spawn();

        }
        state = State.Active;
    }
}
