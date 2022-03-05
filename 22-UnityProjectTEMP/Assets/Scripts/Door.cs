using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    //Variables
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Awake()
    {
        Component halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
    }

    private void OnMouseDown()
    {
        print("ON MOUSE DOWN");
        gameObject.SetActive(false);
    }

    private void OnMouseUp()
    {
        print("ON MOUSE UPP");
    }

    private void OnMouseEnter()
    {
        print("Door:OnMouseEnter()");
        //Highlight on mouseover
        Component halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
    }

    private void OnMouseExit()
    {
        //De-highlight
        print("Door:OnMouseExit()");
        Component halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
    }
}
