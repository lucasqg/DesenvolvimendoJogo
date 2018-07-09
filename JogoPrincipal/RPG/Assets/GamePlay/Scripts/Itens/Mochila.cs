using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mochila : ItensBase {
    // Use this for initialization
    void Start()
    {
        identificacao = 23;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // ao player chegar proximo a mochila vai diretamente para o inventario do player;
            ContoleDeInventario.instance.AddItemToInventory(this);
        }
    }
    public override void TxtAtributos()
    {
        UIController.instancer.atributosItens.text = "Está mochila está dentro de uma mochila que é invisivel, mas tudo bem, sabemos que ela possui coisas de valor.";
    }
}
