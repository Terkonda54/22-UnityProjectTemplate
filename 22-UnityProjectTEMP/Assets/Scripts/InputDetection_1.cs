using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputDetection_1 : MonoBehaviour
{

    //VARIABLES
    public string password;
    public GameObject inputField;
    public GameObject textDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        password = inputField.GetComponent<Text>().text;
        if(password == "223")
        {
            SceneManager.LoadScene("level_2");
        }
    }



}