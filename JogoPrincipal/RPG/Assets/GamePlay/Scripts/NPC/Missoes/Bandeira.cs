using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandeira : NpcBase {

	// Use this for initialization
	public override void Start () {
        nameNPC = "LoboSelvagem";
        //velTotal = 900;
        danoTotal = 0;
        defesaTotal = 1;
        totalLife = 100;
        currentLife = totalLife;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
