using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaçãoNPC : MonoBehaviour {

    private float vel = 0.5f;
    public Transform Hero;
    private bool liberaPer = true;
    private float distancia;
    private bool face = true;
    private Animator anim;
    private bool vivo = true;
    private Transform monster;
    //public PlayerBehaviour Player;
    private List<Transform> monstros;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        monster = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        TesteDeslocamento();
    }

    public void OnTriggerEnter2D(Collider2D outro)
    {
        // após o personagem entrar na zona de visão do mob, ele se deslocará até ele, caso o mob seja um monstro;
        if (outro.gameObject.CompareTag("Player"))
        {
            
            Hero = outro.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            Hero = null;
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

    public void TesteDeslocamento()
    {
        float distanciaX = Hero.transform.position.x - this.transform.position.x;
        float distanciaY = Hero.transform.position.y - this.transform.position.y;
       // if(distanciaX == 0 && distanciaY == 0)
        //{
       //     Player.ApplayDamage()
        //}
        if (distanciaX < distanciaY ) // se a distancia de x < y, então deve andar em X
        {
            MovimentacaoX();
        }
        else // senão andar em y
        {
            MovimentacaoY();
        }
    }

    public void MovimentacaoX()
    {
        if (Hero != null)
        {
                    if (Hero.transform.position.x < this.transform.position.x)
                    {
                        transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                    }
                    else if (Hero.transform.position.x > this.transform.position.x)
                    {
                        transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                    }
                
            
        }
    }
    public void MovimentacaoY()
    {
        if (Hero != null)
        {
            
                if (Hero.transform.position.y < this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, -vel * Time.deltaTime));
                }
                else if (Hero.transform.position.y > this.transform.position.y)
                {
                    transform.Translate(new Vector2(0, vel * Time.deltaTime));
                }
            
        }
    }
}


