using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioVendedor : MonoBehaviour {
    public List<SlotsVendedor> InventarioSlots;
    public static InventarioVendedor instance;
    public int maxInventarioSlots = 20;
    public SlotsVendedor slotPrefab;
    public Transform itensGrid;
    public SlotsVendedor selectedSlot;
    public GameObject buttonComprar, buttonUse, buttonEquip, buttonRemove;
    public GameObject buttoncompras;
    private bool testePrimeiraVez = false;
    public Transform playerPosition;
    
    private PlayerBehaviour player;

    public ContoleDeInventario slots, slotDeVerificação;
    public int quantidadeDeMoedasNecessarias = 0;
    public ItensBase potionsHPb, potionsStaminab, potionsManab, Pergaminho;
    public ItensBase potionsHPm, potionsStaminam, potionsManam;
    public ItensBase potionsHPmm, potionsStaminamm, potionsManamm;
    private void Start()
    {

        for (int i = 0; i < 10; i++)
        {
            GameObject tempSlot = Instantiate(slotPrefab.gameObject);
            tempSlot.transform.SetParent(itensGrid, false);
            InventarioSlots.Add(tempSlot.GetComponent<SlotsVendedor>());
        }
    }

    private void Update()
    {
        if (selectedSlot != null && selectedSlot.currentItem != null)
        {
            buttonComprar.SetActive(true);
            buttoncompras.SetActive(true);
            buttonEquip.SetActive(false);
            buttonRemove.SetActive(false);
            buttonUse.SetActive(false);
        }
        else
        {

            buttonEquip.SetActive(true);
            buttonRemove.SetActive(true);
            buttonUse.SetActive(true);
            buttoncompras.SetActive(false);
            buttonComprar.SetActive(false);
        }
    }
    public void AddItemToInventory(ItensBase item) // adiciona um item ao inventario, testa se é Stack ou não.
    {                                                                   // caso remover = true, entao remove o item e nao adiciona.
        bool foundItem = false;
        SlotsVendedor slotVazio = proxSlotVazio();
        if (item.isStacklabe)
        {
            foreach (SlotsVendedor slot in InventarioSlots)
            {
                if (slot.currentItem != null && slot.currentItem.nameItem == item.nameItem)
                {
                    slot.currentItem.addItem();
                    foundItem = true;
                    Destroy(item.gameObject);
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

        item.gameObject.SetActive(false);

    }

    private SlotsVendedor proxSlotVazio() //aponta o proximo slot vazio
    {
        SlotsVendedor slotToReturn = null;
        foreach (SlotsVendedor slot in InventarioSlots)
        {
            if (slot.currentItem == null)
            {
                slotToReturn = slot;
                break;
            }
        }
        return slotToReturn;
    }

    private void OnEnable() //Quando um objeto do inventario for selecionado, entao os botoes devem aparecer.
    {
        selectedSlot = null;
       
        buttonComprar.SetActive(true);

    }

    public void AdicionarItemUtilizavel()
    {
        if (testePrimeiraVez == false)
        {
            testePrimeiraVez = true;
            AddItemToInventory(potionsHPb);
            AddItemToInventory(potionsHPm);
            AddItemToInventory(potionsHPmm);
            AddItemToInventory(potionsManab);
            AddItemToInventory(potionsManam);
            AddItemToInventory(potionsManamm);
            AddItemToInventory(potionsStaminab);
            AddItemToInventory(potionsStaminam);
            AddItemToInventory(potionsStaminamm);
            AddItemToInventory(Pergaminho);
        }
    }
    public void AdicionarItensEquipaveis()
    {

    }
    
    public void RemoveItensDoIventario()
    {
        InventarioSlots.Clear();
    }

    public void comprarObjeto()
    {
        //verifica no inventario do player se existe o objeto moeda;
        foreach (SlotInventarioBehaviour slot in slots.InventarioSlots)
        {
           
            if (slot.currentItem.nameItem == "Moeda")
            {
                // verifica se o player possui a quantidade de moedas necessaria
                if (slot.currentItem.getAmount() >= quantidadeDeMoedasNecessarias)
                {
                    Debug.Log(quantidadeDeMoedasNecessarias.ToString());
                    // remove a quantidade de moedas do inventairo
                    slot.currentItem.removeAmount(quantidadeDeMoedasNecessarias);
                    // metodo que adiciona o item comprado ao inventario
                    AdicionarItemAoInventario();
                }
            }
        }
    }
    public void AtualizaSlotsAposCompra()
    {
        foreach (SlotInventarioBehaviour slot in slots.InventarioSlots)
        {
            slot.SetupSlot();
        }
    }
    public void AdicionarItemAoInventario()
    {
        foreach (SlotInventarioBehaviour slot in slots.InventarioSlots)
        {
            if (slot.currentItem == null)
            {
                GameObject objeto = Instantiate(selectedSlot.currentItem.prefab, transform.position, transform.rotation, playerPosition);
                objeto.SetActive(true);

                if (objeto.activeSelf) // só adiciona o objeto ao inventario caso ele apareça na cena
                {
                    objeto.GetComponent<ItensBase>().AdicionaDiretamenteAoInventario();
                    //objeto.SetActive(true);
                    selectedSlot.isSelected = false;
                    selectedSlot = null;
                    AtualizaSlotsAposCompra();
                }
                
                
                /*slots.proxVazio().currentItem = selectedSlot.currentItem;
               
                selectedSlot.currentItem = null;
                selectedSlot.isSelected = false;
                selectedSlot = null;*/

                // AddItemToInventory(selectedSlot.currentItem);        

                //slot.currentItem = selectedSlot.currentItem;
                //selectedSlot.currentItem.removeAmount(99);
                //slot.currentItem.removeAmount(1);
                // slot.currentItem.RemoveItem();
                break;
            }
        }
    }
}
