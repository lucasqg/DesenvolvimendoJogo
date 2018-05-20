using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeitoGuerreiro : ArmaduraBase {

    public void GerarAleatorio(int qualidadeDoItem)
    {
        if (qualidadeDoItem < 3)
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
            adicionalDefesa = 15;
        }
        else if (random == 3)
        {
            adicionalDefesa = 50;
        }
        else if (random == 4)
        {
            adicionalDefesa = 25;
        }
        else if (random == 5)
        {
            adicionalDefesa = 30;
        }
        else if (random == 6)
        {
            adicionalDefesa = 20;
            adicionalDano = 24;
        }
        else if (random == 7)
        {
            adicionalDefesa = 25;
            adicionalDano = 24;
        }
        else if (random == 8)
        {
            adicionalDefesa = 30;
            adicionalDano = 30;
        }
        else if (random == 9)
        {
            adicionalDefesa = 25;
        }
        else if (random == 10)
        {
            adicionalDano = 24;
        }
    }

    public void PeitoInicial()
    {
        minLevel = 1;
        defesaBase = 25;
    }
    public void PeitoRuim()
    {
        minLevel = 3;
        defesaBase = 50;
        minFor = 10;
    }
    public void PeitoBom()
    {
        minLevel = 6;
        defesaBase = 90;
        minFor = 15;
    }
    public void PeitoMuitoBom()
    {
        minLevel = 10;
        defesaBase = 130;
        minFor = 25;
    }
}
