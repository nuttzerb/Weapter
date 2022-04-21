using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Sprite doorOpenLeft;
    [SerializeField] Sprite doorOpenRight;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if(GameManager.instance.haveKey)
            {
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = doorOpenLeft;
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = doorOpenRight;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                GameManager.instance.haveKey = false;
            }
        }
    }
}
