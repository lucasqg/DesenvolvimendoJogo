using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonecoDeTreino : NpcBase {

    public TreinadorCampo treinador;
    public PlayerBehaviour player;
    protected void Start()
    {
        danoTotal = 0;
        defesaTotal = 0;
        totalLife = 5;
        currentLife = totalLife;
    }

    public override void DestroiMonster()
    {
        if (currentLife <= 0)
        {
            treinador.missao1 = true;
            Destroy(this.gameObject);
        }
    }

}
