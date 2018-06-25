using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventarioBehaviour : MonoBehaviour {

    public ItensBase currentItem;
    public Image iconItemSlot;
    public Text nameItem;
    public GameObject AmountIndicator;
    public Text amountText;
    private bool isSelected;
    public Image background;
    public Color unselectedColor;
    public Color selectedColor;

	// Use this for initialization
	void Start () {
        SetupSlot();
    }
	
    public void SetupSlot()
    {
        if(currentItem != null && currentItem.getAmount()> 0)
        {
            SetActiveSlot(true);
            iconItemSlot.sprite = currentItem.icon;
            nameItem.text = currentItem.nameItem;
            currentItem.slot = this;

            if (currentItem.isStacklabe)
            {
                amountText.text = currentItem.getAmount().ToString(); 
            }
            else
            {
                AmountIndicator.SetActive(false);
            }
        }
        else
        {
            SetActiveSlot(false);
        }
    }

    public void SetActiveSlot(bool isActive=true)
    {
        AmountIndicator.SetActive(isActive);
        nameItem.gameObject.SetActive(isActive);
        iconItemSlot.gameObject.SetActive(isActive);
    }

	// Update is called once per frame
	void Update () {
        isSelected = ContoleDeInventario.instance.selectedSlot == this;
        background.color = isSelected ? selectedColor : unselectedColor;
	}

    public void onClick()
    {
        if (isSelected)
        {
            ContoleDeInventario.instance.selectedSlot = null;
            currentItem.TxtAtributosLimpa();
            
        }
        else
        {
            ContoleDeInventario.instance.selectedSlot = this;
            currentItem.TxtAtributos();
            
        }
    }

    private void OnEnable()
    {
        SetupSlot();
    }


}
