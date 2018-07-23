using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : NpcBase {
    public GameObject espada, peito;
    public GameObject osso;
    // Use this for initialization
    public override void InicializacaoDeStatus()
    {
        velTotal = 900;
        danoTotal = 8;
        defesaTotal = 3;
        totalLife = 17;
        currentLife = totalLife;
        nameNPC = "Esqueleto";
        xp = 50;
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        for (int i = 0; i < player.GetNivelDeMissao("missão3"); i++)
        {
            danoTotal += 2;
            defesaTotal += 3;
            totalLife += 3;
            currentLife = totalLife;
            xp += 50;
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
            Instantiate(osso, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity).SetActive(true);
        }
        int randomico = Random.Range(1, 10);
        if (randomico == 1) //10% chance de acertar o valor
        {
            GameObject espadaInstanciada = Instantiate(espada, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            espadaInstanciada.GetComponent<ArmasBehaviour>().GerarAleatorio(player.GetNivelDeMissao("missão3" )+1);
        }
        int randominco = Random.Range(1, 10);
        if (randominco == 1) //10% chance de acertar o valor
        {
            GameObject peitoInstanciado = Instantiate(peito, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            peitoInstanciado.GetComponent<PeitoGuerreiro>().GerarAleatorio(player.GetNivelDeMissao("missão3")+1); //gera o atributo da armadura
        }
        base.DropItem();
    }
}
