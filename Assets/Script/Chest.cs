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
        amount = Random.Range(5, 10);
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
            GameManager.instance.coins += amount;
            GameManager.instance.ShowText("+" + amount.ToString() + " coins", 25, Color.yellow, transform.position, Vector3.up * 30, 0.7f);

            // audioSource.Play();
        }
    }
}
