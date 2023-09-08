// Triangle and Circle Waypoint Collide - 
// Name: Chloe Park 
// Aimed Completion Date: January 12, 2023
// Purpose: Ideal Shape Check Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C_WPCollide : MonoBehaviour
{
    // Collider Var: 
    CircleCollider2D collider;

    // Component Var: 
    public int wpNum;

    // Start - Called Before First Frame Update
    void Start()
    {
        // Initialization of Collider: 
         collider = this.GetComponent<CircleCollider2D>();
    }

    // Update - Called Once Per Frame
    void Update()
    {
        // Collision With Waypoints Check: 
        for (int i = 0; i < T_C_MouseDraw.pointsList.Count; i++){
             if(collider.OverlapPoint(T_C_MouseDraw.pointsList[i]) && T_C_MouseDraw.paused == false)
             {
                T_C_MouseDraw.waypoints[wpNum] = null;
             }
        }
    }
}
