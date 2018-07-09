using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuvaGuerreiro : ArmaduraBase {
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
            LuvaInicial();
        }
        else if (qualidadeDoItem < 0 && qualidadeDoItem < 3)
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
            adicionalDefesa = 1;
        }
        else if (random == 3)
        {
            adicionalDefesa = 1;
        }
        else if (random == 4)
        {
            adicionalHP = 10;
        }
        else if (random == 5)
        {
            adicionalHP = 4;
        }
        else if (random == 6)
        {
            adicionalHP = 5;
            adicionalDano = 1;
        }
        else if (random == 7)
        {
            adicionalHP = 6;
            adicionalDano = 1;
        }
        else if (random == 8)
        {
            adicionalHP = 15;
        }
        else if (random == 9)
        {
            adicionalHP = 4;
        }
        else if (random == 10)
        {
            adicionalHP = 6;
            adicionalDano = 1;
        }
    }

    public void LuvaInicial()
    {
        minLevel = 1;
        HPbase = 2;
        
    }
    public void LuvaRuim()
    {
        minLevel = 3;
        HPbase = 5;
    }
    public void LuvaBoa()
    {
        minLevel = 6;
        defesaBase = 1;
        HPbase = 10;
    }
    public void LuvaMuitoBoa()
    {
        minLevel = 10;
        HPbase = 10;
        defesaBase = 2;
    }
    public override string TipoDeArmadura()
    {
        return "luva";
    }
}
