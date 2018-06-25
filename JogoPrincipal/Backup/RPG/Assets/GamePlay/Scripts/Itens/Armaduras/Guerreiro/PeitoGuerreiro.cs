using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeitoGuerreiro : ArmaduraBase {

    public int qualidadeDoItem;

    public override void ativador() // ativado para nao usar o metodo start
    {
        GerarAleatorio(qualidadeDoItem);

    }

    public void GerarAleatorio(int qualidadeDoItem)
    {
        if(qualidadeDoItem == 0)
        {
            PeitoInicial();

        }
        else if (qualidadeDoItem < 0 && qualidadeDoItem < 3)
        {
            PeitoRuim();
            AtributosAdicionais();
        }
        else if (qualidadeDoItem >= 3 && qualidadeDoItem <= 6)
        {
            PeitoBom();
            AtributosAdicionais();
        }
        if (qualidadeDoItem <= 10 && qualidadeDoItem > 6)
        {
            PeitoMuitoBom();
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
            adicionalDefesa = 2;
            adicionalHP = 10;
        }
        else if (random == 4)
        {
            adicionalHP = 5;
        }
        else if (random == 5)
        {
            adicionalDano = 2;
        }
        else if (random == 6)
        {
            adicionalDefesa = 1;
            adicionalDano = 1;
        }
        else if (random == 7)
        {
            adicionalDefesa = 2;
            adicionalDano = 2;
        }
        else if (random == 8)
        {
            adicionalDefesa = 1;
            adicionalDano = 2;
        }
        else if (random == 9)
        {
            adicionalDefesa = 1;
            adicionalHP = 5;
        }
        else if (random == 10)
        {
            adicionalDano = 2;
            adicionalHP = 10;
        }
    }

    public void PeitoInicial()
    {
        minLevel = 1;
        defesaBase = 1;
    }
    public void PeitoRuim()
    {
        minLevel = 3;
        defesaBase = 2;
    }
    public void PeitoBom()
    {
        minLevel = 6;
        defesaBase = 5;
    }
    public void PeitoMuitoBom()
    {
        minLevel = 10;
        defesaBase = 8;
    }
    public override string TipoDeArmadura()
    {
        return "peito";
    }
}
