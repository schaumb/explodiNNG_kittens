using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyBox : MonoBehaviour{

    public Material MaterialOnSelection;
    public Material Material;

    private MemoryStore memoryStore;

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
        memoryStore.Selected(this);
    }
    
    // Use this for initialization
    void Start () {
        this.memoryStore = GameObject.Find("MemoryLogic").GetComponent<MemoryStore>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
