using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrong : MonoBehaviour
{
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
        gameObject.GetComponent<Renderer>().material.color = new Color(256, 0, 0);
        GameManager.lives--;
    }
    private void Awake()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(128, 128, 129);
    }
}
