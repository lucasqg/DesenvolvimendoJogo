using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botões : MonoBehaviour {

    public GameObject start;
    public GameObject exit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStart()
    {
        Application.LoadLevel("Loader");
    }

    public void OnExit()
    {
        
    }
}
