using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int numOfHeart=3;

    [SerializeField] Image[] heart;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
      
    // Start is called before the first frame update
    void Start()
    {
        health = GameManager.instance.player.maxHitpoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(health > numOfHeart)
        {
            health = numOfHeart;
        }

        for (int i = 0; i < heart.Length; i++)
        {
            if(i<health)
            {
                heart[i].sprite = fullHeart;
            }
            else
            {
                heart[i].sprite = emptyHeart;
            }

            if(i<numOfHeart)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }
        }
    }
    public void SetMaxHealth(int health)
    {
        this.health = health;
        this.numOfHeart = health;
    }
    public void SetHealth(int health)
    {
        this.health = health;
    }

}
