using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatoMutado : NpcBase {

	// Use this for initialization
	void Start () {
        basicStats.baseAttack = 30;
        basicStats.baseDefense = 40;
        basicStats.startLife = 120;
        basicStats.nameNpc = "RatoMutado";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
