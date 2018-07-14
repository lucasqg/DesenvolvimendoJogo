using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasBehaviour : ItensBase{
    //atributos minimos;
    private PlayerBehaviour player;

    public float velAtaque;
    public int danoBase;
    public int minLevel;
    public int minFor;
    public int minPres;
    public int minInt;
    //atributos adicionais
    public int adicionalHP;
    public int adicionalDano;
    public int adicionalMago;
    public int adicionalVel;
    

    private void Start()
    {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
       
    }
    public override void TxtAtributos()
    {
        UIController.instancer.atributosItens.text ="\n"; // apaga tudo
        if(minLevel >= 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "Nivel Minimo: " + minLevel.ToString();
        }
        if (velAtaque > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text +"\nVelocidade de ataque: " + velAtaque.ToString();
        }
        if(danoBase > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nDano: " + danoBase.ToString();
        }
        if (minFor > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nForça minima: " + minFor.ToString();
        }
        if (minPres > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nPrecisão minima: " + minPres.ToString();
        }
        if(minInt > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nInteligência minima: " + minInt.ToString();
        }
    }
    public override void StatusArma()
    {
        player.danoTotal += adicionalDano + danoBase;
    }
    public void GeraAtributos()
    {
        danoBase= Random.Range(1, 6);
        adicionalDano = Random.Range(1,5);
        adicionalHP = Random.Range(0, 20);
    }

    public void GerarAtributosPorDefinicao(int nivel)
    {
        danoBase = Random.Range(1,3);
        adicionalDano = Random.Range(1,3);
    }
    

    public void GerarAleatorio(int qualidadeDoItem)
    {
        if (qualidadeDoItem == 0)
        {
            ArmaIncial();
        }
        else if (qualidadeDoItem < 0 && qualidadeDoItem < 3)
        {
            ArmaRuim();
            AtributosAdicionais();
        }
        else if (qualidadeDoItem >= 3 && qualidadeDoItem <= 6)
        {
            ArmaBoa();
            AtributosAdicionais();
        }
        if (qualidadeDoItem <= 10 && qualidadeDoItem > 6)
        {
            ArmaMuitoBoa();
            AtributosAdicionais();
        }
    }

    public void AtributosAdicionais()
    {
        //gera uma func randon para atributos aleatórios;
        int random = Random.Range(1, 10);
        if (random == 1)
        {
            // sem atributos basicos               
        }
        else if (random == 2)
        {
            adicionalDano = 1;
        }
        else if (random == 3)
        {
            adicionalDano = 2;
        }
        else if (random == 4)
        {
            adicionalDano = 1;
        }
        else if (random == 5)
        {
            adicionalDano = 2;
            adicionalHP = 20;
        }
        else if (random == 6)
        {
            adicionalDano = 3;
        }
        else if (random == 7)
        {
            adicionalDano = 4;
        }
        else if (random == 8)
        {
            adicionalDano =4;
            adicionalHP = 5;
        }
        else if (random == 9)
        {
            adicionalDano = 3;
            adicionalHP = 10;
        }
        else if (random == 10)
        {
            adicionalDano = 3;
            adicionalHP = 20;
        }
    }

    public void ArmaIncial()
    {
        minLevel = 1;
        danoBase = 1;
    }
    public void ArmaRuim()
    {
        minLevel = 3;
        danoBase = 3;
    }
    public void ArmaBoa()
    {
        minLevel = 6;
        danoBase = 6;
    }
    public void ArmaMuitoBoa()
    {
        minLevel = 10;
        danoBase = 9;
        velAtaque = 1.2f;
    }
}
