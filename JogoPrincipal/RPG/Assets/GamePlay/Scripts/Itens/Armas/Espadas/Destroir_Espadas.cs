using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroir_Espadas : Damage {
    public GameObject Arma;
    private float timer = 0f;

    // Use this for initialization

    void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
        if (timer > 0.3f)
            Destroy(Arma);
        else
            timer=timer + Time.deltaTime;
    }

    
}
