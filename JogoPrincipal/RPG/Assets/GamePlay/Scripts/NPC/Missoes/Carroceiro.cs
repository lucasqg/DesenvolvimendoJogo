using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carroceiro : NpcBase {
    public Transform DeslocCarroceiro;
    private bool inimigo = false;
    private float vel = 1f;
    public Animator anim;
    public GameObject carroceiroFalas;

    private int i=2;
    private float positionX;
    private float positionY;

    
    // npc carroceiro é responsavel pela missão de ir de um lugar até outro sem morrer!
    public int tipoDeMissao = 0;

	// Use this for initialization
	public override void Start () {
        totalLife = 30;
        defesaTotal = 2;

    }
	
	// Update is called once per frame
	public override void Update () {
        //DestroiMonster();   // testa se o monstro deve morrer
        DeslocamentoDeMissao();
        TestVida();             // testa se o monstro deve morrer e remove reputação caso morra
    }

    private void restorePosition(int op)
    {
        switch (op)
        {
            case 1:
                positionX = -199.45f;
                positionY = -225.28f;
                break;
            case 2:
                positionX = -211.91f;
                positionY = -226.55f;
                break;
            case 3:
                //deve ser teleportado
                positionX = -121.04f;
                positionY = -63.41f;
                this.gameObject.transform.SetPositionAndRotation(new Vector2(positionX, positionY), Quaternion.identity);
                break;
            case 4:
                positionX = -123.76f;
                positionY =-62.4f;
                break;
            case 5:
                positionX = -135.89f;
                positionY = -62.19f;
                break;
            case 6:
                positionX = -135.89f;
                positionY = -36.35f;
                break;
            case 7:
                positionX = -166.53f;
                positionY = -36.35f;
                break;
            case 8:
                positionX = -166.53f;
                positionY = -30.57f;
                break;
            case 9:
                positionX = -208.73f;
                positionY = -30.57f;
                break;
            case 10:
                positionX = -208.73f;
                positionY = -24.76f;
                break;
            case 11:
                Chegada();
                Destroi();
                break;
            default:
                break;
        }

    }
    public void TestVida()
    {
        if (currentLife <= 2)
        {
            PlayerStatsController.AddReputation(-5);
            carroceiroFalas.SetActive(true);
            Destroi();
        }
    }
    public void Chegada()
    {
        if(this.transform.position.x == positionX && transform.position.y == positionY)
        {
            // adiciona 5 pontos de reputação
            PlayerStatsController.AddReputation(20);
            carroceiroFalas.SetActive(true);

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
            if(i == 11)
            {
                Chegada();
                Destroi();
            }
            else
            {
                Movimentacao();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Morcego" || collision.tag == "LoboDecomposto" || collision.tag == "LoboSelvagem" || collision.tag == "Esqueleto")
        {
            inimigo = true; // tem um inimigo no raio de visão
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Morcego" || collision.tag == "LoboDecomposto" || collision.tag == "LoboSelvagem" || collision.tag == "Esqueleto")
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
