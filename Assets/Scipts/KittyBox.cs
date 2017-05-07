using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyBox : MonoBehaviour{

    public Material MaterialOnSelection;
    public Material Material;

    public void OnGazeIn()
    {
        var renderer = this.GetComponent<Renderer>();

        renderer.material = this.MaterialOnSelection;
    }

    public void OnGazeOut()
    {
        var renderer = this.GetComponent<Renderer>();

        renderer.material = this.Material;
    }

    public void OnClick()
    {
        Debug.Log(string.Format("Box selected with name: {0}", this.name));
    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
