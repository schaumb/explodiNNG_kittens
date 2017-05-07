using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryStore : MonoBehaviour {

    public GameObject[] Store;

	// Use this for initialization
	void Start () {
		foreach (var box in Store)
        {
            Debug.Log(string.Format("Box is up and running name: {0}", box.name));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
