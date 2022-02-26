/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 23, 2022
 * 
 * Description: Checks game logic [TESTINGS ONLY]
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TEST SCRIPT FOR CHECKING SCORE UPDATE
public class TestGame : MonoBehaviour
{
    /*** VARIABLES ***/
    public int point = 100;

    // Update is called once per frame
    void Update()
    {
        //check input as long as we are playing
        if (GameManager.GM.gameState == GameManager.gameStates.Playing)
        {
            if (Input.GetKeyUp("return"))
            {
                GameManager.GM.Score = GameManager.GM.Score + point;
            }

            if (Input.GetKeyUp("space"))
            {
                LevelManager.collectablesCollected++;
            }

            if (Input.GetKeyUp("backspace"))
            {
                GameManager.GM.Lives--;
            }
        }

    }//end Update()
}
