using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : NpcBase {
    
    // Use this for initialization
    protected void Start ()
    {
        basicStats.baseAttack = 40;
        basicStats.baseDefense = 50;
        basicStats.startLife = 200;
        basicStats.nameNpc = "Esqueleto";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
