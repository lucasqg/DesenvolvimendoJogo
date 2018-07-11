using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalçaGuerreiro : ArmaduraBase {

    public int qualidadeDoItem;


    public override void ativador() // ativado para nao usar o metodo start
    {
        qualidadeDoItem = Random.Range(1, 10);
        GerarAleatorio(qualidadeDoItem);

    }



    private void GerarAleatorio(int qualidadeDoItem)
    {
        if(qualidadeDoItem == 0)
        {
            CalçaInicial();
        }
        else if (qualidadeDoItem >0 && qualidadeDoItem < 3)
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

    private void AtributosAdicionais()
    {
        //gera uma func randon para atributos aleatórios;
        int random = Random.Range(1, 10);
        if (random == 1)
        {
            // sem atributos basicos               
        }
        else if (random == 2)
        {
            adicionalDefesa = 2;
        }
        else if (random == 3)
        {
            adicionalDefesa = 3;
        }
        else if (random == 4)
        {
            adicionalDefesa = 0;
            adicionalDano = 2;
        }
        else if (random == 5)
        {
            adicionalDefesa = 1;
        }
        else if (random == 6)
        {
            adicionalDefesa = 2;
            adicionalDano = 1;
        }
        else if (random == 7)
        {
            adicionalDefesa = 1;
            adicionalDano = 1;
        }
        else if (random == 8)
        {
            adicionalDefesa = 2;
        }
        else if (random == 9)
        {
            adicionalDefesa = 1;
            adicionalDano = 3;
        }
        else if (random == 10)
        {
            adicionalDano = 4;
        }
    }

    private void CalçaInicial()
    {
        minLevel = 1;
        defesaBase = 1;
    }
    private void CalçaRuim()
    {
        minLevel = 3;
        defesaBase = 2;
    }
    private void CalçaBoa()
    {
        minLevel = 6;
        defesaBase = 5;
    }
    private void CalçaMuitoBoa()
    {
        minLevel = 10;
        defesaBase = 7;
    }
    public override string TipoDeArmadura()
    {
        return "calça";
    }
    
}
