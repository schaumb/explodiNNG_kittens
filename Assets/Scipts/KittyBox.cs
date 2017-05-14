using System;
using UnityEngine;

public class KittyBox : MonoBehaviour{

    public Material MaterialOnSelection;
    public Material Material;
    public Material MaterialClicked;

    private MemoryStore memoryStore;

    private Boolean selected;
    private new Renderer renderer;

    public void OnGazeIn()
    {
        if (!this.selected)
        {
            this.renderer.material = this.MaterialOnSelection;
        }
    }

    public void OnGazeOut()
    {
        if (!this.selected)
        {
            this.renderer.material = this.Material;
        }
    }

    public void OnClick()
    {
        if (!this.selected)
        {
            memoryStore.OnSelect(this);
        }
    }
    
    // Use this for initialization
    void Start () {
        this.memoryStore = GameObject.Find("MemoryLogic").GetComponent<MemoryStore>();
        this.renderer = this.GetComponent<Renderer>();
        this.renderer.material = this.Material;
        this.selected = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void select()
    {
        this.selected = true;
        this.renderer.material = this.MaterialClicked;
    }

    public void deselect()
    {
        this.selected = false;
        this.renderer.material = this.Material;
    }

    public void hide()
    {
        this.gameObject.SetActive(false);
    }
}
