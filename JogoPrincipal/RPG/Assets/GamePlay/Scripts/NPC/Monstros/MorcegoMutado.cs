using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoMutado : NpcBase {
    public GameObject calca, luva;
    public TreinadorCampo treinador;
		
    public override void DestroiMonster()
    {
        if (currentLife <= 0)
        {
            PlayerStatsController.AddXp(xp);
            DropItem();
            treinador = FindObjectOfType(typeof(TreinadorCampo)) as TreinadorCampo;
            treinador.missao1 = false;
            Destroy(this.gameObject);
        }
    }

    public override void InicializacaoDeStatus()
    {
        velTotal = 1500;
        danoTotal = 7;
        defesaTotal = 1;
        totalLife = 15;
        currentLife = totalLife;
        nameNPC = "Morcego";
        xp = 30;
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        for (int i = 0; i < player.GetNivelDeMissao("missao1"); i++)
        {
            xp += 40;
            danoTotal += 3;
            defesaTotal += 2;
            totalLife += 5;
            currentLife = totalLife;

        }

    }
    public override void DropItem()
    {
        PlayerStatsController.AddXp(xp);
        int random = Random.Range(1, 10);
        if (random == 2) //10% chance de acertar o valor
        {
            GameObject calcaInstanciada =  Instantiate(calca, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            calcaInstanciada.GetComponent<CalçaGuerreiro>().GerarAleatorio(player.GetNivelDeMissao("missão1")+1);
        }
        int randomico = Random.Range(1, 10);
        if (randomico == 1) //10% chance de acertar o valor
        {
            GameObject luvaInstanciada = Instantiate(luva, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            luvaInstanciada.GetComponent<LuvaGuerreiro>().GerarAleatorio(player.GetNivelDeMissao("missão1")+1);
        }
        base.DropItem();
    }

    public override void Start()
    {
        InicializacaoDeStatus();
        
    }

}
