using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setas1 : MonoBehaviour {

    public Text sigaSeta;
    // Use this for initialization
    void Start () {
		
	}
	    
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player"){

            sigaSeta.text = "Entre na porta e fale com o treinador";
            Destroy(this.gameObject);
        }
    }
}
