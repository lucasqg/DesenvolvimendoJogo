using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaçãoNPC : MonoBehaviour {
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
    void Start () {
        anim = GetComponent<Animator>();
        monster = GetComponent<Transform>();
        ArmazenarCoordenadasX = this.transform.position.x;
        ArmazenarCoordenadasY = this.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
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
        // após o personagem entrar na zona de visão do mob, ele se deslocará até ele, caso o mob seja um monstro;
        if (outro.gameObject.CompareTag("Player"))
        {
            
            Hero = outro.transform;
            perseguindo = true;
        }
    }

    public void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
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
                    anim.SetBool("AndarEsquerda", true);

                }
                else if (ArmazenarCoordenadasX > this.transform.position.x)
                {
                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                    ResetAnimatorAndando();
                    anim.SetBool("AndarDireita", true);
                }
            }
            else
            {
                if (ArmazenarCoordenadasY < this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, -vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("AndarFrente", true);
                }
                else if (ArmazenarCoordenadasY > this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("AndarCostas", true);
                }
            }
        }
        else
        {
            anim.SetBool("AndarCostas", false);
            anim.SetBool("AndarFrente", false);
            anim.SetBool("AndarDireita", false);
            anim.SetBool("AndarEsquerda", false);
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
        if(distancia< 0)
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
                    anim.SetBool("AndarEsquerda", true);

                }
                else if (Hero.transform.position.x > this.transform.position.x)
                {
                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                    ResetAnimatorAndando();
                    anim.SetBool("AndarDireita", true);
                }
            }
            else
            {
                if (Hero.transform.position.y < this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, -vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("AndarFrente", true);
                }
                else if (Hero.transform.position.y > this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, vel * Time.deltaTime));
                    ResetAnimatorAndando();
                    anim.SetBool("AndarCostas", true);
                }
            }
        }
    }

    public void ResetAnimatorParado()
    {
        anim.SetBool("AndarFrente", false);
        anim.SetBool("AndarCostas", false);
        anim.SetBool("AndarEsquerda", false);
        anim.SetBool("AndarDireita", false);
        anim.SetBool("Parar", true);

    }

    public void ResetAnimatorAndando()
    {
        anim.SetBool("AndarFrente", false);
        anim.SetBool("AndarCostas", false);
        anim.SetBool("AndarEsquerda", false);
        anim.SetBool("AndarDireita", false);
        anim.SetBool("Parar", false);

    }
   
}


