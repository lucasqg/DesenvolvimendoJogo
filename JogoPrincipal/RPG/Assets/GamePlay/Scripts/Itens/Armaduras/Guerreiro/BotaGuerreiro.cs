using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaGuerreiro : ArmaduraBase {

    public int qualidadeDoItem;

    

    public override void ativador() // ativado para nao usar o metodo start
    {
        qualidadeDoItem = Random.Range(1, 10);
        GerarAleatorio(qualidadeDoItem);

    }

    public void GerarAleatorio(int qualidadeDoItem)
    {
        if(qualidadeDoItem == 0)
        {
            BotaInicial();
        }
        else if (qualidadeDoItem < 0 && qualidadeDoItem < 3)
        {
            BotaRuim();
            AtributosAdicionais();
        }
        else if (qualidadeDoItem >= 3 && qualidadeDoItem <= 6)
        {
            BotaBoa();
            AtributosAdicionais();
        }
        if (qualidadeDoItem <= 10 && qualidadeDoItem > 6)
        {
            BotaMuitoBoa();
            AtributosAdicionais();
        }
    }

    public void AtributosAdicionais()
    {
        //gera uma func randon para atributos aleatórios;
        int random = Random.Range(1, 5);
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
            adicionalDano = 0;
        }
    }

    public void BotaInicial()
    {
        minLevel = 1;
        velocidadeMovimento = 3;
        defesaBase = 1;
    }
    public void BotaRuim()
    {
        minLevel = 3;
        defesaBase = 1;
        velocidadeMovimento = 4;
    }
    public void BotaBoa()
    {
        minLevel = 6;
        defesaBase = 2;
        velocidadeMovimento = 5;
    }
    public void BotaMuitoBoa()
    {
        minLevel = 10;
        defesaBase = 3;
        velocidadeMovimento = 6;
    }
    public override string TipoDeArmadura()
    {
        return "bota";
    }
}
