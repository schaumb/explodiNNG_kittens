using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyBox : MonoBehaviour{

    public Material MaterialOnSelection;
    public Material Material;

    public void OnGazeIn()
    {
        var renderer = GetComponent<Renderer>();

        renderer.material = MaterialOnSelection;
    }

    public void OnGazeOut()
    {
        var renderer = GetComponent<Renderer>();

        renderer.material = Material;
    }

    public void OnClick()
    {
        Debug.Log("Cube selected");
    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
