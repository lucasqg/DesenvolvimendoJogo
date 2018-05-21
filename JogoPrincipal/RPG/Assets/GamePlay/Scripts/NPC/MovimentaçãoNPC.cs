using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaçãoNPC : MonoBehaviour {

    private float vel = 1.0f;
    public Transform Hero;
    private bool liberaPer = true;
    private float distancia;
    private bool face = true;
    private Animator anim;
    private bool vivo = true;
    private Transform monster;
    private List<Transform> monstros;
    public PolygonCollider2D poligon;
    public BoxCollider2D boxx;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        monster = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        MovimentacaoX();
        MovimentacaoY();
    }

    public void OnTriggerEnter2D(Collider2D outro)
    {
        // após o personagem entrar na zona de visão do mob, ele se deslocará até ele, caso o mob seja um monstro;
        if (outro.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Morrendo", true);
            vivo = false;
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

    public void MovimentacaoX()
    {
        if (monster.gameObject.CompareTag("Monster") == Hero.gameObject.CompareTag("Player"))
        {
            Destroy(Hero);
        }


        if (vivo == true)
        {

            distancia = Vector2.Distance(this.transform.position, Hero.transform.position);
            if ((Hero.transform.position.x > this.transform.position.x) && !face)
            {
                flip();
            }
            else if ((Hero.transform.position.x < this.transform.position.x) && face)
            {
                flip();
            }
            if ((liberaPer == true) && distancia > 1f)
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
        else
        {
            vel = 2f;
            transform.Translate(new Vector3(0, -vel * Time.deltaTime, 0));

            if (transform.position.y < -5)
            {
                Destroy(monster.gameObject);
            }
        }
    }
    public void MovimentacaoY()
    {
        if (monster.gameObject.CompareTag("Monster") == Hero.gameObject.CompareTag("Player"))
        {
            Destroy(Hero);
        }


        if (vivo == true)
        {

            distancia = Vector2.Distance(this.transform.position, Hero.transform.position);
            if ((Hero.transform.position.y > this.transform.position.y) && !face)
            {
                flip();
            }
            else if ((Hero.transform.position.y < this.transform.position.y) && face)
            {
                flip();
            }
            if ((liberaPer == true) && distancia > 1f)
            {
                if (Hero.transform.position.y < this.transform.position.y)
                {
                    transform.Translate(new Vector2(0,-vel * Time.deltaTime));
                }
                else if (Hero.transform.position.y > this.transform.position.y)
                {
                    transform.Translate(new Vector2(0,vel * Time.deltaTime));
                }
            }
        }
        else
        {
            vel = 2f;
            transform.Translate(new Vector3(0, -vel * Time.deltaTime, 0));

            if (transform.position.y < -5)
            {
                Destroy(monster.gameObject);
            }
        }
    }
}
