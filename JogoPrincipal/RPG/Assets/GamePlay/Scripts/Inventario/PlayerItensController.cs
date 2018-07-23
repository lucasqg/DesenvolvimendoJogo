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
    public PlayerBehaviour player;
    public GameObject teste;
    void Start () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
    }
    
    public void AddEquipSave(GameObject ObjetoEquipavel)
    {
            item = ObjetoEquipavel.GetComponent<ItensBase>();
            this.EquipItem();
            item.slot.SetupSlot();
            item = null;
    }

    public void EquipItem()
    {
        if (item.canEquip)
        {
            if(item.nameItem == "Espada")
            {
                SlotArma();
                arma.ActiveIcon();
                arma.currentItem.StatusArma();
            }
            if(item.nameItem == "elmo")
            {
                SlotElmo();
                elmo.ActiveIcon();
                elmo.currentItem.StatusArma();
            }
            if (item.nameItem == "peito")
            {
                SlotPeito();
                peito.ActiveIcon();
                peito.currentItem.StatusArma();
            }
            if (item.nameItem == "calça")
            {
                SlotCalça();
                calça.ActiveIcon();
                calça.currentItem.StatusArma();
            }
            if (item.nameItem == "luva")
            {
                SlotLuva();
                luva.ActiveIcon();
                luva.currentItem.StatusArma();
            }
            if (item.nameItem == "bota")
            {
                SlotBota();
                bota.ActiveIcon();
                bota.currentItem.StatusArma();
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
           // slotInventario.selectedSlot.SetupSlot();
            //retira o item do inventario
            item = null;
        }
    }
}
