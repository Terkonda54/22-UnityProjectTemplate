/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 26, 2022
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
    GameState gameState; //reference to the current game state

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
    [HideInInspector]
    public float currentTime; //current time of timer
    [HideInInspector]
    public string displayTime; //current time string to display
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
    public int collectAmount; //number of collectables to beat the level
    private GameObject[] collectables; //array of all colletable game objects
    private int collectablesCount; //number of total colletables in level
    [HideInInspector]
    public int collectablesCollected = 0; //number of collectables collected by player
    private bool leveWon;
    
    /*** MEHTODS ***/


    // Start is called before the first frame update
    private void Start()
    {
        gm = GameManager.GM; //find the game manager
        gameState = gm.gameState;// get the game sate

        //if we have not started playing set the defaults
        if (gameState != GameState.Playing){gm.SetDefaultGameStats();}

        if (mainCamera == null) { mainCamera = Camera.main; } //if main camera is null set to the default main camera
        if(playerGameObject == null) { playerGameObject = GameObject.FindGameObjectWithTag("Player"); } //set the player if null
    
        if(levelLives != 0) { gm.Lives = levelLives; } //if the level has a number of lives, set it to the number of lives for the game
        else { levelLives = gm.Lives; } //otherwise set the number of lives based on overall game lives

        if (timedLevel) { currentTime = startTime;  } // if this is a timed level,set the current time to the startTime specified

        if (collectableLevel){SetCollectables();} //if this is a collectable level get count of colletables



    }//end Start();

    // Update is called once per frame
    private void Update()
    {
        gameState = gm.gameState;

        //check input as long as we are playing
        if (gameState == GameState.Playing)
        {
            levelLives = gm.Lives; //updates the number of lives based game manager lives

            if (levelLives == 0) {levelWon = false; LevelEnd();}//lives all lost, set to lost, run level end
            else if (canBeatLevel && (gm.Score >= beatLevelScore)) { levelWon = true; LevelEnd();} //if level beat, set to won, run level end
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


    //Sets the number of collectables to get
    private void SetCollectables()
    {
        //if all collectables are spwaned at the start of the level 
        if (collectableExsistOnStart)
        {
            //find and count all collectables in the level
            collectables = GameObject.FindGameObjectsWithTag(collectableTag);
            collectablesCount = collectables.Length;

            //Check if we need to collect all collectables
            if (collectAll) { collectAmount = collectablesCount; }
        }


    }//end GetCollectables()


    //collectable added to collection
    public void CollectableAquired()
    {
        collectablesCollected++;
    }//end CollectableAquired()

    private void LevelEnd()
    {
        gm.SetGameState(GameState.Idle); //set the game state
        
        Debug.Log("Level Over");
        
        if(levelWon){gm.SetGameState(GameState.BeatLevel);} //if we won the level, go to next level
        else if(timerEnded || (!levelWon)){gm.SetGameState(GameState.LostLevel);} //otherwise check to see if 
        
    }//end LevelEnd()

}
