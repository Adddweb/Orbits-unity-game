using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public GravitationLogic obj;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<GravitationLogic>() != null)
        {
            obj = collision.gameObject.GetComponent<GravitationLogic>();
            obj.force = new Vector2(0f, 0f);
        }
    }
}
