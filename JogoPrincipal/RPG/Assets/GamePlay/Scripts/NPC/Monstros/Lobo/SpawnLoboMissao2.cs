using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoboMissao2 : MonoBehaviour {

    public bool iniciarMissao = true;
    public int contadorDeTempo1, contadorDeTempo2, contadorDeTempo3 = 0;
    public int tempoSpawn1, tempoSpawn2, tempoSpawn3;
    public GameObject lobo;

    public List<float> positionX, positionY;
    public List<GameObject> conjuntoDeMonstros;
    // Use this for initialization
    void Start () {
        tempoSpawn1 = 1500;
        tempoSpawn2 = 1000;
        tempoSpawn3 = 700;
    }
	
	// Update is called once per frame
	void Update () {

        contadorDeTempo1 += 1; // inicia um contador de tempo para dar spawn nos mobs
        contadorDeTempo2 += 1;
        contadorDeTempo3 += 1;
        if (iniciarMissao == true)
        {
            // inicia spawn
            InicioSpawn();
        }
	}

    public void InicioSpawn()
    {
        if(contadorDeTempo1 >= tempoSpawn1)
        {
            contadorDeTempo1 = 0; //reseta o contador para reiniciar o spawn
            tempoSpawn1 -= 100;
            conjuntoDeMonstros.Add(SpawnMonster(positionX[0], positionY[0], lobo));

        }
        if (contadorDeTempo2 >= tempoSpawn2)
        {
            contadorDeTempo2 = 0; //reseta o contador para reiniciar o spawn
            tempoSpawn2 -= 150;
            conjuntoDeMonstros.Add(SpawnMonster(positionX[1], positionY[1], lobo));

        }
        if (contadorDeTempo3 >= tempoSpawn3)
        {
            contadorDeTempo3 = 0; //reseta o contador para reiniciar o spawn
            tempoSpawn3 += 100;
            conjuntoDeMonstros.Add(SpawnMonster(positionX[2], positionY[2], lobo));

        }
    }


    public void FimDeMissão()
    {
        conjuntoDeMonstros.Clear();

    }
    public GameObject SpawnMonster(float x, float y, GameObject monstro)
    {
        GameObject monster = Instantiate(monstro, new Vector3(x, y, -1), Quaternion.identity);
        return monster;
    }
}
