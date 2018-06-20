using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carroceiro : NpcBase {
    public Transform DeslocCarroceiro;
    private bool inimigo = false;
    private float vel = 1.5f;
    public Animator anim;

    private int i=2;
    private float positionX;
    private float positionY;

    
    // npc carroceiro é responsavel pela missão de ir de um lugar até outro sem morrer!
    public int tipoDeMissao = 0;

	// Use this for initialization
	public override void Start () {
       
        Inicialization();
    }
	
	// Update is called once per frame
	public override void Update () {
        DestroiMonster();   // testa se o monstro deve morrer
        DeslocamentoDeMissao();
    }

    private void restorePosition(int op)
    {
        switch (op)
        {
            case 1:
                positionX = 17f;
                positionY = -43.29f;
                break;
            case 2:
                positionX = 25.11f;
                positionY = -41.25f;
                break;
            case 3:
                positionX = 35.22f;
                positionY = -40.56f;
                break;
            case 4:
                positionX = 39.67f;
                positionY = -60.05f;
                break;
            case 5:
                positionX = 43.21f;
                positionY = -67.41f;
                break;
            case 6:
                positionX = 50.57f;
                positionY = -70.15f;
                break;
            case 7:
                positionX = 46.18f;
                positionY = -78.88f;
                break;
            default:
                break;
        }

    }
    public void DeslocamentoDeMissao()
    {
        if (!inimigo) // se não houver um inimigo então ele deve caminhar
        {
            
            if(positionX == 0 && positionY == 0)
            {
                restorePosition(i);
                i++;
            }
            if(this.transform.position.x == positionX && this.transform.position.y == positionY)
            {
                restorePosition(i);
                i++;
            }   
            else
            {
                Movimentacao();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "monster")
        {
            inimigo = true; // tem um inimigo no raio de visão
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "monster")
        {
            inimigo = false; // saiu o inimigo do campo de visão, entao deve caminhar
        }
    }


    public void Movimentacao()
    {
        float distanciaX = positionX - this.transform.position.x;
        float distanciaY = positionY - this.transform.position.y;

        distanciaX = VerificaModulo(distanciaX);
        distanciaY = VerificaModulo(distanciaY);

        if(distanciaX < 0.05f && distanciaY < 0.05f)
        {
            restorePosition(i);
            i++;
        }
        if (distanciaX > distanciaY)
        {
            if (positionX < this.transform.position.x)
            {
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
            }
            else if (positionX > this.transform.position.x)
            {
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
            }
        }
        else
        {
            if (positionY < this.transform.position.y)
            {
                transform.Translate(new Vector2(0, -vel * Time.deltaTime));
            }
            else if (positionY > this.transform.position.y)
            {
                transform.Translate(new Vector2(0, vel * Time.deltaTime));
            }
        }

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
}
