// Umbrella Timer - 
// Name: Chloe Park 
// Aimed Completion Date: Thursday, January 12
// Purpose: Timer Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class U_Timer : MonoBehaviour
{
    // Component Var: 
    public static float TimeLeft = 39;
    public static bool TimerOn = false;

    // UI Var: 
    public TextMeshProUGUI TimerTxt;

    // Start - Called Before First Frame Update
    void Start()
    {
        // Initialization of Component: 
        TimerOn = true;
    }

    // Update - Called Once Per Frame
    void Update()
    {
        if(TimerOn && S_U_MouseDraw.started == false){
            UpdateTimer(TimeLeft);
        }
        if(TimerOn && S_U_MouseDraw.started == true)
        {   
            // Timer Duration: 
            if(TimeLeft > 0 && S_U_MouseDraw.gameOver == false)
            {
                TimeLeft -= Time.deltaTime; // Gradually decreasing time
                UpdateTimer(TimeLeft);
            }

            // Timer Ended: 
            if(TimeLeft <= 0 && S_U_MouseDraw.gameOver == false)
            {
                TimeLeft = 0;
                TimerOn = false;
                S_U_MouseDraw.gameOver = true;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
