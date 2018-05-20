using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElmoBomber : ArmaduraBase
{
    public void GerarAleatorio(int qualidadeDoItem)
    {
        if (qualidadeDoItem < 3)
        {
            ElmoRuim();
            AtributosAdicionais();
        }
        else if (qualidadeDoItem >= 3 && qualidadeDoItem <= 6)
        {
            ElmoBom();
            AtributosAdicionais();
        }
        if (qualidadeDoItem <= 10 && qualidadeDoItem > 6)
        {
            ElmoMuitoBom();
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
            adicionalMago = 12;
        }
        else if (random == 3)
        {
            adicionalDefesa = 20;
            adicionalMago = 6;
        }
        else if (random == 4)
        {
            adicionalDefesa = 25;
            adicionalMago = 10;
        }
        else if (random == 5)
        {
            adicionalDefesa = 30;
            adicionalMago = 8
        }
        else if (random == 6)
        {
            adicionalDefesa = 20;
            adicionalMago = 6;
        }
        else if (random == 7)
        {
            adicionalDefesa = 25;
            adicionalMago = 12;
        }
        else if (random == 8)
        {
            adicionalDefesa = 20;
            adicionalMago = 8;
        }
        else if (random == 9)
        {
            adicionalDefesa = 25;
            adicionalMago = 10;
        }
        else if (random == 10)
        {
            adicionalHP = 80;
            adicionalMago = 12;
        }
    }

    public void ElmoInicial()
    {
        minLevel = 1;
        defesaBase = 15;
    }
    public void ElmoRuim()
    {
        minLevel = 3;
        defesaBase = 30;
        minInt = 10;
    }
    public void ElmoBom()
    {
        minLevel = 6;
        defesaBase = 65;
        minInt = 15;
    }
    public void ElmoMuitoBom()
    {
        minLevel = 10;
        defesaBase = 90;
        minInt = 25;
    }
}
