using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoMutado : NpcBase {

	// Use this for initialization
	void Start () {
        basicStats.baseAttack = 25;
        basicStats.baseDefense = 35;
        basicStats.startLife = 120;
        basicStats.nameNpc = "MorcegoMutado";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
