using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBehaviour : ItensBase {

    public int amountLiquid;
    private PlayerBehaviour player;

    private void Start()
    {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
    }
    public override void AfterUse()
    {
        ApplyPotion();
        RemoveItem();
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

        public override void TxtAtributos()
        {
        UIController.instancer.atributosItens.text = "Poção Vermelha: Recupera HP do personagem" +
        "\nPoção Azul: Recupera MANA do personagem" +
        "\nPoção Amarela: Recupera Stamina do personagem" ;
        }
    }
