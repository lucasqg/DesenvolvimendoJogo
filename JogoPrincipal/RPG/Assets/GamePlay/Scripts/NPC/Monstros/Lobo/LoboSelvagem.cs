using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboSelvagem : NpcBase {
    public GameObject luva, elmo, espada;
    // Use this for initialization
    public override void InicializacaoDeStatus()
    {
        velTotal = 1000;
        danoTotal = 8;
        defesaTotal = 2;
        totalLife = 8;
        currentLife = totalLife;
        nameNPC = "LoboSelvagem";
        xp = 40;

        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        for (int i=0; i<player.GetNivelDeMissao("missão2"); i++)
        {
            danoTotal += 2;
            defesaTotal += 2;
            totalLife += 5;
            currentLife = totalLife;
            xp += 38;
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
            GameObject luvaInstanciada = Instantiate(luva, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            luvaInstanciada.GetComponent<LuvaGuerreiro>().GerarAleatorio(player.GetNivelDeMissao("missão2")+1);
        }
        int randomico = Random.Range(1, 10);
        if (randomico == 1) //10% chance de acertar o valor
        {
            GameObject elmoInstanciada = Instantiate(elmo, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            elmoInstanciada.GetComponent<ElmoGuerreiro>().GerarAleatorio(player.GetNivelDeMissao("missão2")+1);
        }
        int randomico2 = Random.Range(1, 10);
        if (randomico2 == 1) //10% chance de acertar o valor
        {
            GameObject espadaInstanciada = Instantiate(espada, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            espadaInstanciada.GetComponent<ArmasBehaviour>().GerarAleatorio(player.GetNivelDeMissao("missão2") +1);
        }
        base.DropItem();
    }
}
