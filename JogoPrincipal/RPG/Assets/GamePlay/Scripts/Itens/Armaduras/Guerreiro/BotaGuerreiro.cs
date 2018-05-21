using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaGuerreiro : ArmaduraBase {


    public void GerarAleatorio(int qualidadeDoItem)
    {
        if (qualidadeDoItem < 3)
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
            adicionalDano = 15;
        }
        else if (random == 3)
        {
            adicionalDano = 20;
        }
        else if (random == 4)
        {
            adicionalDano = 25;
        }
        else if (random == 5)
        {
            adicionalDano = 30;
        }
    }

    public void BotaInicial()
    {
        minLevel = 1;
        velocidadeMovimento = 4;
        defesaBase = 10;
    }
    public void BotaRuim()
    {
        minLevel = 3;
        defesaBase = 20;
        velocidadeMovimento = 5;
        minFor = 10;
    }
    public void BotaBoa()
    {
        minLevel = 6;
        defesaBase = 40;
        velocidadeMovimento = 5;
        minFor = 15;
    }
    public void BotaMuitoBoa()
    {
        minLevel = 10;
        defesaBase = 60;
        velocidadeMovimento = 6;
        minFor = 25;
    }
    public override string TipoDeArmadura()
    {
        return "bota";
    }
}
