using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoboMissao2 : NpcBase {

    public bool iniciarMissao = true;
    public int contadorDeTempo1, contadorDeTempo2, contadorDeTempo3 = 0, contadorFimMissao;
    public int tempoSpawn1, tempoSpawn2, tempoSpawn3;
    public GameObject lobo;
    public CabeloVerde boneca;
    private bool Ativador;
    public List<float> positionX, positionY;
    public List<GameObject> conjuntoDeMonstros;
    // Use this for initialization
    void Start () {
        inicialization();
        iniciarMissao = true;
        tempoSpawn1 = 1500;
        tempoSpawn2 = 1500;
        tempoSpawn3 = 700;
        //linha de codigo abaixo ja está implementada no script da boneca
        //boneca = FindObjectOfType(typeof(CabeloVerde)) as CabeloVerde; // ENCONTRA O SCRIPT DA CABELO VERDE NA CENA
    }
    public override void DropItem()
    {

    }
    public override void DestroiMonster()
    {
        if (currentLife <= 0)
        {
            boneca.DerrotaDeMissao();//fim de missao
            Destroy(this.gameObject);
        }
    }
    public void inicialization()
    {
        danoTotal = 10;
        defesaTotal = 2;
        totalLife = 10;
        currentLife = totalLife;
        nameNPC = "Ovelha";;
    }

    // Update is called once per frame
    void Update () {
        if (Ativador)
        {
            contadorDeTempo1 += 1; // inicia um contador de tempo para dar spawn nos mobs
            contadorDeTempo2 += 1;
            contadorDeTempo3 += 1;
            contadorFimMissao += 1;
            if (contadorFimMissao >= 10000) //spawn 15X
                boneca.FinalizarMissao();
            if (iniciarMissao == true)
            {
                // inicia spawn
                InicioSpawn();
            }
            DestroiMonster();
        }
	}

    public void InicioSpawn()
    {
        if (tempoSpawn2 <= 0)
        {
            //FimDeMissão();
        }
        if (contadorDeTempo1 >= tempoSpawn1)
        {
            contadorDeTempo1 = 0; //reseta o contador para reiniciar o spawn
            tempoSpawn1 -= 50;
            conjuntoDeMonstros.Add(SpawnMonster(positionX[0], positionY[0], lobo));

        }
        if (contadorDeTempo2 >= tempoSpawn2 && tempoSpawn2 >= -100)
        {
            contadorDeTempo2 = 0; //reseta o contador para reiniciar o spawn
            tempoSpawn2 -= 30;
            conjuntoDeMonstros.Add(SpawnMonster(positionX[1], positionY[1], lobo));

        }
        if (contadorDeTempo3 >= tempoSpawn3)
        {
            contadorDeTempo3 = 0; //reseta o contador para reiniciar o spawn
            tempoSpawn3 += 200;
            conjuntoDeMonstros.Add(SpawnMonster(positionX[2], positionY[2], lobo));

        }
    }


    public void FimDeMissão()
    {
        conjuntoDeMonstros.Clear();
        boneca.FinalizarMissao();
    }
    public GameObject SpawnMonster(float x, float y, GameObject monstro)
    {
        GameObject monster = Instantiate(monstro, new Vector3(x, y, -1), Quaternion.identity);
        monster.GetComponent<MovimentacaoLobo>().LoboDeMissao = true;
        monster.GetComponent<MovimentacaoLobo>().bandeira = this.gameObject;
        monster.GetComponent<MovimentacaoLobo>().perseguirBandeira();
        monster.transform.parent = this.transform;
        return monster;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Ativador = true;
            Destroy(this.GetComponent<CircleCollider2D>());
        }
    }
}
