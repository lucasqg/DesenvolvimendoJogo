using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuvaBomber : ArmaduraBase {


    public void GerarAleatorio(int qualidadeDoItem)
    {
        if (qualidadeDoItem < 3)
        {
            LuvaRuim();
            AtributosAdicionais();
        }
        else if (qualidadeDoItem >= 3 && qualidadeDoItem <= 6)
        {
            LuvaBoa();
            AtributosAdicionais();
        }
        if (qualidadeDoItem <= 10 && qualidadeDoItem > 6)
        {
            LuvaMuitoBoa();
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
            adicionalMago = 8;
        }
        else if (random == 5)
        {
            adicionalDefesa = 30;
            adicionalMago = 12;
        }
        else if (random == 6)
        {
            adicionalDefesa = 20;
            adicionalMago = 10;
        }
        else if (random == 7)
        {
            adicionalDefesa = 25;
            adicionalMago = 12;
        }
        else if (random == 8)
        {
            adicionalDefesa = 15;
        }
        else if (random == 9)
        {
            adicionalDefesa = 10;
        }
        else if (random == 10)
        {
            adicionalMago = 6;
        }
    }

    public void LuvaInicial()
    {
        minLevel = 1;
        defesaBase = 10;
    }
    public void LuvaRuim()
    {
        minLevel = 3;
        defesaBase = 25;
        minInt = 10;
    }
    public void LuvaBoa()
    {
        minLevel = 6;
        defesaBase = 50;
        minInt = 15;
    }
    public void LuvaMuitoBoa()
    {
        minLevel = 10;
        defesaBase = 75;
        minInt = 25;
    }
    public override string TipoDeArmadura()
    {
        return "Luva";
    }
}
