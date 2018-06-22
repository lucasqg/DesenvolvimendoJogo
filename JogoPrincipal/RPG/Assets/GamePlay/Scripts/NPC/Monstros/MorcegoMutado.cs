using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoMutado : NpcBase {

    public TreinadorCampo treinador;
	// Use this for initialization
	void Start () {
        danoTotal = 3;
        defesaTotal = 1;
        totalLife = 12;
        currentLife = totalLife;
    }
	
	
    public override void DestroiMonster()
    {
        if (currentLife <= 0)
        {
            treinador = FindObjectOfType(typeof(TreinadorCampo)) as TreinadorCampo;
            treinador.missao1 = false;
            Destroy(this.gameObject);
        }
    }

    
}
