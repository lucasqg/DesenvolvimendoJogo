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
    public GameObject tPersonagem;
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
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            posicao = 1; // direita
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            posicao = 2; //esquerda
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            posicao = 3; //costas
        }
        else if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
        {
            posicao = 4; //frente
        }
    }

    public void PosicaoDeAtack()
    {
        ContadorDeTempo += 1;
        if (Input.GetKeyDown(KeyCode.Keypad1) && ContadorDeTempo >= velAtack)
        {
            for (int i = 1; i <= quantidadeDeHits; i++)
            {
                ContadorDeTempo = 0;
                if (posicao == 3)
                {
                    GameObject espada = Instantiate(Espada__costas, transform.position, transform.rotation, Personagem);
                    espada.transform.parent = tPersonagem.transform;
                }
                else if (posicao == 1)
                {
                    GameObject espada = Instantiate(Espada__Direita, transform.position, transform.rotation, Personagem);
                    espada.transform.parent = tPersonagem.transform;
                }
                else if (posicao == 2)
                {
                    GameObject espada = Instantiate(Espada__Esquerda, transform.position, transform.rotation, Personagem);
                    espada.transform.parent = tPersonagem.transform;
                }
                else if (posicao == 4)
                {
                    GameObject espada =  Instantiate(Espada__Frente, transform.position, transform.rotation, Personagem);
                    espada.transform.parent = tPersonagem.transform;
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
