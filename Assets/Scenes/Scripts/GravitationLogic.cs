using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationLogic : MonoBehaviour
{
    public float Alimx = 40;
    public float Alimy = 40;
    public float mass = 10000;
    public float radius;
    public Vector2 initialVelocity;
    public Vector2 forceDir;
    public Vector2 force;
    Vector2 currentVelocity;
    public Vector2 acceleration;
    BodySim nbody;
    private TrailRenderer tr;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        nbody = FindObjectOfType<BodySim>();
        rb = GetComponent<Rigidbody2D>();
        currentVelocity = initialVelocity;
        tr.startColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        tr.endColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    public void UpdateVelocity(GravitationLogic[] allBodies, float timeStep)
    {
        foreach(var otherBody in allBodies)
        {
            if(otherBody != this)
            {
                float sqrDst = (otherBody.rb.position - rb.position).sqrMagnitude;
                forceDir = (otherBody.rb.position - rb.position).normalized;
                force = forceDir * Universe.gravitationConstant * mass * otherBody.mass / sqrDst;
                acceleration = force / mass;
                if(acceleration.x > Alimx)
                {
                    acceleration.x = Alimx;
                }
                else if(acceleration.x < -Alimx)
                {
                    acceleration.x = -Alimx;
                }
                if(acceleration.y > Alimy)
                {
                    acceleration.y = Alimy;
                }
                else if(acceleration.y < -Alimx)
                {
                    acceleration.y = -Alimy;
                }
                currentVelocity += acceleration * timeStep;
            }
        }
    }
    public void UpdatePosition(float timeStep)
    {
        
        rb.position += currentVelocity * timeStep;
    }
}
