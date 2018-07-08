using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBehaviour : ItensBase {

    public int amountLiquid;
    private PlayerBehaviour player;

    private void Start()
    {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        ValorDoItem();
        Identificacao();
    }
    public override void AfterUse()
    {
        ApplyPotion();
        RemoveItem();
    }
    public void Identificacao()
    {
        if (this.nameItem == "Poção Vida Média")
            identificacao = 3;
        else if (this.nameItem == "Poção Vida Grande")
            identificacao = 4;
        else if (this.nameItem == "Poção Vida Pequena")
            identificacao = 5;
        else if (this.nameItem == "Poção Mana Média")
            identificacao = 6;
        else if (this.nameItem == "Poção Mana Grande")
            identificacao = 7;
        else if (this.nameItem == "Poção Mana Pequena")
            identificacao = 8;
        else if (this.nameItem == "Poção Stamina Média")
            identificacao = 9;
        else if (this.nameItem == "Poção Stamina Grande")
            identificacao = 10;
        else if (this.nameItem == "Poção Stamina Pequena")
            identificacao = 11;
    }
    public void ApplyPotion()
    {
        if (this.nameItem == "Poção Vida Média" || this.nameItem == "Poção Vida Grande" || this.nameItem == "Poção Vida Pequena")
        {
            player.addLife(amountLiquid);
        }
        else if (this.nameItem == "Poção Mana Média" || this.nameItem == "Poção Mana Grande" || this.nameItem == "Poção Mana Pequena")
        {
            player.addMana(amountLiquid);
        }
        else if (this.nameItem == "Poção Stamina Média" || this.nameItem == "Poção Stamina Grande" || this.nameItem == "Poção Stamina Pequena")
        {
            player.addStamina(amountLiquid);
        }
    }

    public void ValorDoItem()
    {
        if (this.nameItem == "Poção Vida Média" || this.nameItem == "Poção Mana Média" || this.nameItem == "Poção Stamina Média")
        {
            valorDoItem = 2;
        }
            else if(this.nameItem == "Poção Vida Grande" || this.nameItem == "Poção Mana Grande" || this.nameItem == "Poção Stamina Grande")
        {
            valorDoItem = 3;
        } 
            else if(this.nameItem == "Poção Vida Pequena" || this.nameItem == "Poção Mana Pequena" || this.nameItem == "Poção Stamina Pequena") 
        {
            valorDoItem = 1;
        }
    }
        public override void TxtAtributos()
        {
        UIController.instancer.atributosItens.text = "Poção Vermelha: Recupera HP do personagem" +
        "\nPoção Azul: Recupera MANA do personagem" +
        "\nPoção Amarela: Recupera Stamina do personagem" ;
        }
    }
