using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // AudioSource audioSource;
    Player player;
    bool collected = false;
    public Sprite emptyChest;
    [SerializeField]int amount;

    private void Start()
    {
        amount = Random.Range(1, 10);
        //  audioSource = GetComponent<AudioSource>();
      //  player = FindObjectOfType<Player>();
    }
    private void OnCollect()
    {
        collected = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collected)
        {
            if (collision.gameObject.name == "Player")
            {
                OnCollect();
            }
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            //        GameManager.instance.ShowText("+" + amount + " coin", 36, Color.yellow, transform.position, Vector3.up * 50, 1.0f);
            //  GameManager.instance.coins += amount;
            // audioSource.Play();
            GameManager.instance.coins += amount;
        }
    }
}
