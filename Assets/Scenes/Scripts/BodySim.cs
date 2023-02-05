using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySim : MonoBehaviour
{
    public GravitationLogic[] bodies;
    public float timespeed = 1f;
    void Start()
    {
        bodies = FindObjectsOfType<GravitationLogic>();
        Time.fixedDeltaTime = Universe.phisicsTimeStep;
    }

    void FixedUpdate()
    {
        bodies = FindObjectsOfType<GravitationLogic>();
        Time.timeScale = timespeed;
        for(int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdateVelocity(bodies, Universe.phisicsTimeStep);
        }
        for(int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(Time.fixedDeltaTime);
        }
    }

    public void UpdateList(GravitationLogic bodie)
    {
        GravitationLogic[] tmpb = new GravitationLogic[bodies.Length - 1];
        int index = 0;
        for(int k = 0; k < bodies.Length; k++)
        {
            if(bodies[k] == bodie)
            {
                index = k;
                Debug.Log(bodies[k]);
            }
        }
        for(int k = 0; k < bodies.Length; k++)
        {
            if(k < index)
            {
                tmpb[k] = bodies[k];
            }
            else if(k > index)
            {
                tmpb[k - 1] = bodies[k];
            }
        }
    }
}
