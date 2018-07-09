using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour {
    [Space(10)]
    public GameObject Inventario;

    public ItensBase potionsHPb, potionsStaminab, potionsManab, Pergaminho;
    public ItensBase potionsHPm, potionsStaminam, potionsManam;
    public ItensBase potionsHPmm, potionsStaminamm, potionsManamm;
    public ItensBase Bota, Calça, Elmo, Luva, Peito, Pistola, Bomba, Espada;

    public void CarregaGame()
    {
        LoadMissoes();
        LoadGameStatus();
        LoadItensInventario();
        LoadItensEquipaveis();

        Debug.Log("Carregou com sucesso");
    }

    public void LoadMissoes()
    {
        int[] AllMissoes = DataStatusInGame.LoadInGameMissoes();

        FindObjectOfType<DestructiveBase>().missoes[0] = AllMissoes[0];
        FindObjectOfType<DestructiveBase>().missoes[1] = AllMissoes[1];
        FindObjectOfType<DestructiveBase>().missoes[2] = AllMissoes[2];
        FindObjectOfType<DestructiveBase>().missoes[3] = AllMissoes[3];

        FindObjectOfType<DestructiveBase>().SetTodasMissoes();

    }

    public void LoadGameStatus()
    {
        int[] Status = DataStatusInGame.LoadInGameStatusBase();

        FindObjectOfType<PlayerBehaviour>().basicStats.forca = Status[0];
        FindObjectOfType<PlayerBehaviour>().basicStats.inteligencia = Status[1];
        FindObjectOfType<PlayerBehaviour>().basicStats.precisão = Status[2];
        FindObjectOfType<PlayerBehaviour>().basicStats.constituicao = Status[3];
        FindObjectOfType<PlayerBehaviour>().currentPontos = Status[4];
        FindObjectOfType<PlayerBehaviour>().currentSkills = Status[5];
    }

    public void LoadItensInventario()
    {
        int[] IDItens = DataStatusInGame.LoadInGameItens();
        int[] Amount = DataStatusInGame.LoadInGameAmount();
        int i = 0;

        //Seta os itens no inventario
        for (i = 0; i < IDItens.Length; i++)
        {
            {
                //addPergaminho
                if (IDItens[i] == 2)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Pergaminho);
                }

                //addPotionVidaMedia
                if (IDItens[i] == 3)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(potionsHPm);
                }

                //addPotionVidaGrande
                if (IDItens[i] == 4)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(potionsHPb);
                }

                //addPotionVidaPequena
                if (IDItens[i] == 5)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(potionsHPmm);
                }

                //addPotionManaMedia
                if (IDItens[i] == 6)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(potionsManam);
                }

                //addPotionManaGrande
                if (IDItens[i] == 7)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(potionsManab);
                }

                //addPotionManaPequena
                if (IDItens[i] == 8)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(potionsManamm);
                }

                //addPotionStaminaMedia
                if (IDItens[i] == 9)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(potionsStaminam);
                }

                //addPotionStaminaGrande
                if (IDItens[i] == 10)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(potionsStaminab);
                }

                //addPotionStaminaPequena
                if (IDItens[i] == 11)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(potionsStaminamm);
                }

                //addEspada
                if (IDItens[i] == 12)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Espada);
                }

                //addBomba
                if (IDItens[i] == 13)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Bomba);
                }

                //addPistola
                if (IDItens[i] == 14)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Pistola);
                }

                //addElmo
                if (IDItens[i] == 15)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Elmo);
                }

                //addPeito
                if (IDItens[i] == 16)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Peito);
                }

                //addLuva
                if (IDItens[i] == 17)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Luva);
                }

                //addCalça
                if (IDItens[i] == 18)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Calça);
                }

                //addBota
                if (IDItens[i] == 19)
                {
                    Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Bota);
                }

                //addAnel
                if (IDItens[i] == 20)
                {
                    //Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Anel);
                }

                //addBrinco
                if (IDItens[i] == 21)
                {
                    //Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Brinco);
                }

                //addItemMissão
                if (IDItens[i] > 21)
                {
                    //Inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent(Elmo);
                }
            }



            /*if (Inventario.GetComponent<ContoleDeInventario>().InventarioSlots[i].currentItem != null)
            {
               //inventario.GetComponent<ContoleDeInventario>().AddItemToInventoryPermanent()
                Inventario.GetComponent<ContoleDeInventario>().InventarioSlots[i].currentItem.identificacao = IDItens[i];
                Inventario.GetComponent<ContoleDeInventario>().InventarioSlots[i].currentItem.AmountSet(Amount[i]);
            }*/
        }
    }


    public void LoadItensEquipaveis()
    {
        int[] ItensEquipaveis = DataStatusInGame.LoadInGameItensEquipaveis();

        /*PlayerItensController.instance.elmo.currentItem.identificacao = ItensEquipaveis[0];
        PlayerItensController.instance.peito.currentItem.identificacao = ItensEquipaveis[1];
        PlayerItensController.instance.calça.currentItem.identificacao = ItensEquipaveis[2];
        PlayerItensController.instance.luva.currentItem.identificacao = ItensEquipaveis[3];
        PlayerItensController.instance.bota.currentItem.identificacao = ItensEquipaveis[4];
        PlayerItensController.instance.arma.currentItem.identificacao = ItensEquipaveis[5];
        PlayerItensController.instance.anel1.currentItem.identificacao = ItensEquipaveis[6];
        PlayerItensController.instance.anel2.currentItem.identificacao = ItensEquipaveis[7];
        PlayerItensController.instance.colar.currentItem.identificacao = ItensEquipaveis[8];
        */
    }
}