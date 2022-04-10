using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public static KnockBack instance;

    public void  Push( Transform thisObj,  Vector2 direction,  float pushForce)
    {
        thisObj.position = new Vector2(thisObj.position.x + direction.x * pushForce, thisObj.position.y + direction.y * pushForce);
    }
}
