using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotEquipavel : MonoBehaviour {
    public ItensBase currentItem;
    public Image iconItemSlot;
    public Text nameItem;
    private bool isSelected;
    public Image background;
    public Color unselectedColor;
    public Color selectedColor;

    void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        isSelected = PlayerItensController.instance.selectedSlot == this;
    }
    public void ActiveIcon()
    {
        if (currentItem != null)
        {
            SetActiveSlot(true);
            iconItemSlot.sprite = currentItem.icon;
            nameItem.text = currentItem.nameItem;
            currentItem.slotEkp = this;

        }
    }
    public void SetActiveSlot(bool isActive = true)
    {
        nameItem.gameObject.SetActive(isActive);
        iconItemSlot.gameObject.SetActive(isActive);
    }
    public void onClick()
    {
        if (isSelected)
        {
            PlayerItensController.instance.selectedSlot = null;
            currentItem.TxtAtributosLimpa();
        }
        else
        {
            PlayerItensController.instance.selectedSlot = this;
            currentItem.TxtAtributos();

        }
    }

}
