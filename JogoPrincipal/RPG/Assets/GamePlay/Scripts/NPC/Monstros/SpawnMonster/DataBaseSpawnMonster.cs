using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseSpawnMonster : MonoBehaviour {

    public GameObject morcego;
    public List<GameObject> conjuntoDeMonstros;
    public int quantidadeDeMonstros;
    public List<float> positionX, positionY;
    public bool activeMonster = false;
    public bool desactive = true;

	// Use this for initialization

	void Start () {
        desactive = true;

    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (activeMonster)
        {
            ChecarMonstros();
        }
        else if(!activeMonster && desactive)
        {
            desactive = false;
            for (int i = 0; i < quantidadeDeMonstros; i++)
            {
                Destroy(conjuntoDeMonstros[i]); //destroi todos monstros quando o personagem sai do triger
            }
        }
        */
    }

    public void ChecarMonstros()
    {
        for(int i = 0; i < quantidadeDeMonstros; i++)
        {
            CheckExist(positionX[i], positionY[i], morcego, conjuntoDeMonstros[i]);
        }
    }


    public GameObject SpawnMonster(float x, float y, GameObject monstro)
    {
        GameObject monster = Instantiate(monstro, new Vector3(x, y, -1), Quaternion.identity);
        return monster;
    }

                                   //(X, Y, Tipo do monstro, Objeto monstro criado)
    public GameObject CheckExist(float x, float y, GameObject monstro, GameObject monster)
    {
        if (monster != null) // verifica se o monstro existe
        {
            return monster;
        }
        else                //se nao existir então instancia ele        
        {
            GameObject bixo = Instantiate(monstro, new Vector3(x, y, -1), Quaternion.identity);
            return bixo;
        }
    }

    public void Spawn()//spawn de todos mobs
    {

        for(int i=0; i<quantidadeDeMonstros ; i++)
        {
            conjuntoDeMonstros.Add(SpawnMonster(positionX[i], positionY[i], morcego));
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Carroceiro")
        {
            activeMonster = true;
            if (desactive)
            {
                Spawn();
                desactive = false;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Carroceiro")
        {
            activeMonster = false;
            desactive = true;
            for (int i = 0; i < quantidadeDeMonstros; i++)
            {
                conjuntoDeMonstros[i].GetComponent<NpcBase>().Destroi(); //destroi todos monstros quando o personagem sai do trigger
                
            }
            conjuntoDeMonstros.Clear();
            desactive = true;
        }
    }
}
