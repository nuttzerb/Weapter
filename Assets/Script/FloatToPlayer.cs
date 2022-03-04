using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatToPlayer : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float speed;
    [SerializeField] float pickupRadius;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) <= pickupRadius)
        {
         transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

}
