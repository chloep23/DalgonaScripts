// Star and Umbrella Waypoint Collide - 
// Name: Chloe Park 
// Aimed Completion Date: January 12, 2023
// Purpose: Ideal Shape Check Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_U_WPCollide : MonoBehaviour
{
    // Collider Var: 
    CircleCollider2D collider;

    // Componenet Var: 
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
        for (int i = 0; i < S_U_MouseDraw.pointsList.Count; i++){
             if(collider.OverlapPoint(S_U_MouseDraw.pointsList[i]) && S_U_MouseDraw.paused == false)
             {
                S_U_MouseDraw.waypoints[wpNum] = null;
             }
        }
    }
}
