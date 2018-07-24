using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtivadorEspada : MonoBehaviour {
    
    public GameObject Espada__costas;
    public GameObject Espada__Frente;
    public GameObject Espada__Esquerda;
    public GameObject Espada__Direita;
    public GameObject EspadaLançada;
    public ControleDeEspada Atributos;
    public PlayerBehaviour player;
    public Transform Personagem;
    public GameObject tPersonagem;
    public int posicao = 4;
    public bool espadaActive = false;
    public float velAtack = 3.0f;
    public int quantidadeDeHits=1;
    public GameObject explosion;
    public SkillBehaviour skill;
    public float ContadorDeTempo1=0, ContadorDeTempo7=0;
    public float ContadorDeTempo2 =5.0f;
    public float ContadorDeTempo3 = 7.0f;
    public float ContadorDeTempo4 = 10.0f;
    public float ContadorDeTempo5 = 15.0f;
    public float ContadorDeTempo6 = 20.0f;

    void Start()
    {
        velAtack = 3.0f;
        ContadorDeTempo1 = 0;
        ContadorDeTempo7 = 0;
   ContadorDeTempo2 = 5.0f;
     ContadorDeTempo3 = 7.0f;
     ContadorDeTempo4 = 10.0f;
     ContadorDeTempo5 = 15.0f;
    ContadorDeTempo6 = 20.0f;
}

    // Update is called once per frame
    void Update()
    {
            posicaoPlayer();
            PosicaoDeAtack();
            AtivadorSkill();
        ContadorDeTempo7 += Time.deltaTime;
        if (ContadorDeTempo7 >= 15)
        {
            RecuperaHpStamina();
            ContadorDeTempo7 = 0;
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
        else if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
        {
            posicao = 4; //frente
        }
    }

    public void PosicaoDeAtack()
    {
        ContadorDeTempo1 += Time.deltaTime;
        if ((Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) && ContadorDeTempo1 >= velAtack)
        {
            //for (int i = 1; i <= quantidadeDeHits; i++)
           // {
            ContadorDeTempo1 = 0;
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
                GameObject espada = Instantiate(Espada__Frente, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
            }
           // }
           // quantidadeDeHits = 1;
        }
    }

    public void AtivadorHitSkill(int QuantidadeDeHits)
    {
        quantidadeDeHits = QuantidadeDeHits;
    }


    public void AtivadorSkill()
    {
        
        ContadorDeTempo2 -= Time.deltaTime;
        ContadorDeTempo3 -= Time.deltaTime;
        ContadorDeTempo4 -= Time.deltaTime;
        ContadorDeTempo5 -= Time.deltaTime;
        ContadorDeTempo6 -= Time.deltaTime;
        UIController.instancer.SetSkill2(5, ContadorDeTempo2);
        UIController.instancer.SetSkill3(7, ContadorDeTempo3);
        UIController.instancer.SetSkill4(10, ContadorDeTempo4);
        UIController.instancer.SetSkill5(15, ContadorDeTempo5);
        UIController.instancer.SetSkill6(20, ContadorDeTempo6);
        if (Input.GetKeyDown(KeyCode.Alpha1)) // ataque básico
        {

        }
        if ((Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) && skill.hitDuplo == true && ContadorDeTempo2 <= 0)
        {
            if (player.currentStamina >= 15)
            {
                player.addStamina(-15);
                HitDuplo();
                ContadorDeTempo2 = 5;
            }
        }
        if ((Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)) && skill.explosion == true && ContadorDeTempo3 <= 0)
        {
            if (player.currentStamina >= 20)
            {
                player.addStamina(-20);
                Explosion();
                ContadorDeTempo3 = 7;
            }
        }
        if ((Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4)) && skill.hitTriplo == true && ContadorDeTempo4 <= 0)
        {
            if (player.currentStamina >= 20)
            {
                player.addStamina(-20);
                HitTriplo();
                ContadorDeTempo4 = 10;
            }
        }
        if ((Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5)) && skill.lançarEspada == true && ContadorDeTempo5 <= 0)
        {
            if (player.currentStamina >= 30)
            {
                player.addStamina(-30);
                LançarEspada();
                ContadorDeTempo5 = 15;
            }
        }
        if ((Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6)) && skill.giroDoInfinito == true && ContadorDeTempo6 <= 0)
        {
            if (player.currentStamina >= 40)
            {
                player.addStamina(-40);
                GiroDoInfinito();
                ContadorDeTempo6 = 20;
            }
        }
    }

    public void OnClick()
    {

    }

    public void HitDuplo()
    {
        if (skill.hitDuplo == true)
        {
            if (posicao == 3)
            {
                GameObject espada = Instantiate(Espada__costas, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada1 = Instantiate(Espada__costas, transform.position, transform.rotation, Personagem);
                espada1.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 1)
            {
                GameObject espada = Instantiate(Espada__Direita, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada1 = Instantiate(Espada__Direita, transform.position, transform.rotation, Personagem);
                espada1.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 2)
            {
                GameObject espada = Instantiate(Espada__Esquerda, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada1 = Instantiate(Espada__Esquerda, transform.position, transform.rotation, Personagem);
                espada1.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 4)
            {
                GameObject espada = Instantiate(Espada__Frente, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada1 = Instantiate(Espada__Frente, transform.position, transform.rotation, Personagem);
                espada1.transform.parent = tPersonagem.transform;
            }
        }
        else
        {
            //informa pontos skill insuficiente;
        }
    }

    public void Explosion()
    {
        if (skill.explosion == true)
        {
            if (posicao == 3)
            {
                GameObject espada = Instantiate(Espada__costas, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                espada.GetComponent<Damage>().explosionActivation = true;
                espada.GetComponent<Damage>().explosion = explosion;
                //explosionActive.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 1)
            {
                GameObject espada = Instantiate(Espada__Direita, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                espada.GetComponent<Damage>().explosionActivation = true;
                espada.GetComponent<Damage>().explosion = explosion;

                // explosionActive.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 2)
            {
                GameObject espada = Instantiate(Espada__Esquerda, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                espada.GetComponent<Damage>().explosionActivation = true;
                espada.GetComponent<Damage>().explosion = explosion;
                // explosionActive.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 4)
            {
                GameObject espada = Instantiate(Espada__Frente, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                espada.GetComponent<Damage>().explosionActivation = true;
                espada.GetComponent<Damage>().explosion = explosion;
                //explosionActive.transform.parent = tPersonagem.transform;
            }
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void HitTriplo()
    {
        if (skill.hitTriplo == true)
        {
            if (posicao == 3)
            {
                GameObject espada = Instantiate(Espada__costas, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada1 = Instantiate(Espada__costas, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada2 = Instantiate(Espada__costas, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 1)
            {
                GameObject espada = Instantiate(Espada__Direita, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada1 = Instantiate(Espada__Direita, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada2 = Instantiate(Espada__costas, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 2)
            {
                GameObject espada = Instantiate(Espada__Esquerda, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada1 = Instantiate(Espada__Esquerda, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada2 = Instantiate(Espada__Esquerda, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 4)
            {
                GameObject espada = Instantiate(Espada__Frente, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada1 = Instantiate(Espada__Frente, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject espada2 = Instantiate(Espada__Frente, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
            }
        }
    
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void RecuperaHpStamina()//
    {
        if (skill.regeneracaoHPStamina == true)
        {
            player.addLife(3);
            player.addStamina(10);
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void LançarEspada()//
    {
        if (skill.lançarEspada == true)
        {
            
                GameObject espada = Instantiate(EspadaLançada, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;

            espada.GetComponent<AtirarEspada>().alone = true;
            
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }


    public void GiroDoInfinito()
    {
        if (skill.giroDoInfinito == true)
        {
                GameObject espada = Instantiate(EspadaLançada, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                espada.GetComponent<AtirarEspada>().X = 0;
                espada.GetComponent<AtirarEspada>().Y = 1;
                GameObject espada1 = Instantiate(EspadaLançada, transform.position, transform.rotation, Personagem);
                espada1.transform.parent = tPersonagem.transform;
                espada1.GetComponent<AtirarEspada>().X = 1;
                espada1.GetComponent<AtirarEspada>().Y = 0;
                GameObject espada2 = Instantiate(EspadaLançada, transform.position, transform.rotation, Personagem);
                espada2.transform.parent = tPersonagem.transform;
                espada2.GetComponent<AtirarEspada>().X = 0;
                espada2.GetComponent<AtirarEspada>().Y = -1;
                GameObject espada3 = Instantiate(EspadaLançada, transform.position, transform.rotation, Personagem);
                espada3.transform.parent = tPersonagem.transform;
                espada3.GetComponent<AtirarEspada>().X = -1;
                espada3.GetComponent<AtirarEspada>().Y = 0;
                 GameObject espada4 = Instantiate(EspadaLançada, transform.position, transform.rotation, Personagem);
                espada4.transform.parent = tPersonagem.transform;
                espada4.GetComponent<AtirarEspada>().X = 0;
                espada4.GetComponent<AtirarEspada>().Y = 1;



        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }
}

