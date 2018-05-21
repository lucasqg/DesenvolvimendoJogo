using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItensController : MonoBehaviour {

    public ItensBase item;
    public static PlayerItensController instance;
    // Use this for initialization
    public SlotEquipavel elmo, peito, calça, luva, bota, arma, anel1, anel2, colar;
    public SlotEquipavel selectedSlot;
    public GameObject buttonEquip;
    public GameObject optionOnSelect;
    public ContoleDeInventario slotInventario;
    void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    

    public void EquipItem()
    {
        if (item.canEquip)
        {
            if(item.nameItem == "Espada")
            {
                SlotArma();
                arma.ActiveIcon();
            }
            if(item.nameItem == "elmo")
            {
                SlotElmo();
                elmo.ActiveIcon();
            }
            if (item.nameItem == "peito")
            {
                SlotPeito();
                peito.ActiveIcon();
            }
            if (item.nameItem == "calça")
            {
                SlotCalça();
                calça.ActiveIcon();
            }
            if (item.nameItem == "luva")
            {
                SlotLuva();
                luva.ActiveIcon();
            }
            if (item.nameItem == "bota")
            {
                SlotBota();
                bota.ActiveIcon();
            }

        }
    }

    public void SlotArma()
    {
        arma.currentItem = item;
    }

    public void SlotElmo()
    {
        elmo.currentItem = item; 

    }
    public void SlotPeito()
    {
        peito.currentItem = item;
    }
    public void SlotCalça()
    {
        calça.currentItem = item;
    }
    public void SlotLuva()
    {
        luva.currentItem = item;
    }
    public void SlotBota()
    {
        bota.currentItem = item;
    }

    public void EquipeItem() // equipa  o item? !
    {
        if (selectedSlot.currentItem.canEquip)
        {
            ItensBase item = selectedSlot.currentItem;
            // retirando o item equipavel
            slotInventario.AddItemToInventory(item);
            //retira o item do inventario
            item = null;
            
        }
    }
}
