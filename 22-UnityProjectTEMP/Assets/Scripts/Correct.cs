using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correct : MonoBehaviour
{

    //Variables
    public Renderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        print("ON MOUSE DOWN");
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 256, 0);
        MoveCamera.stage++;
    }

    private void Awake()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(128, 128, 129);
    }
}
