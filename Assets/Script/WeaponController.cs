using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Update()
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle , Vector3.forward);
        transform.rotation = rotation;
        if(dir.x<0)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
        }
        if (dir.x > 0)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = false;
        }

    }
}
