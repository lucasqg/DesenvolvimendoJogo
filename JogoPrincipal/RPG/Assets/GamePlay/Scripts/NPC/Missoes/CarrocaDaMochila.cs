using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrocaDaMochila : MonoBehaviour {
    public bool ativarMissao;
    public GameObject mochila;
    public Text texto;
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
                GameObject mochileti = Instantiate(mochila, new Vector3(this.gameObject.transform.position.x, -this.gameObject.transform.position.y, -1.12f), Quaternion.identity);
                texto.text = "Leve a mochila ao Mestre !";
            }
        }
    }
}
