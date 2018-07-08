using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : NpcBase {

    // Use this for initialization
    public override void InicializacaoDeStatus()
    {
        velTotal = 1000;
        danoTotal = 2;
        defesaTotal = 1;
        totalLife = 2;
        currentLife = totalLife;
        nameNPC = "LoboSelvagem";

    }

    public override void Start()
    {
        InicializacaoDeStatus();
    }

}
