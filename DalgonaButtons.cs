// Dalgona Buttons - 
// Name: Chloe Park 
// Aimed Completion Date: January 12, 2023
// Purpose: Trigger for Buttons 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DalgonaButtons : MonoBehaviour
{
    // Triangle Function - 
    public void Triangle()
    {
        T_C_MouseDraw.gameOver = false;
        SceneManager.LoadScene(1); // Switches to Triangle Scene
    }

    // Circle Function - 
    public void Circle()
    {
        T_C_MouseDraw.gameOver = false;
        SceneManager.LoadScene(2); // Switches to Circle Scene
    }
    // Star Function - 
    public void Star()
    {
        S_U_MouseDraw.gameOver = false;
        SceneManager.LoadScene(3); // Switches to Star Scene
    }
    // Umbrella Function - 
    public void Umbrella()
    {
        S_U_MouseDraw.gameOver = false;
        SceneManager.LoadScene(4); // Switches to Umbrella Scene
    }
    // Info Screen Function - 
    public void InfoScreen()
    {
        SceneManager.LoadScene(5); // Switches to Info Scene
    }
}
