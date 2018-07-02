using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboSelvagem : NpcBase {

    // Use this for initialization
    public override void InicializacaoDeStatus()
    {
        velTotal = 1000;
        danoTotal = 10;
        defesaTotal = 20;
        totalLife = 50;
        currentLife = totalLife;
        nameNPC = "LoboSelvagem";
        
    }

    public override void Start()
    {
        InicializacaoDeStatus();
    }

}
