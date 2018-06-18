using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotsVendedor : MonoBehaviour {
    public Text nameObject;
    public Text amount;
    public Image icon;
    public ItensBase currentItem;
    public Text preço;
    public SlotInventarioBehaviour inventario;

	
	// Update is called once per frame
	void Update () {
        //atualiza os icones e nomes do slot
        if (currentItem != null)
        {
            icon.sprite = currentItem.icon;
            nameObject.text = currentItem.nameItem;
            amount.text = currentItem.getAmount().ToString();
        }
	}
    /*public void comprarObjeto()
    {
        //verifica no inventario do player se existe o objeto moeda;
        foreach (SlotInventarioBehaviour slot in slots.InventarioSlots)
        {
            if (slot.currentItem == moeda)
            {
                // verifica se o player possui a quantidade de moedas necessaria
                if (slot.currentItem.getAmount() <= quantidadeDeMoedasNecessarias)
                {
                    // remove a quantidade de moedas do inventairo
                    slot.currentItem.removeAmount(quantidadeDeMoedasNecessarias);
                    // metodo que adiciona o item comprado ao inventario
                    AdicionarItemAoInventario();
                }
            }
        }
    }
    public void AdicionarItemAoInventario()
    {
        foreach (SlotInventarioBehaviour slot in slots.InventarioSlots)
        {
            if (slot.currentItem == null)
            {
                slot.currentItem = currentItem;
                slot.currentItem.RemoveItem();
                break;
            }
        }
    }*/
}
