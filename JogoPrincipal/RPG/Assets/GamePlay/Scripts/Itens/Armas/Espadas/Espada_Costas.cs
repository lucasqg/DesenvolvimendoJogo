using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada_Costas : MonoBehaviour
{
    public GameObject Espada__costas;
    public GameObject Espada__Frente;
    public GameObject Espada__Esquerda;
    public GameObject Espada__Direita;
    public Transform Personagem;
    public int posicao = 4;
    public bool espadaActive = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (espadaActive)
        {
            posicaoPlayer();
            PosicaoDeAtack();
        }

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
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            posicao = 4; //frente
        }
    }
    public void PosicaoDeAtack()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
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
        }
    }



}
