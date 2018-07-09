using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CientistaLouco : MonoBehaviour {

    private PlayerBehaviour player;
    public FalaNpcs mestre;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            foreach (SlotInventarioBehaviour slot in ContoleDeInventario.instance.InventarioSlots)
            {
                if (slot.currentItem != null && slot.currentItem.identificacao == 2)
                {
                    slot.currentItem.DestroiItem();
                    mestre.pergaminhoEntregue = true;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
