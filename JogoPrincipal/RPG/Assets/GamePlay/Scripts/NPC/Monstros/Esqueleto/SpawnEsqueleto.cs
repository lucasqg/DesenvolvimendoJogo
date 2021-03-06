﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEsqueleto : MonoBehaviour {
    public int tempoSpawn;
    public List<int> contadorSpawn;
    public List<float> x, y;
    public List<GameObject> monster;
    public int tamanho;
    public GameObject esqueleto;
    public List<GameObject> conjuntoDeMonstros;
    public int chamaSpawn = 0;
    
    void Start()
    {
        tempoSpawn = 700;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Spawn();
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
       // if(collision.tag == "Player")
          //  VerificaVida();
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            monster.Clear();
            chamaSpawn = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void Spawn()
    { if (chamaSpawn == 0)
        {
            for (int i = 0; i < tamanho; i++)
            {
                GameObject monstro = Instantiate(esqueleto, new Vector3(x[i], y[i], -1), Quaternion.identity);
                monster.Add(monstro);
            }
        }
        chamaSpawn = 1;
    }

    public void VerificaVida()
    {
        for (int i = 0; i < tamanho; i++)
        {
            contadorSpawn[i] += 1;
        }
        for (int i = 0; i< tamanho; i ++)
        {
            if(monster[i].activeSelf == false && contadorSpawn[i] >= tempoSpawn){
                monster[i]=(Instantiate(esqueleto, new Vector3(x[i], y[i], -1), Quaternion.identity));
            }
        }
    }
    
}
