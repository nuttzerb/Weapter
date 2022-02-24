using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public float arrowVelocity;
    [SerializeField] Rigidbody2D rb;


    void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    //    Destroy(gameObject);

    }

}
