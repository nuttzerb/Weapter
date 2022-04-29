using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;
    public float smoothing;
    public Vector3 offset;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, player.position + offset, smoothing);
            transform.position = newPos;
        }

    }
}
