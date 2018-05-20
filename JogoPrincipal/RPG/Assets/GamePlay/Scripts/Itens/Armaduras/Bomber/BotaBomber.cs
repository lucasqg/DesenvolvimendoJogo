using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaBomber : ArmaduraBase {
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
            adicionalMago = 6;
        }
        else if (random == 3)
        {
            adicionalMago = 12;
        }
        else if (random == 4)
        {
            adicionalMago = 10;
        }
        else if (random == 5)
        {
            adicionalMago = 8;
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
        defesaBase = 15;
        velocidadeMovimento = 5;
        minInt = 5;
    }
    public void BotaBoa()
    {
        minLevel = 6;
        defesaBase = 30;
        velocidadeMovimento = 5;
        minInt = 15;
    }
    public void BotaMuitoBoa()
    {
        minLevel = 10;
        defesaBase = 45;
        velocidadeMovimento = 6;
        minInt = 15;
    }
}

