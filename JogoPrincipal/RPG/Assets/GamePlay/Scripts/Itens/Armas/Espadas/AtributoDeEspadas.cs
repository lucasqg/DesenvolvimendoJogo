using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributoDeEspadas : ArmasBehaviour {

    //public int qualidadeDoItem; // de 1 até 10, sendo 1 ruim e 10 muito bom
	
	public void GerarAleatorio( int qualidadeDoItem)
    {
        if(qualidadeDoItem < 3)
        {
            EspadaRuim();
            AtributosAdicionais();
        }
        else if (qualidadeDoItem >= 3 && qualidadeDoItem <= 6)
        {
            EspadaBoa();
            AtributosAdicionais();
        }
        if (qualidadeDoItem <= 10 && qualidadeDoItem >6)
        {
            EspadaMuitoBoa();
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
        else if( random == 2)
        {
            adicionalDano = 36;
        }
        else if( random == 3)
        {
            adicionalDano = 45;
        }
        else if(random == 4)
        {
            adicionalDano = 54;
        }
        else if(random == 5)
        {
            adicionalDano = 64;
        }
        else if(random == 6)
        {
            adicionalDano = 16;
            adicionalVel = 8;
        }
        else if(random == 7)
        {
            adicionalDano = 36;
            adicionalVel = 16;
        }
        else if(random == 8)
        {
            adicionalVel = 33;
        }
        else if ( random == 9)
        {
            adicionalVel = 20;
            adicionalDano = 18;
        }
        else if( random == 10)
        {
            adicionalVel = 40;
        }

    }

    public void EspadaInicial()
    {
        //atributos básicos nescessarios;
        minFor = 10;
        minLevel = 1;
        //atributos básicos
        danoBase = 20;
        velAtaque = 10;
    }
    public void EspadaRuim()
    {
        //atributos básicos nescessarios
        minFor = 15;
        minLevel =3;
        //atributos básicos
        danoBase = 30;
        velAtaque = 10;
    }
    public void EspadaBoa()
    {
        //atributos básicos nescessarios
        minFor = 20;
        minLevel = 7;
        //atributos básicos
        danoBase = 20;
        velAtaque = 12;
    }
    public void EspadaMuitoBoa()
    {
        //atributos básicos nescessarios
        minFor = 30;
        minLevel = 10;
        //atributos básicos
        danoBase = 20;
        velAtaque = 15;
    }
    

}

