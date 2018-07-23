using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoLobo : MonoBehaviour
{

    private float ArmazenarCoordenadasX, ArmazenarCoordenadasY;
    private float vel = 0.5f;
    public Transform Hero;
    private bool liberaPer = true;
    private float distancia;
    private bool face = true;
    private Animator anim;
    private bool vivo = true;
    private bool perseguindo = false;
    //public PlayerBehaviour Player;
    private Transform lobo;
    public GameObject bandeira;
    public float positionX, positionY;
    public bool LoboDeMissao;
    // Use this for initialization
    void Start()
    {
        ArmazenarCoordenadasX = this.transform.position.x;
        ArmazenarCoordenadasY = this.transform.position.y;
        anim = GetComponent<Animator>();
        lobo = GetComponent<Transform>();
        ArmazenarCoordenadasX = this.transform.position.x;
        ArmazenarCoordenadasY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (perseguindo)
        {
            Movimentacao();
        }
        else
        {
            VoltaPosicaoInicial();
        }
    }

    public void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == "Ovelha" && LoboDeMissao)
        {
            Hero = outro.transform;
            perseguindo = true;
            //CASO CHEGUE NESTA CONDICAO, ENTAO O PLAYER PERDE
        }
        // após o personagem entrar na zona de visão do mob, ele se deslocará até ele, caso o mob seja um monstro;
        else if (outro.gameObject.CompareTag("Player"))
        {

            //Hero.position = new Vector3(positionX, positionY, -1.1f);
            Hero = outro.transform;
            perseguindo = true;
        }
        else if (outro.tag == "Carroceiro")
        {
            Hero = outro.transform;
            perseguindo = true;
        }
        else if (LoboDeMissao)
        {
            Hero = bandeira.transform; // passa para perseguir a coordenada da bandeira;
            perseguindo = true;
        }
    }
    public void perseguirBandeira()
    {
        Hero = bandeira.transform; // passa para perseguir a coordenada da bandeira;
        perseguindo = true;
    }

    public void OnTriggerExit2D(Collider2D outro)
    {

        if (outro.gameObject.CompareTag("Player"))
        {
            Hero = null;
            perseguindo = true;
            if (LoboDeMissao)
            {
                Hero = bandeira.transform; // passa para perseguir a coordenada da bandeira;
                perseguindo = true;
            }
        }



    }

    public void VoltaPosicaoInicial()
    {


        float distanciaX = ArmazenarCoordenadasX - this.transform.position.x;
        float distanciaY = ArmazenarCoordenadasY - this.transform.position.y;

        distanciaX = VerificaModulo(distanciaX);
        distanciaY = VerificaModulo(distanciaY);
        if (distanciaX != ArmazenarCoordenadasX && distanciaY != ArmazenarCoordenadasY)
        {

            if (distanciaX > distanciaY)
            {
                if (ArmazenarCoordenadasX < this.transform.position.x)
                {
                    transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                    ResetAnimatorAndando();
                    anim.SetBool("Andando", true);
                    anim.SetBool("Parado", false);

                }
                else if (ArmazenarCoordenadasX > this.transform.position.x)
                {
                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                    ResetAnimatorAndando();
                    anim.SetBool("Andando", true);
                    anim.SetBool("Parado", false);
                }
            }
            else
            {
                if (ArmazenarCoordenadasY < this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, -vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("Andando", true);
                    anim.SetBool("Parado", false);
                }
                else if (ArmazenarCoordenadasY > this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("Andando", true);
                    anim.SetBool("Parado", false);
                }
            }
        }
        else
        {
            anim.SetBool("Andando", false);
            anim.SetBool("Parado", true);
        }

    }

    void Spawn() // ainda não há spawn
    {

    }

    void flip()
    {
        face = !face;
        Vector3 scala = this.transform.localScale;
        scala.x *= -1;
        this.transform.localScale = scala;

    }

    public float VerificaModulo(float distancia) //atribui sempre distancia como positivo
    {
        if (distancia < 0)
        {
            distancia = distancia * -1;
            return distancia;
        }
        return distancia;
    }

    public void Movimentacao()
    {
        float distanciaX = Hero.transform.position.x - this.transform.position.x;
        float distanciaY = Hero.transform.position.y - this.transform.position.y;

        distanciaX = VerificaModulo(distanciaX);
        distanciaY = VerificaModulo(distanciaY);

        if (Hero != null)
        {
            if (distanciaX > distanciaY)
            {
                if (Hero.transform.position.x < this.transform.position.x)
                {
                    transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                    ResetAnimatorAndando();
                    anim.SetBool("Andando", true);
                    anim.SetBool("Parado", false);

                }
                else if (Hero.transform.position.x > this.transform.position.x)
                {
                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                    ResetAnimatorAndando();
                    anim.SetBool("Andando", true);
                    anim.SetBool("Parado", false);
                }
            }
            else
            {
                if (Hero.transform.position.y < this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, -vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("Andando", true);
                    anim.SetBool("Parado", false);
                }
                else if (Hero.transform.position.y > this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("Andando", true);
                    anim.SetBool("Parado", false);
                }
            }
        }
    }

    public void ResetAnimatorParado()
    {
        anim.SetBool("Andando", false);
        anim.SetBool("Parado", true);

    }

    public void ResetAnimatorAndando()
    {
        anim.SetBool("Andando", false);
        anim.SetBool("Parado", true);

    }
}
