using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCS : MonoBehaviour
{
    BodySim bs;
    public float distance;
    Rigidbody2D rb;
    private void Awake()
    {
        bs = FindObjectOfType<BodySim>();
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        foreach(var bd in bs.bodies)
        {
            distance = (bd.GetComponent<Rigidbody2D>().position - rb.position).magnitude;
            bd.Alimx /= distance;
            bd.Alimy /= distance;
        }
    }
}
