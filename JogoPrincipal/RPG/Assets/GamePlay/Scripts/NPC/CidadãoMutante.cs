using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CidadãoMutante : NpcBase {

	// Use this for initialization
	void Start () {

        basicStats.baseAttack = 50;
        basicStats.baseDefense = 60;
        basicStats.startLife = 200;
        basicStats.nameNpc = "CidadãoMutante";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
