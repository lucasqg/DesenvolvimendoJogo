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
    public InventarioVendedor inventario;
    public Image background;
    public Color unselectedColor;
    public Color selectedColor;
    public bool isSelected = false;
    public int quantidadeDeMoedasNecessarias=0;

    void Update () {
        //atualiza os icones e nomes do slot
        SetupSlot();
        //isSelected = InventarioVendedor.instance.selectedSlot == this;
        //background.color = isSelected ? selectedColor : unselectedColor;
    }

    private void Start()
    {
        inventario = FindObjectOfType(typeof(InventarioVendedor)) as InventarioVendedor;
       
    }
    public void SetupSlot()
    {
        
        if (currentItem != null)
        {
            icon.sprite = currentItem.icon;
            nameObject.text = currentItem.nameItem;
            currentItem.slot1 = this;
            amount.text = currentItem.getAmount().ToString();
        }
        else
        {
            icon.sprite =null;
            nameObject.text = "Item esgotado";
            currentItem.slot1 = this;
            amount.text = "0";
        }
    }
    

    public void onClick()
    {
        if (isSelected)
        {
            inventario.selectedSlot = null;
            isSelected = false;

        }
        else
        {
            inventario.selectedSlot = this;
            isSelected = true;
        }
    }
    
    
}
