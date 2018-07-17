using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonecoDeTreino : NpcBase {

    public TreinadorCampo treinador;
    public override void Start()
    {
        danoTotal = 0;
        defesaTotal = 0;
        totalLife = 10;
        currentLife = totalLife;
        DestroiMonster();
       // base.Start();
    }
    public override void Update()
    {
        DestroiMonster();
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
