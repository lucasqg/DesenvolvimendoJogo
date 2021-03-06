﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboDecomposto : NpcBase {
    public GameObject peito, luva;
    // Use this for initialization
    public override void InicializacaoDeStatus()
    {
        velTotal = 1000;
        danoTotal = 8;
        defesaTotal = 4;
        totalLife = 20;
        currentLife = totalLife;
        xp = 100;
        nameNPC = "LoboDecomposto";
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        for (int i = 0; i < player.GetNivelDeMissao("missãoPrincipal"); i++)
        {
            xp += 70;
            danoTotal += 2;
            defesaTotal += 3;
            totalLife += 5;
            currentLife = totalLife;
        }

    }

    public override void Start()
    {
        InicializacaoDeStatus();

    }

    public override void DropItem()
    {
        PlayerStatsController.AddXp(xp);
        int random = Random.Range(1, 10);
        if (random == 2) //10% chance de acertar o valor
        {
            GameObject peitoInstanciado = Instantiate(peito, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            peitoInstanciado.GetComponent<PeitoGuerreiro>().GerarAleatorio(player.GetNivelDeMissao("missãoprincipal")+1);
        }
        int randomico = Random.Range(1, 10);
        if (randomico == 1) //10% chance de acertar o valor
        {
            GameObject luvaInstanciada = Instantiate(luva, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            luvaInstanciada.GetComponent<LuvaGuerreiro>().GerarAleatorio(player.GetNivelDeMissao("missãoprincipal")+1);
        }
        base.DropItem();
    }
}
