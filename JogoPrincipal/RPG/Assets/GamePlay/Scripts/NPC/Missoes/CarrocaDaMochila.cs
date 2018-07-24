using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrocaDaMochila : MonoBehaviour {
    public bool ativarMissao;
    public GameObject mochila;
    public FalaNpcs Mestre;
    public Text texto;
    public bool mochilaEncontrada;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (ativarMissao)
            {
                GameObject mochileti = Instantiate(mochila, new Vector3(-242.99f, -64.56f, -1.12f), Quaternion.identity);
                collision.GetComponent<PlayerBehaviour>().SetNivelDeMissao("missaoPrincipal");
                mochilaEncontrada = true;
                ativarMissao = false;
            }
        }
    }
}
