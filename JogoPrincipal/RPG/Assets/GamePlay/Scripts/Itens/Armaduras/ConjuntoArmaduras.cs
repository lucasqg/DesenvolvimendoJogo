using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public enum TiposArmaduras
{
        Elmo = 0,
        Peito = 1,
        Calça = 2,
        Bota = 3,
        Luva = 4
}

public class ConjuntoArmaduras : MonoBehaviour
{
    public PlayerBehaviour typeCharacter;
    public TiposArmaduras typeArmadura;
    public Hashtable conjunto = new Hashtable();

    public void ConjuntoDeArmaduras()
    {
        if(typeCharacter.GetTypeChar().ToString() == "Guerreiro")
        {
            ConjuntoGuerreiro();

            
        }
        else if (typeCharacter.GetTypeChar().ToString() == "Pistoleiro")
        {
            ConjuntoPistoleiro();

            
        }
        else if (typeCharacter.GetTypeChar().ToString() == "Guerreiro")
        {
            ConjuntoBomber();

            
        }
        else // sempre retorna o tipo guerreiro, mesmo que o type esteja errado.
        {
            ConjuntoGuerreiro();
        }
    }

    public void PutConjunto(string nome, int level, int dano, int defesa, int hp)
    {
        List<int> Atributos = new List<int>();

        Atributos.Add(level);
        Atributos.Add(dano);
        Atributos.Add(defesa);
        Atributos.Add(hp);

        this.conjunto.Add(nome, Atributos); //A hash guarda a informação do nome do elmo como key, e os atributos nela contidos.
    }

    public int RandomNumber(int min, int max)
    {
        int random = Random.Range(min, max);
        return random;
    }

    public void PutAtributoAdicional(string nome, int dano, int defesa, int hp)
    {
        if(typeCharacter.ToString() == "Elmo")
        {
            int random = RandomNumber(0, 10);
            if(random == 0)
            {

            }
        }
    }
    
    public void TodoConjunto()
    {
        //4 tipos de elmo
        PutConjunto("ElmoInicial", 1, 0, 1, 0); // elmo inicial (nome, level 1, dano 0, defesa 1, hp 0 )
        PutConjunto("ElmoFraco", 1, 0, 2, 0); // elmo fraco possui apenas +1 de defesa
        PutConjunto("ElmoMedio", 4, 2, 3, 3); // elmo medio possui 2 dano, 3 def, 3 hp ++
        PutConjunto("ElmoForte", 10, 4, 5, 10); //elmo forte possui 4 dano, 5 defesa, 10 hp++

        // 4 tipos de Peitos
        PutConjunto("PeitoInicial", 1, 0, 2, 0); // peito inicial possui 2 defesa apenas.
        PutConjunto("PeitoFraco", 1, 0, 3, 0);  //peito fraco possui apenas 3 de defesa
        PutConjunto("PeitoMedio", 5, 2, 5, 10); // peito medio possui 2 dano, 5 defesa, 10 hp
        PutConjunto("PeitoForte", 10, 5, 7, 20); // peito forte possui 5 dano, 7 defesa, 20 hp

        // 4 tipos de calças
        PutConjunto("CalçaInicial", 1, 0, 2, 0); // calça inicial possui apenas 2 defesa
        PutConjunto("CalçaFraca", 1, 0, 3, 0); // calça fraca possui apenas 3 defesa
        PutConjunto("CalçaMedia", 5, 2, 5, 10); //calça media possui 2 dano, 5 defesa, 10 hp
        PutConjunto("CalçaForte", 10, 5, 7, 20); //calça forte possui 5 dano, 7 defesa, 20 hp

        //4 tipos de luvas
        PutConjunto("LuvaInicial", 1, 1, 0, 0); // luva inicial possui apenas 1 de dano
        PutConjunto("LuvaFraca", 1, 2, 1, 0); // luva fraca possui 2 dano, 1 def
        PutConjunto("LuvaMedia", 4, 2, 2, 0); // luva media possui 3 dano, 2 def
        PutConjunto("LuvaForte", 8, 3, 3, 0); //luva forte possui 3 dano,  3 def

        //4 tipos de botas
        PutConjunto("BotaInicial", 1, 0, 0, 0); // bota inicial não possui nenhum atributo
        PutConjunto("BotaFraca", 1, 1, 0, 0); // bota inicial possui 1 dano
        PutConjunto("BotaMedia", 4, 1, 1, 0); // bota media possui 1 dano 1 def
        PutConjunto("BotaForte", 8, 2, 3, 0); // bota forte possui 3 dano 3 def

    }

    public void AtributosAdicionais() // método para encontrar um atributo aleatoriamente pra devidas classes de personagem
    {
        
    }

    public void ConjuntoGuerreiro() {
        TodoConjunto(); // cria todos os objetos com seus devidos atributos básicos;
                        // TODAS classes possuem o mesmo atributo, mas cada classe possui um atributo adicional
        
    }
}
*/