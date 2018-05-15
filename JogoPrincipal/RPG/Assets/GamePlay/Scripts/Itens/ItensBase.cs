using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItensBase : MonoBehaviour {
    public string nameItem;
    public Sprite icon;
    public bool isStacklabe;
    protected int amount = 1 ;
    private bool canTakeItem;
    public bool canEquip;
    public SlotInventarioBehaviour slot;
   


    public void addItem(int amountToAdd = 1)
    {
        amount += amountToAdd;
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
    public void TxtAtributosLimpa()
    {
        UIController.instancer.atributosItens.text = "";
    }
}
