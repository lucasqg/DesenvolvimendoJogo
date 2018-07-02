using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboSelvagem : NpcBase {

    private PlayerBehaviour player;

    // Use this for initialization

    public override void Start()
    {
        nameNPC = "LoboSelvagem";
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        nivel = player.GetNivelDeMissao("missao2");
        VerificaNivel();
    }

    public override void VerificaNivel()
    {
        Inicializar();
        base.VerificaNivel(); //chama o metodo base;
    }

    public void Inicializar()
    {
        velTotal = 900;
        danoTotal = 10;
        defesaTotal = 7;
        totalLife = 50;
        currentLife = totalLife;
    }

   

}
