/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 23, 2022
 * 
 * Description: Basic level manager
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    /*** VARIABLES ***/

    GameManager gm; //reference to game manager

    [Header("LEVEL SETTINGS")]
    public Camera mainCamera; //reference to main camera
    public GameObject playerGameObject; //reference to player character
    [Space(10)]

    [Tooltip("Number of Lives for level")]
    public int levelLives; //number of lives for level resets the game manager lives
    [Space(10)]

    [Tooltip("Can the level be beat by a score")]
    public bool canBeatLevel = false; //can the level be beat by a score
    public int beatLevelScore; // the score value to beat level
    [Space(10)]

    [Tooltip("Is the level timed")]
    public bool timedLevel = false; //is the leve timed 
    public float startTime = 10f; //time for level (if level is timed)
    static public float currentTime; //current time of timer (made static incase we can add to time through powerups)
    static public string displayTime; //current time string to display
    private bool timerStarted = false; //timer started
    private bool timerEnded = false; //check if timer has ended
    [Space(10)]

    [Tooltip("Are there collectables")]
    public bool collectableLevel = false; //are there collectables for the level
    [Tooltip("What tag is used for all colletables")]
    public string collectableTag; //tag for referencing colletables
    [Tooltip("Do the collectables exist in the level on start")]
    public bool collectableExsistOnStart; //are the collectables all in the level at start
    [Tooltip("Must collect all colletables to beat level")]
    public bool collectAll; //all colectables must be collected
    [Tooltip("Number of collectables to beat level")]
    public int numberToCollect; //number of collectables to beat the level
    static public int collectAmount; //number of collectables to beat the level
    private GameObject[] collectables; //array of all colletable game objects
    private int collectablesCount; //number of total colletables in level
    static public int collectablesCollected = 0; //number of collectables collected by player

   
    /*** MEHTODS ***/

    // Start is called before the first frame update
    private void Start()
    {
       gm = GameManager.GM; //find the game manager

        //game state is idle start game to change state to playing
        if (GameManager.GM.gameState == GameManager.gameStates.Idle) {gm.StartGame();}

        if (mainCamera == null) { mainCamera = Camera.main; } //if main camera is null set to the default main camera
        if(playerGameObject == null) { playerGameObject = GameObject.FindGameObjectWithTag("Player"); } //set the player if null
    
        if(levelLives != 0) { gm.Lives = levelLives; } //if the level has a number of lives, set it to the number of lives for the game
        else { levelLives = gm.Lives; } //otherwise set the number of lives based on overall game lives

        if (timedLevel) { currentTime = startTime;  } // if this is a timed level,set the current time to the startTime specified

        if (collectableLevel){GetCollectables();} //if this is a collectable level get count of colletables

    }//end Start();

    // Update is called once per frame
    private void Update()
    {

        //check input as long as we are playing
        if (GameManager.GM.gameState == GameManager.gameStates.Playing)
        {
            levelLives = gm.Lives; //updates the number of lives based game manager lives

            if (levelLives == 0) { LevelEnd(); } //if we have lost all lives go to level end
            else if (canBeatLevel && (gm.Score >= beatLevelScore)) {LevelEnd(); } //if we can beat the level and our score is greater than the beat level, /end level
            else if (timedLevel) { CheckTimer(); } //if we have run out of time
        }

    }//end Update()


    private void CheckTimer()
    {
        if (currentTime < 0)
        { // check to see if timer has run out
            timerEnded = true;
            LevelEnd();
        }
        else 
        { // game playing state, so update the timer
            currentTime -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(currentTime / 60); //calculate timer mintues
            float seconds = Mathf.FloorToInt(currentTime % 60); //calculate timer seconds
            displayTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }//end StartTimer();


    private void GetCollectables()
    {
        //if all collectables are spwaned at the start of the level 
        if (collectableExsistOnStart)
        {
            //find and count all collectables in the level
            collectables = GameObject.FindGameObjectsWithTag(collectableTag);
            collectablesCount = collectables.Length;

            //Check if we need to collect all collectables
            if (collectAll) { numberToCollect = collectablesCount; }
        }

        collectAmount = numberToCollect; //set number of collectables to collect

    }//end GetCollectables()

    private void LevelEnd()
    {
        gm.gameState = GameManager.gameStates.Idle; //set the game state

        Debug.Log("Level Over");
   
        gm.NextLevel();
    }//end LevelEnd()

}