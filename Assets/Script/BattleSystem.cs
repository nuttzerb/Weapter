using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private enum State
    {
        Idle,
        Active,
        BattleOver,
    }
    [SerializeField] Wave[] waveArray;
    [SerializeField] BattleColliderTrigger colliderTrigger;
    [SerializeField] GameObject wallZone;

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

    private void StartBattle()
    {
        Debug.Log("Start Battle");
        state = State.Active;
        StartCoroutine(GameManager.instance.cameraShake.Shake(GameManager.instance.duration, GameManager.instance.magnitude));

    }
    private void Update()
    {
        switch (state)
        {
            case State.Active:
                wallZone.SetActive(true) ;
                foreach (Wave wave in waveArray)
                {
                    wave.Update();
                }
                TestBattleOVer();
                break;
        }

  
    }
    private void TestBattleOVer()
    {
        if(state == State.Active)
        {
            if(AreWaveOver())
            {
                state = State.BattleOver;
                wallZone.SetActive(false);
                Debug.Log("BattleOver");
            }
        }
    }

    private bool AreWaveOver()
    {
        foreach (Wave wave in waveArray)
        {
            if(wave.isWaveOver())
            {
                // wave is over
               // return true; //ket thuc 1 wave
            }
            else
            {
                //wave not over
                return false;
            }
        }
        return true;
    }

    [System.Serializable]
    private class Wave// : MonoBehaviour
    {
        [SerializeField] private SpawnPoint[] spawnPoints;
        [SerializeField] private float timer;
        [SerializeField] public int numOfEnemies;
        public GameObject[] enemyInScene;

        public void Update()
        {
        //    Debug.Log(enemyInScene.Length);

            if (timer>0)
            {
                timer -= Time.deltaTime;
            }
            {
                if (timer < 0)
                {
                    if(numOfEnemies>0)
                    {
                        SpawnEnemy();
                    }
                }
            }
            enemyInScene = GameObject.FindGameObjectsWithTag("Enemy");

        }
        public void SpawnEnemy()
        {
            foreach (SpawnPoint spawnPoint in spawnPoints)
            {
                spawnPoint.GetComponent<SpawnPoint>().Spawn();
                numOfEnemies--;
            }
        }

        public bool isWaveOver()
        {
            if (timer < 0)
            {
          //      Debug.Log(enemyInScene.Length);
                if (enemyInScene.Length > 0) return false;
                else return true;
            }
            else
            {
                return false;
            }
        }

    }
    
}
