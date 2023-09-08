// Triangle and Circle Collision - 
// Name: Chloe Park 
// Aimed Completion Date: January 12, 2023
// Purpose: Collision Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C_Collision : MonoBehaviour
{
    // Collider Var: 
    PolygonCollider2D collider;

    // Start - Called Before First Frame Update
    void Start()
    {
        // Initialization of Collider: 
        collider = this.GetComponent<PolygonCollider2D>();
    }

    // Update - Called Once Per Frame
   void Update()
    {
        // Collision With Outside of Shape Check: 
        for (int i = 0; i < T_C_MouseDraw.pointsList.Count; i++){
             if(collider.OverlapPoint(T_C_MouseDraw.pointsList[i]) && T_C_MouseDraw.paused == false)
             {
                T_C_MouseDraw.gameOver = true;
             }
        }
    }
}
