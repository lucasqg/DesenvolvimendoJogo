using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoMutado : NpcBase {

    public TreinadorCampo treinador;
		
    public override void DestroiMonster()
    {
        if (currentLife <= 0)
        {
            treinador = FindObjectOfType(typeof(TreinadorCampo)) as TreinadorCampo;
            treinador.missao1 = false;
            Destroy(this.gameObject);
        }
    }

    public void Inicializar()
    {
        velTotal = 1500;
        danoTotal = 3;
        defesaTotal = 1;
        totalLife = 12;
        currentLife = totalLife;
        nameNPC = "Morcego";
    }

    public override void VerificaNivel()
    {
        Inicializar();
        base.VerificaNivel(); //chama o metodo base;
    }

    public override void Start()
    {
        VerificaNivel();
    }

}
