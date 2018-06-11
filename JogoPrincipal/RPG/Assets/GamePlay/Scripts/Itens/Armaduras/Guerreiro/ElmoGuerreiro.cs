using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElmoGuerreiro : ArmaduraBase
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
            adicionalHP = 3;
        }
        else if (random == 3)
        {
            adicionalHP = 2;
        }
        else if (random == 4)
        {
            adicionalDefesa = 1;
        }
        else if (random == 5)
        {
            adicionalDefesa = 1;
        }
        else if (random == 6)
        {
            adicionalDefesa = 2;
            adicionalHP = 10;
        }
        else if (random == 7)
        {
            adicionalDefesa = 1;
            adicionalHP = 5;
        }
        else if (random == 8)
        {
            adicionalDefesa = 1;
            adicionalHP = 5;
        }
        else if (random == 9)
        {
            adicionalDefesa = 1;
            adicionalHP = 6;
        }
        else if (random == 10)
        {
            adicionalHP = 10;
            adicionalDano = 1;
        }
    }

    public void ElmoInicial()
    {
        minLevel = 1;
        HPbase = 3;
    }
    public void ElmoRuim()
    {
        minLevel = 3;
        HPbase = 5;
    }
    public void ElmoBom()
    {
        minLevel = 6;
        defesaBase = 1;
        HPbase = 5;
    }
    public void ElmoMuitoBom()
    {
        minLevel = 10;
        defesaBase = 2;
        HPbase = 10;
    }
    public override string TipoDeArmadura()
    {
        return "elmo";
    }
}
