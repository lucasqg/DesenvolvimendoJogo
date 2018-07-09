using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItensBase : MonoBehaviour {
    public int identificacao;
    public string nameItem;
    public Sprite icon;
    public bool isStacklabe;
    protected int amount = 1 ;
    private bool canTakeItem;
    public bool canEquip;
    public SlotInventarioBehaviour slot;
    public SlotEquipavel slotEkp;
    public SlotsVendedor slot1;
    public GameObject prefab;
    public int valorDoItem = 0;

    public int GetId()
    {
        return identificacao;
    }
    public void InstantiatePrefab()
    {
        prefab = gameObject;
    }
    public void addItem(int amountToAdd = 1)
    {
        amount += amountToAdd;
    }
    public void AmountSet(int amountToAdd)
    {
        amount += amountToAdd;
    }

    public void DestroiItem()
    {
        Destroy(gameObject);
    }

    public void RemoveItem(int amountToRemove = 1)
    {
        amount -= amountToRemove;
        if(amount <= 0)
        {
            Destroy(gameObject);
        }
    }
    public int getAmount()
    {
        return amount;
    }
    public void removeAmount(int amountNew)
    {
        amount -= amountNew;
    }

    public void Use()
    {
        AfterUse();
    }

    public virtual void AfterUse()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTakeItem)
        {
            ContoleDeInventario.instance.AddItemToInventory(this);
        }

    }

    public void AdicionaDiretamenteAoInventario()
    {
        ContoleDeInventario.instance.AddItemToInventory(this, true);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            canTakeItem = true;
            UIController.instancer.ShowMessageTakeItem();
        }
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canTakeItem = false;
            
        }
    }
    public void NaoUtilizavel() // mostra a mensagem de nao utilizavel
    {
        UIController.instancer.naoUtilizavel = true;
        UIController.instancer.ShowMessageTakeItem();
        UIController.instancer.naoUtilizavel = false;
    }
    public virtual void TxtAtributos()
    {

    }
    public virtual void StatusArma()
    {
        
    }
    public virtual string TipoDeArmadura()
    {
        return "notArmadura";
    }
    public void TxtAtributosLimpa()
    {
        UIController.instancer.atributosItens.text = "";
    }
}
