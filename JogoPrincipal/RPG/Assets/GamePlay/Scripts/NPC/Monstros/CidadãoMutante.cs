using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CidadãoMutante : NpcBase {

	// Use this for initialization
	protected void Start () {

        danoTotal = 8;
        defesaTotal = 6;
        totalLife = 30;
        currentLife = totalLife;
    }

    public override void DestroiMonster()
    {
        if (currentLife <= 0)
        {
            
            Destroy(this.gameObject);
        }
    }
}
