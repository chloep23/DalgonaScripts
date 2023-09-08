// Pause Menu - 
// Name: Chloe Park 
// Aimed Completion Date: January 12, 2023
// Purpose: Trigger for Buttons

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Object Var: 
    [SerializeField] GameObject pauseMenu; // Private variable but also shows up in editor

    // Pause Function - 
    public void Pause()
    {
        S_U_MouseDraw.paused = true;
        T_C_MouseDraw.paused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Freezes game
    }

    // Resume Function - 
    public void Resume()
    {
        S_U_MouseDraw.paused = false;
        T_C_MouseDraw.paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 
    }

    // MainMenu Function - 
    public void MainMenu()
    {
        S_U_MouseDraw.paused = false;
        T_C_MouseDraw.paused = false;
        Time.timeScale = 1f;
        T_C_MouseDraw.gameOver = false;
        T_C_MouseDraw.win = false;
        T_C_MouseDraw.paused = false;
        T_C_MouseDraw.started = false; 
        T_Timer.TimerOn = true;
        T_Timer.TimeLeft = 14;
        C_Timer.TimerOn = true;
        C_Timer.TimeLeft = 24;
        SceneManager.LoadScene(0); // Switches Main Menu Scene
    }
    // Exit Function - 
    public void Exit()
    {
        S_U_MouseDraw.paused = false;
        T_C_MouseDraw.paused = false;
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Only in Unity Editor
        #endif
            Application.Quit(); // On Separate Application 
    }
}
