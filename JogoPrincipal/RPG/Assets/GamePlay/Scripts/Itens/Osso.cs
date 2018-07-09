using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osso : ItensBase {

	// Use this for initialization
	void Start () {
        identificacao = 22;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // ao player chegar proximo a moeda, então vai diretamente para o inventario do player;
            ContoleDeInventario.instance.AddItemToInventory(this);
        }
    }
    public override void TxtAtributos()
    {
        UIController.instancer.atributosItens.text = "Osso da perna do Sr. Esqueleto. Parece ideal para transformar em carvão.";
    }
}
