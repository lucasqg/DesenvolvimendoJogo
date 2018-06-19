using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vendedor : NpcBase{
    public GameObject inventarioVendedor;
    public GameObject inventarioPlayer;
    public GameObject inventarioEquipavel;
    public InventarioVendedor inventario;
    public Transform vendedor;
    public ItensBase potionHP1, potionHP2, potionHP3, potionStamina1, potionStamina2, potionStamina3, potionMana1, potionMana2, potionMana3, pergaminho;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F) && (!inventarioPlayer.activeSelf))
            {
               
                inventarioVendedor.SetActive(true);
                inventarioPlayer.SetActive(true);
                inventarioEquipavel.SetActive(false);
                inventario.AdicionarItemUtilizavel();

                // código para abertura do vendedor
            }
            else if((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Escape)) &&(inventarioPlayer.activeSelf))
            {
                inventarioVendedor.SetActive(false);
                inventarioEquipavel.SetActive(true);
                //inventario.RemoveItensDoIventario();
                inventarioPlayer.SetActive(false);
                // código para abertura do vendedor
            }
            /*if (collision.GetComponent<ItensBase>())
            {
                inventario.AddItemToInventory(collision.GetComponent<ItensBase>());
            }*/
        }
        
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
       /* if (collision.GetComponent<ItensBase>())
        {
            inventario.AddItemToInventory(collision.GetComponent<ItensBase>());
        }*/
    }


}

