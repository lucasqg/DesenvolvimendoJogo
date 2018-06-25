using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoMutado : NpcBase {

    public TreinadorCampo treinador;
	// Use this for initialization
	void Start () {
        danoTotal = 5;
        defesaTotal = 1;
        totalLife = 20;
        currentLife = totalLife;
    }
	
	
    public override void DestroiMonster()
    {
        if (currentLife <= 0)
        {
            treinador = FindObjectOfType(typeof(TreinadorCampo)) as TreinadorCampo;
            treinador.missao2 = true;
            Destroy(this.gameObject);
        }
    }
}
