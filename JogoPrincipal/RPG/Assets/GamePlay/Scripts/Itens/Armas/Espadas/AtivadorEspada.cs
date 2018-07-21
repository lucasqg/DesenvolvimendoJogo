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
    public GameObject explosion;
    public SkillBehaviour skill;
    public int ContadorDeTempo=0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            posicaoPlayer();
            PosicaoDeAtack();
            AtivadorSkill();
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


    public void AtivadorSkill()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // ataque básico
        {

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && skill.hitDuplo == true)
        {
            HitDuplo();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && skill.explosion == true)
        {
            Explosion();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && skill.hitTriplo == true)
        {
            HitTriplo();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && skill.lançarEspada == true)
        {
            LançarEspada();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && skill.giroDoInfinito == true)
        {
            GiroDoInfinito();
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
                GameObject explosionActive = Instantiate(explosion, new Vector3(0, 0.216f,-1), Quaternion.identity, Personagem);
                //explosionActive.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 1)
            {
                GameObject espada = Instantiate(Espada__Direita, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject explosionActive = Instantiate(explosion, new Vector3(0.2f, 0, -1), Quaternion.identity, Personagem);
               // explosionActive.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 2)
            {
                GameObject espada = Instantiate(Espada__Esquerda, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject explosionActive = Instantiate(explosion, new Vector3(-0.2f, 0, -1), Quaternion.identity, Personagem);
               // explosionActive.transform.parent = tPersonagem.transform;
            }
            else if (posicao == 4)
            {
                GameObject espada = Instantiate(Espada__Frente, transform.position, transform.rotation, Personagem);
                espada.transform.parent = tPersonagem.transform;
                GameObject explosionActive = Instantiate(explosion, (new Vector3(0, -0.2506067f, -1)), Quaternion.identity, Personagem);
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
            ContadorDeTempo = 0;
        }
    
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void BuffDefesa()//
    {
        if (skill.buffDefesa == true)
        {

        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void AumentoHP()//
    {
        if (skill.aumentoHP == true)
        {

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

        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }
    public void AumentoAtackGuerreiro()//
    {
        if (skill.aumentoAtackGuerreiro == true)
        {

        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void PassivaIvulnerabilidade()//
    {

        if (skill.passivaIvulnerabilidade == true)
        {

        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void RegeneraçãoHPStamina()//
    {
        if (skill.regeneracaoHPStamina == true)
        {

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

        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }
}

