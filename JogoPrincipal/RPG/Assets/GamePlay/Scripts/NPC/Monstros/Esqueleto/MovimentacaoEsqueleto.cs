﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoEsqueleto : MonoBehaviour {

    private float ArmazenarCoordenadasX, ArmazenarCoordenadasY;
    private float vel = 0.5f;
    public Transform Hero;
    private bool liberaPer = true;
    private float distancia;
    private bool face = true;
    private Animator anim;
    private bool vivo = true;
    private Transform monster;
    private bool perseguindo = false;
    //public PlayerBehaviour Player;
    private List<Transform> monstros;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        monster = GetComponent<Transform>();
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
        if (outro.tag == "Carroceiro")
        {
            Hero = outro.transform;
            perseguindo = true;
        }
        // após o personagem entrar na zona de visão do mob, ele se deslocará até ele, caso o mob seja um monstro;
        else if (outro.gameObject.CompareTag("Player"))
        {

            Hero = outro.transform;
            perseguindo = true;
        }
        else if (outro.gameObject.CompareTag("Carroceiro"))
        {

            Hero = outro.transform;
            perseguindo = true;
        }
    }

    public void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.tag == "Carroceiro")
        {
            Hero = null;
            perseguindo = false;
        }
        else if (outro.gameObject.CompareTag("Player"))
        {
            Hero = null;
            perseguindo = false;
        }
        else if (outro.gameObject.CompareTag("Carroceiro"))
        {
            Hero = null;
            perseguindo = false;
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
                    anim.SetBool("AndandoLadoEsquerdo", true);
                }
                else if (ArmazenarCoordenadasX > this.transform.position.x)
                {
                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                    ResetAnimatorAndando();
                    anim.SetBool("AndandoLado", true);
                }
            }
            else
            {
                if (ArmazenarCoordenadasY < this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, -vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("AndandoFrente", true);
                }
                else if (ArmazenarCoordenadasY > this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("AndandoCostas", true);
                }
            }
        }
        else
        {
            anim.SetBool("AndandoCostas", false);
            anim.SetBool("AndandoFrente", false);
            anim.SetBool("AndandoLadoEsquerdo", false);
            anim.SetBool("AndandoLado", false);
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
                    anim.SetBool("AndandoLadoEsquerdo", true);
                }
                else if (Hero.transform.position.x > this.transform.position.x)
                {
                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                    ResetAnimatorAndando();
                    anim.SetBool("AndandoLado", true);
                }
            }
            else
            {
                if (Hero.transform.position.y < this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, -vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("AndandoFrente", true);
                }
                else if (Hero.transform.position.y > this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("AndandoCostas", true);
                }
            }
        }
    }

    public void Face(int face)
    {
        this.transform.Translate(new Vector2(this.transform.rotation.x,face));
    }

    public void ResetAnimatorParado()
    {
        anim.SetBool("AndandoFrente", false);
        anim.SetBool("AndandoCostas", false);
        anim.SetBool("AndandoLado", false);
        anim.SetBool("AndandoLadoEsquerdo", false);
        anim.SetBool("Parar", true);

    }

    public void ResetAnimatorAndando()
    {
        anim.SetBool("AndandoFrente", false);
        anim.SetBool("AndandoCostas", false);
        anim.SetBool("AndandoLado", false);
        anim.SetBool("AndandoLadoEsquerdo", false);
        anim.SetBool("Parar", false);
    }
}
