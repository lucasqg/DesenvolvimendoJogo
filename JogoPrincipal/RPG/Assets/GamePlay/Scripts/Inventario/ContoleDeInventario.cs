using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ContoleDeInventario : MonoBehaviour
{
    public List<SlotInventarioBehaviour> InventarioSlots;
    public static ContoleDeInventario instance;
    public int maxInventarioSlots=20;
    public SlotInventarioBehaviour slotPrefab;
    public Transform itensGrid;
    public SlotInventarioBehaviour selectedSlot;
    public GameObject optionOnSelect;
    public GameObject buttonUse;
    public GameObject buttonEquip;
    public GameObject buttonComprar;
    public GameObject buttonRemover;
    private PlayerBehaviour player;
    public PlayerItensController Equipavel;

    void Start()
    {
        instance = this;
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;

        for(int i =0; i< maxInventarioSlots; i++)
        {
            GameObject tempSlot = Instantiate(slotPrefab.gameObject);
            tempSlot.transform.SetParent(itensGrid, false);
            InventarioSlots.Add(tempSlot.GetComponent<SlotInventarioBehaviour>());  
        }
    }

   
    void Update()
    {
        if(selectedSlot != null && selectedSlot.currentItem!=null)
        {
            optionOnSelect.SetActive(true);
            if (selectedSlot.currentItem.canEquip)
            {
                buttonUse.SetActive(false);
                buttonEquip.SetActive(true);
                buttonComprar.SetActive(false);
                buttonRemover.SetActive(true);
                
            }
            else
            {
                buttonRemover.SetActive(true);
                buttonEquip.SetActive(false);
                buttonUse.SetActive(true);
                buttonComprar.SetActive(false);
            }
        }
        else
        {
            optionOnSelect.SetActive(false);
        }
    }

    public void VerificaPotionHP()
    {
        foreach (SlotInventarioBehaviour slot in InventarioSlots)
        {
            if (slot.currentItem.nameItem == "Poção Vida Grande" || slot.currentItem.nameItem == "Poção Vida Média" || slot.currentItem.nameItem == "Poção Vida Pequena")
            {
                slot.currentItem.Use(); //usa o item e o retira do inventario.
                slot.SetupSlot();
                break;
            }

        }
    }
    public void VerificaPotionStamina()
    {
        foreach (SlotInventarioBehaviour slot in InventarioSlots)
        {
            if (slot.currentItem.nameItem == "Poção Stamina Grande" || slot.currentItem.nameItem == "Poção Stamina Média" || slot.currentItem.nameItem == "Poção Stamina Pequena")
            {
                slot.currentItem.Use(); //usa o item e o retira do inventario.
                slot.SetupSlot();
                break;
            }

        }
    }

    public void AddItemToInventory(ItensBase item, bool delete = false) // adiciona um item ao inventario, testa se é Stack ou não.
    {
        bool foundItem = false;
        SlotInventarioBehaviour slotVazio = proxSlotVazio();
        if (item.isStacklabe )
        {
            foreach(SlotInventarioBehaviour slot in InventarioSlots)
            {
                if(slot.currentItem!=null && slot.currentItem.nameItem == item.nameItem)
                {
                    slot.currentItem.addItem();
                    foundItem = true;
                    if (delete)
                    {
                        item.DestroiItem();
                    }
                }
            }
            if (!foundItem && slotVazio !=null)
            {
                slotVazio.currentItem = item;
            }
        }
        else if(slotVazio != null)
        {
            slotVazio.currentItem = item;
        }
        if (!delete)
        {
            item.gameObject.SetActive(false);
        }
    }


    public void AddItemToInventoryPermanent(ItensBase item, bool delete = false) // adiciona um item ao inventario, testa se é Stack ou não.
    {
        bool foundItem = false;
        SlotInventarioBehaviour slotVazio = proxSlotVazio();
        if (item.isStacklabe)
        {
            foreach (SlotInventarioBehaviour slot in InventarioSlots)
            {
                if (slot.currentItem != null && slot.currentItem.nameItem == item.nameItem)
                {
                    slot.currentItem.addItem();
                    foundItem = true;
                }
            }
            if (!foundItem && slotVazio != null)
            {
                slotVazio.currentItem = item;
            }
        }
        else if (slotVazio != null)
        {
            slotVazio.currentItem = item;
        }
    }

    public SlotInventarioBehaviour proxVazio()
    {
        return proxSlotVazio();
    }
    private SlotInventarioBehaviour proxSlotVazio() //aponta o proximo slot vazio
    {
        SlotInventarioBehaviour slotToReturn = null;
        foreach (SlotInventarioBehaviour slot in InventarioSlots)
        {
            if(slot.currentItem == null)
            {
                slotToReturn =  slot;
                break;
            }
        }
        return slotToReturn;
    }

    private void OnEnable() //Quando um objeto do inventario for selecionado, entao os botoes devem aparecer.
    {
        selectedSlot = null;
        optionOnSelect.SetActive(false);
        buttonEquip.SetActive(true);
        buttonUse.SetActive(true); 

    }

    public void UseItem()
    {
        if (selectedSlot.currentItem.nameItem == "Pergaminho")
        {
            selectedSlot.currentItem.Use();     //usa o item e o retira do inventario.
            selectedSlot.SetupSlot();           //atualiza o inventario e retira o icone
        }
        if (TestePVida())  //se for poção de vida, TODAS classes podem usar.
        {
            selectedSlot.currentItem.Use();     //usa o item e o retira do inventario.
            selectedSlot.SetupSlot();           //atualiza o inventario e retira o icone
        }
       else if(player.GetTypeChar() == TypeCharacter.Guerreiro)
        {
            if (TestePStamina())// se verdade guerreiro só pode usar poção de stamina
            {
                selectedSlot.currentItem.Use(); //usa o item e o retira do inventario.
                selectedSlot.SetupSlot();       //atualiza o inventario e retira o icone
            }
            else
            {
                selectedSlot.currentItem.NaoUtilizavel(); // msg de erro
            }
            
        }
        else if (player.GetTypeChar() == TypeCharacter.Bomber || player.GetTypeChar() == TypeCharacter.Pistoleiro)
        {       //bomber e pistoleiro só podem usar poção de mana

            if (TestePMana())
            {
                selectedSlot.currentItem.Use(); //usa o item e o retira do inventario.
                selectedSlot.SetupSlot(); //atualiza o inventario e retira o icone
            }
            else
            {
                selectedSlot.currentItem.NaoUtilizavel(); // msg de erro
            }
           
        }
        
               
    }

    

    public bool TestePMana() // teste poção de mana, verifica se o objeto a ser usado é mana
    {
        if (selectedSlot.currentItem.nameItem == "Poção Mana Grande" || selectedSlot.currentItem.nameItem == "Poção Mana Média" || selectedSlot.currentItem.nameItem == "Poção Mana Pequena")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool TestePVida() // teste para verificar se o objeto usado é vida
    {
        if (selectedSlot.currentItem.nameItem == "Poção Vida Grande" || selectedSlot.currentItem.nameItem == "Poção Vida Média" || selectedSlot.currentItem.nameItem == "Poção Vida Pequena")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool TestePStamina() // teste para verificar se o objeto usado é stamina
    {
        if (selectedSlot.currentItem.nameItem == "Poção Stamina Grande" || selectedSlot.currentItem.nameItem == "Poção Stamina Média" || selectedSlot.currentItem.nameItem == "Poção Stamina Pequena")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveItem() // remove o item do inventario e o dropa no chão
    {
        ItensBase item = selectedSlot.currentItem;
        item.gameObject.SetActive(true);
        item.transform.position = player.transform.position; // joga o item no chao na posição do personagem
        item.slot.currentItem = null;
        item.slot.SetupSlot();  // método para retirar o icone do inventario
        item.slot = null;
        
    }

    public void EquipeItem() // equipa  o item? !
    {
        if(selectedSlot.currentItem.canEquip)
        {
            ItensBase item = selectedSlot.currentItem;
            // coloca o item no equipavel, mas verifica se ja há um item ocupando o slot
            if (item.nameItem == "Espada")
            { 
                if(PlayerItensController.instance.arma.currentItem == null)
                {
                    PlayerItensController aux;
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                }
                else
                {
                    
                    PlayerItensController aux;
                    SlotEquipavel auxInventory = PlayerItensController.instance.arma;
                    AddItemToInventory(auxInventory.currentItem);
                    auxInventory.currentItem.StatusArmaD();
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                    
                }
            
            }
            if (item.nameItem == "elmo")
            {
                if (PlayerItensController.instance.elmo.currentItem == null)
                {
                    PlayerItensController aux;
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                }
                else
                {

                    PlayerItensController aux;
                    SlotEquipavel auxInventory = PlayerItensController.instance.elmo;
                    auxInventory.currentItem.StatusArmaD();
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                    AddItemToInventory(auxInventory.currentItem);
                }
            }
            if (item.nameItem == "peito")
            {
                if (PlayerItensController.instance.peito.currentItem == null)
                {
                    PlayerItensController aux;
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                }
                else
                {

                    PlayerItensController aux;
                    SlotEquipavel auxInventory = PlayerItensController.instance.peito;
                    auxInventory.currentItem.StatusArmaD();
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                    AddItemToInventory(auxInventory.currentItem);
                }
            }
            if (item.nameItem == "calça")
            {
                if (PlayerItensController.instance.calça.currentItem == null)
                {
                    PlayerItensController aux;
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                }
                else
                {

                    PlayerItensController aux;
                    SlotEquipavel auxInventory = PlayerItensController.instance.calça;
                    auxInventory.currentItem.StatusArmaD();
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                    AddItemToInventory(auxInventory.currentItem);
                }
            }
            if (item.nameItem == "luva")
            {
                if (PlayerItensController.instance.luva.currentItem == null)
                {
                    PlayerItensController aux;
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                }
                else
                {

                    PlayerItensController aux;
                    SlotEquipavel auxInventory = PlayerItensController.instance.luva;
                    auxInventory.currentItem.StatusArmaD();
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                    AddItemToInventory(auxInventory.currentItem);
                }
            }
            if (item.nameItem == "bota")
            {
                if (PlayerItensController.instance.bota.currentItem == null)
                {
                    PlayerItensController aux;
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                }
                else
                {

                    PlayerItensController aux;
                    SlotEquipavel auxInventory = PlayerItensController.instance.bota;
                    auxInventory.currentItem.StatusArmaD();
                    aux = Equipavel;
                    Equipavel.item = selectedSlot.currentItem;
                    Equipavel.EquipItem();
                    selectedSlot.currentItem = null;
                    item.slot.SetupSlot();
                    AddItemToInventory(auxInventory.currentItem);
                }
            }
        }
    }
}
