// Star and Umbrella Collision - 
// Name: Chloe Park 
// Aimed Completion Date: January 12, 2023
// Purpose: Collision Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_U_Collision : MonoBehaviour
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
        for (int i = 0; i < S_U_MouseDraw.pointsList.Count; i++){
             if(collider.OverlapPoint(S_U_MouseDraw.pointsList[i]) && S_U_MouseDraw.paused == false)
             {
                S_U_MouseDraw.gameOver = true;
             }
        }
    }
}
