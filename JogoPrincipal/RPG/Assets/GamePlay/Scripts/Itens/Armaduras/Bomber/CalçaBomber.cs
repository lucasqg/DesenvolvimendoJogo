﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalçaBomber : ArmaduraBase {
    public void GerarAleatorio(int qualidadeDoItem)
    {
        if (qualidadeDoItem < 3)
        {
            CalçaRuim();
            AtributosAdicionais();
        }
        else if (qualidadeDoItem >= 3 && qualidadeDoItem <= 6)
        {
            CalçaBoa();
            AtributosAdicionais();
        }
        if (qualidadeDoItem <= 10 && qualidadeDoItem > 6)
        {
            CalçaMuitoBoa();
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
            adicionalDefesa = 15;
            adicionalMago = 8;
        }
        else if (random == 3)
        {
            adicionalDefesa = 20;
            adicionalMago = 10;
        }
        else if (random == 4)
        {
            adicionalDefesa = 25;
            adicionalDano = 24;
        }
        else if (random == 5)
        {
            adicionalDefesa = 30;
            adicionalMago = 6;
        }
        else if (random == 6)
        {
            adicionalDefesa = 20;
            adicionalMago = 8;
        }
        else if (random == 7)
        {
            adicionalDefesa = 25;
            adicionalMago = 10;
        }
        else if (random == 8)
        {
            adicionalDefesa = 50;
        }
        else if (random == 9)
        {
            adicionalDefesa = 25;
            adicionalMago = 12;
        }
        else if (random == 10)
        {
            adicionalMago = 10;
        }
    }

    public void CalçaInicial()
    {
        minLevel = 1;
        defesaBase = 15;
    }
    public void CalçaRuim()
    {
        minLevel = 3;
        defesaBase = 35;
        minFor = 5;
        minInt = 10;
    }
    public void CalçaBoa()
    {
        minLevel = 6;
        defesaBase = 70;
        minFor = 7;
        minInt = 15;
    }
    public void CalçaMuitoBoa()
    {
        minLevel = 10;
        defesaBase = 100;
        minFor = 10;
        minInt = 20;
    }
    public override string TipoDeArmadura()
    {
        return "Calça";
    }
}
