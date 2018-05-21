using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboDecomposto : NpcBase {

	// Use this for initialization
	void Start () {
        basicStats.baseAttack = 20;
        basicStats.baseDefense = 30;
        basicStats.startLife = 100;
        basicStats.nameNpc = "LoboDecomposto";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
