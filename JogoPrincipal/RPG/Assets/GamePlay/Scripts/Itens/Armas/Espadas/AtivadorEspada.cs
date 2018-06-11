using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorEspada : MonoBehaviour {
    public GameObject Espada__costas;
    public GameObject Espada__Frente;
    public GameObject Espada__Esquerda;
    public GameObject Espada__Direita;
    public ControleDeEspada Atributos;
    public Transform Personagem;
    public int posicao = 4;
    public bool espadaActive = false;
    public int velAtack = 100;
    public int quantidadeDeHits=1;

    public int ContadorDeTempo=0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
            posicaoPlayer();
            PosicaoDeAtack();
        
    }

    public void posicaoPlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            posicao = 1; // direita
        }
        else if (Input.GetKey(KeyCode.A))
        {
            posicao = 2; //esquerda
        }
        else if (Input.GetKey(KeyCode.W))
        {
            posicao = 3; //costas
        }
        else if (Input.GetKey(KeyCode.S))
        {
            posicao = 4; //frente
        }
    }

    public void PosicaoDeAtack()
    {
        ContadorDeTempo += 1;
        if (Input.GetKeyDown(KeyCode.M) && ContadorDeTempo >= velAtack)
        {
            for (int i = 1; i <= quantidadeDeHits; i++)
            {
                if (posicao == 3)
                {
                    Instantiate(Espada__costas, transform.position, transform.rotation, Personagem);

                }
                else if (posicao == 1)
                {
                    Instantiate(Espada__Direita, transform.position, transform.rotation, Personagem);

                }
                else if (posicao == 2)
                {
                    Instantiate(Espada__Esquerda, transform.position, transform.rotation, Personagem);

                }
                else if (posicao == 4)
                {
                    Instantiate(Espada__Frente, transform.position, transform.rotation, Personagem);

                }
                ContadorDeTempo = 0;
            }
            quantidadeDeHits = 1;
        }
    }

    public void AtivadorHitSkill(int QuantidadeDeHits)
    {
        quantidadeDeHits = QuantidadeDeHits;
    }
}
