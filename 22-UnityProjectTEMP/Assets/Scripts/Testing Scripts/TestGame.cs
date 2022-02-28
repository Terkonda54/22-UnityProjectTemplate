/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 23, 2022
 * 
 * Description: Check for score update [TESTINGS ONLY]
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TEST SCRIPT FOR CHECKING SCORE UPDATE
public class TestGame : MonoBehaviour
{
    GameManager gm; //reference to game manager
    LevelManager lm; //reference to level manger

    public int point = 100;
   
    /*** MEHTODS ***/

    // Start is called before the first frame update
    private void Start()
    {
        gm = GameManager.GM; //find the game manager
        lm = GameObject.FindObjectOfType<LevelManager>();//find the Level manager game object

    }//end Start

    // Update is called once per frame
    void Update()
    {
        //add points
        if (Input.GetKeyUp("return"))
        {
            gm.UpdateScore(point);
        }

        //collectable added
        if (Input.GetKeyUp("space"))
        {
            lm.CollectableAquired();
        }

        //lose live
        if (Input.GetKeyUp("backspace"))
        {
            gm.LostLife();
        }

    }//end Update()
}

