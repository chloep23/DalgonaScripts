// Star and Umbrella Mouse Draw - 
// Name: Chloe Park 
// Aimed Completion Date: January 12, 2023
// Purpose: Mouse Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_U_MouseDraw : MonoBehaviour
{
    // Duration Var: 
    Coroutine drawing; // Coroutine allows code to be run over several frames

    // Static Var: 
    public static List<Vector2> pointsList;
    public static List<GameObject> waypoints;
    public static GameObject WP1, WP2, WP3, WP4, WP5, WP6, WP7, WP8, WP9, WP10, WP11, WP12, WP13, WP14, WP15, WP16, WP17, WP18, WP19, WP20, WP21, WP22, WP23, WP24, WP25, WP26, WP27, WP28, WP29, WP30, WP31, WP32, WP33, WP34, WP35, WP36, WP37, WP38, WP39, WP40; 
    public static bool gameOver = false; 
    public static bool win = false;
    public static bool paused = false;
    public static bool started = false; 

    // Component Var:
    public List<LineRenderer> lineList;
    public int TouchedPoints = 0;
    public float delay = 1.5f;
    private Vector3 position;

    // Object Var:
    public GameObject Shape;
    public GameObject FinishedShape;
    public GameObject BrokenShape;
    public GameObject WinTxt;
    public GameObject LoseTxt;
    public GameObject EndMenu;
   
    // Start - Called Before First Frame Update
    void Start()
    {
        // Initialization of Objects:
        Shape.gameObject.SetActive(true);
        FinishedShape.gameObject.SetActive(false);
        BrokenShape.gameObject.SetActive(false);
        WinTxt.gameObject.SetActive(false);
        LoseTxt.gameObject.SetActive(false);

        // Initialization of Lists: 
        pointsList = new List<Vector2> ();
        waypoints = new List<GameObject> ();
        WP1 = GameObject.Find("WP1");
        WP2 = GameObject.Find("WP2");
        WP3 = GameObject.Find("WP3");
        WP4 = GameObject.Find("WP4");
        WP5 = GameObject.Find("WP5");
        WP6 = GameObject.Find("WP6");
        WP7 = GameObject.Find("WP7");
        WP8 = GameObject.Find("WP8");
        WP9 = GameObject.Find("WP9");
        WP10 = GameObject.Find("WP1O");
        WP11 = GameObject.Find("WP11");
        WP12 = GameObject.Find("WP12");
        WP13 = GameObject.Find("WP13");
        WP14 = GameObject.Find("WP14");
        WP15 = GameObject.Find("WP15");
        WP16 = GameObject.Find("WP16");
        WP17 = GameObject.Find("WP17");
        WP18 = GameObject.Find("WP18");
        WP19= GameObject.Find("WP19");
        WP20 = GameObject.Find("WP20");
        WP21 = GameObject.Find("WP21");
        WP22 = GameObject.Find("WP22");
        WP23 = GameObject.Find("WP23");
        WP24 = GameObject.Find("WP24");
        WP25 = GameObject.Find("WP25");
        WP26 = GameObject.Find("WP26");
        WP27 = GameObject.Find("WP27");
        WP28 = GameObject.Find("WP28");
        WP29= GameObject.Find("WP29");
        WP30 = GameObject.Find("WP3O");
        WP31 = GameObject.Find("WP31");
        WP32 = GameObject.Find("WP32");
        WP33 = GameObject.Find("WP33");
        WP34 = GameObject.Find("WP34");
        WP35 = GameObject.Find("WP35");
        WP36 = GameObject.Find("WP36");
        WP37 = GameObject.Find("WP37");
        WP38 = GameObject.Find("WP38");
        WP39 = GameObject.Find("WP39");
        WP40 = GameObject.Find("WP4O");
        waypoints.Add(WP1);
        waypoints.Add(WP2);
        waypoints.Add(WP3);
        waypoints.Add(WP4);
        waypoints.Add(WP5);
        waypoints.Add(WP6);
        waypoints.Add(WP7);
        waypoints.Add(WP8);
        waypoints.Add(WP9);
        waypoints.Add(WP10);
        waypoints.Add(WP11);
        waypoints.Add(WP12);
        waypoints.Add(WP13);
        waypoints.Add(WP14);
        waypoints.Add(WP15);
        waypoints.Add(WP16);
        waypoints.Add(WP17);
        waypoints.Add(WP18);
        waypoints.Add(WP19);
        waypoints.Add(WP20);
        waypoints.Add(WP21);
        waypoints.Add(WP22);
        waypoints.Add(WP23);
        waypoints.Add(WP24);
        waypoints.Add(WP25);
        waypoints.Add(WP26);
        waypoints.Add(WP27);
        waypoints.Add(WP28);
        waypoints.Add(WP29);
        waypoints.Add(WP30);
        waypoints.Add(WP31);
        waypoints.Add(WP32);
        waypoints.Add(WP33);
        waypoints.Add(WP34);
        waypoints.Add(WP35);
        waypoints.Add(WP36);
        waypoints.Add(WP37);
        waypoints.Add(WP38);
        waypoints.Add(WP39);
        waypoints.Add(WP40);
    }

    // Update - Called Once Per Frame
    void Update()
    {
        // Mouse Down: 
        if(Input.GetMouseButtonDown(0) && gameOver == false && paused == false) // Value 0 is the left click of a mouse
        {
            started = true;
            StartLine();
        }

        // Ideal Shape Tracker: 
        for (int Windex = 0; Windex < waypoints.Count; Windex++){
            if (waypoints[Windex] is null){
                TouchedPoints++;
            }
        }

        // Mouse Up: 
        if(Input.GetMouseButtonUp(0))
        {
            FinishLine();

            // Ideal Shape Check: 
            if (TouchedPoints == 40 && Input.GetMouseButtonUp(0)){
                // Ends Game: 
                gameOver = true;
                win = true;
            }
        }

        // Lose Game Check:
        if(gameOver == true && win == false && paused == false){
            for (int i = 0; i < lineList.Count; i++){ // Changes Color of Line if Fail: 
                lineList[i].SetColors(Color.red, Color.red);
            }
            LoseGame();
        }

        // Win Game Check:
        if(gameOver == true && win == true && paused == false){
            WinGame();
        }

        TouchedPoints = 0; // Reset touched points tracker
    }

    // Drawing Line Renderer Function - 
    void StartLine()
    {
        if(drawing!=null)// Check if drawing coroutine exists
        {
            StopCoroutine(drawing);
        }
        drawing = StartCoroutine(DrawLine());
    }

    // End Line Renderer Function - 
    void FinishLine()
    {
        StopCoroutine(drawing);
    }

    // Draw Line Process - 
    IEnumerator DrawLine()
    {
        // Generating Line Renderer: 
        GameObject newGameObject = Instantiate(Resources.Load("Line") as GameObject, new Vector3(0,0,0), Quaternion.identity); // Quaternion identity essentially copies rotation
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;
        lineList.Add(line);

        // During Coroutine: 
        while(true)
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            // Only Adds New Points to List: 
            if (!pointsList.Contains (new Vector2(position.x, position.y)) && paused == false) 
            {
                pointsList.Add (new Vector2(position.x, position.y)); 
            }
            line.positionCount++;
            line.SetPosition(line.positionCount-1, position);

            // Changes Color of Line if Fail: 
            if (gameOver == true && win == false && paused == false){
                 for (int i = 0; i < lineList.Count; i++){
                    lineList[i].SetColors(Color.red, Color.red);
                 }
                 break;
            }
            yield return null; // Acts once per frame and waits for the next frame to act again
        }
    }

    // Win Function - 
    public void WinGame()
    {
        // Brings in Finished Shape and Text: 
        Shape.gameObject.SetActive(false);
        FinishedShape.gameObject.SetActive(true);
        WinTxt.gameObject.SetActive(true);
        EndMenu.gameObject.SetActive(true);
        StartCoroutine(ResetRoutine());
    }

    // Lose Game Function - 
    public void LoseGame()
    {
        // Brings in Broken Shape and Text: 
        Shape.gameObject.SetActive(false);
        BrokenShape.gameObject.SetActive(true);
        LoseTxt.gameObject.SetActive(true);
        EndMenu.gameObject.SetActive(true);
        StartCoroutine(ResetRoutine());
    }

    // Reset Delay Function - 
    IEnumerator ResetRoutine(){
        yield return new WaitForSeconds(delay);
        Reset();
    }

    // Reset Function - 
    public void Reset()
    {
        Shape.gameObject.SetActive(true);
        FinishedShape.gameObject.SetActive(false);
        BrokenShape.gameObject.SetActive(false);
        WinTxt.gameObject.SetActive(false);
        LoseTxt.gameObject.SetActive(false);
        gameOver = false;
        win = false;
        paused = false;
        started = false; 
        S_Timer.TimerOn = true;
        S_Timer.TimeLeft = 29;
        U_Timer.TimerOn = true;
        U_Timer.TimeLeft = 39;
        pointsList = new List<Vector2> ();
        waypoints = new List<GameObject> ();
        WP1 = GameObject.Find("WP1");
        WP2 = GameObject.Find("WP2");
        WP3 = GameObject.Find("WP3");
        WP4 = GameObject.Find("WP4");
        WP5 = GameObject.Find("WP5");
        WP6 = GameObject.Find("WP6");
        WP7 = GameObject.Find("WP7");
        WP8 = GameObject.Find("WP8");
        WP9 = GameObject.Find("WP9");
        WP10 = GameObject.Find("WP1O");
        WP11 = GameObject.Find("WP11");
        WP12 = GameObject.Find("WP12");
        WP13 = GameObject.Find("WP13");
        WP14 = GameObject.Find("WP14");
        WP15 = GameObject.Find("WP15");
        WP16 = GameObject.Find("WP16");
        WP17 = GameObject.Find("WP17");
        WP18 = GameObject.Find("WP18");
        WP19= GameObject.Find("WP19");
        WP20 = GameObject.Find("WP20");
        WP21 = GameObject.Find("WP21");
        WP22 = GameObject.Find("WP22");
        WP23 = GameObject.Find("WP23");
        WP24 = GameObject.Find("WP24");
        WP25 = GameObject.Find("WP25");
        WP26 = GameObject.Find("WP26");
        WP27 = GameObject.Find("WP27");
        WP28 = GameObject.Find("WP28");
        WP29= GameObject.Find("WP29");
        WP30 = GameObject.Find("WP3O");
        WP31 = GameObject.Find("WP31");
        WP32 = GameObject.Find("WP32");
        WP33 = GameObject.Find("WP33");
        WP34 = GameObject.Find("WP34");
        WP35 = GameObject.Find("WP35");
        WP36 = GameObject.Find("WP36");
        WP37 = GameObject.Find("WP37");
        WP38 = GameObject.Find("WP38");
        WP39 = GameObject.Find("WP39");
        WP40 = GameObject.Find("WP4O");
        waypoints.Add(WP1);
        waypoints.Add(WP2);
        waypoints.Add(WP3);
        waypoints.Add(WP4);
        waypoints.Add(WP5);
        waypoints.Add(WP6);
        waypoints.Add(WP7);
        waypoints.Add(WP8);
        waypoints.Add(WP9);
        waypoints.Add(WP10);
        waypoints.Add(WP11);
        waypoints.Add(WP12);
        waypoints.Add(WP13);
        waypoints.Add(WP14);
        waypoints.Add(WP15);
        waypoints.Add(WP16);
        waypoints.Add(WP17);
        waypoints.Add(WP18);
        waypoints.Add(WP19);
        waypoints.Add(WP20);
        waypoints.Add(WP21);
        waypoints.Add(WP22);
        waypoints.Add(WP23);
        waypoints.Add(WP24);
        waypoints.Add(WP25);
        waypoints.Add(WP26);
        waypoints.Add(WP27);
        waypoints.Add(WP28);
        waypoints.Add(WP29);
        waypoints.Add(WP30);
        waypoints.Add(WP31);
        waypoints.Add(WP32);
        waypoints.Add(WP33);
        waypoints.Add(WP34);
        waypoints.Add(WP35);
        waypoints.Add(WP36);
        waypoints.Add(WP37);
        waypoints.Add(WP38);
        waypoints.Add(WP39);
        waypoints.Add(WP40);
    }
}
