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
    public GameObject buttonComprar;
    public GameObject buttoncompras;
    private PlayerBehaviour player;
        


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
            buttoncompras.SetActive(false);
            
        }
        else
        {
            buttoncompras.SetActive(false);
        }
    }
    public void AddItemToInventory(ItensBase item) // adiciona um item ao inventario, testa se é Stack ou não.
    {
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

    public void AdicionarItemUtilizaveis()
    {
        for (int i = 0; i < 100; i++)
        {
            AddItemToInventory(potionsHPb);
        }
        for (int i = 0; i < 100; i++)
        {
            AddItemToInventory(potionsHPm);
        }
        for (int i = 0; i < 100; i++)
        {
            AddItemToInventory(potionsHPmm);
        }
        for (int i = 0; i < 100; i++)
        {
            AddItemToInventory(potionsManab);
        }
        for (int i = 0; i < 100; i++)
        {
            AddItemToInventory(potionsManam);
        }
        for (int i = 0; i < 100; i++)
        {
            AddItemToInventory(potionsManamm);
        }
        for (int i = 0; i < 100; i++)
        {
            AddItemToInventory(potionsStaminab);
        }
        for (int i = 0; i < 100; i++)
        {
            AddItemToInventory(potionsStaminam);
        }
        for (int i = 0; i < 100; i++)
        {
            AddItemToInventory(potionsStaminamm);
        }
        for (int i = 0; i < 100; i++)
        {
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
}
