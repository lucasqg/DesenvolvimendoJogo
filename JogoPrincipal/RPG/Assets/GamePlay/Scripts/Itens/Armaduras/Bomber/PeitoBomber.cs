using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeitoBomber : ArmaduraBase
{
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
            adicionalMago = 12;
        }
        else if (random == 3)
        {
            adicionalDefesa = 30;
            adicionalMago = 8;
        }
        else if (random == 4)
        {
            adicionalDefesa = 25;
            adicionalMago = 10;
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
            adicionalDefesa = 30;
            adicionalMago = 12;
        }
        else if (random == 9)
        {
            adicionalDefesa = 25;
        }
        else if (random == 10)
        {
            adicionalMago = 10;
        }
    }

    public void PeitoInicial()
    {
        minLevel = 1;
        defesaBase = 20;
    }
    public void PeitoRuim()
    {
        minLevel = 3;
        defesaBase = 40;
        minInt = 10;
    }
    public void PeitoBom()
    {
        minLevel = 6;
        defesaBase = 80;
        minInt = 15;
    }
    public void PeitoMuitoBom()
    {
        minLevel = 10;
        defesaBase = 110;
        minInt = 25;
    }
}
