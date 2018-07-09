using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvaGame : MonoBehaviour {

    public GameObject Inventario;

    public void SaveGame(){

        SaveMissoes();
        SaveGameStatus();
        SaveItensInventario();
        SaveItensEquipaveis();

        Debug.Log("Salvou com sucesso");
    }

    public void SaveMissoes()
    {
        int MS1 =1 , MS2= 2, MS3 =3, MP =4;

        MS1 = FindObjectOfType<PlayerBehaviour>().GetNivelDeMissao("missao1");
        MS2 = FindObjectOfType<PlayerBehaviour>().GetNivelDeMissao("missao2");
        MS3 = FindObjectOfType<PlayerBehaviour>().GetNivelDeMissao("missao3");
        MP = FindObjectOfType<PlayerBehaviour>().GetNivelDeMissao("missaoPrincipal");

        DataStatusInGame.SaveInGameMissoes(MS1, MS2, MS3, MP);
    }

    public void SaveGameStatus()
    {
        int forca;
        int inteligencia;
        int precisão;
        int constituicao;
        int currentPontos;
        int pontosSkill;

        forca = FindObjectOfType<PlayerBehaviour>().basicStats.forca;
        inteligencia = FindObjectOfType<PlayerBehaviour>().basicStats.inteligencia;
        precisão = FindObjectOfType<PlayerBehaviour>().basicStats.precisão;
        constituicao = FindObjectOfType<PlayerBehaviour>().basicStats.constituicao;
        currentPontos = FindObjectOfType<PlayerBehaviour>().currentPontos;
        pontosSkill = FindObjectOfType<PlayerBehaviour>().currentSkills;

        DataStatusInGame.SaveInGameStatusBase(forca, inteligencia, precisão, constituicao, currentPontos, pontosSkill);
    }

    public void SaveItensInventario()
    {
        List<SlotInventarioBehaviour> inventario;
        int[] IDItens = new int[20];
        int[] Amount = new int[20];
        int i = 0;

        inventario = Inventario.GetComponent<ContoleDeInventario>().InventarioSlots;

        foreach (SlotInventarioBehaviour slot in inventario)
        {
            if(slot.currentItem != null)
            {
                IDItens[i] = slot.currentItem.GetId();
                Amount[i] = slot.currentItem.getAmount();
            }

            i++;
        }
        i = 0;
        DataStatusInGame.SaveInGameItens(IDItens, Amount);
    }

    public void SaveItensEquipaveis()
    {
        int elmo = 0, peito = 0, calça = 0, luva = 0, bota = 0, arma = 0, anel1 = 0, anel2 = 0, colar = 0;

        if(PlayerItensController.instance.elmo.currentItem != null)
        {
            elmo = PlayerItensController.instance.elmo.currentItem.identificacao;
        }
        
        if(PlayerItensController.instance.peito.currentItem != null)
        {
            peito = PlayerItensController.instance.peito.currentItem.identificacao;
        }

        if (PlayerItensController.instance.calça.currentItem != null)
        {
            calça = PlayerItensController.instance.calça.currentItem.identificacao;
        }

        if (PlayerItensController.instance.luva.currentItem != null)
        {
            luva = PlayerItensController.instance.luva.currentItem.identificacao;
        }

        if (PlayerItensController.instance.bota.currentItem != null)
        {
            bota = PlayerItensController.instance.bota.currentItem.identificacao;
        }

        if (PlayerItensController.instance.arma.currentItem != null)
        {
            arma = PlayerItensController.instance.arma.currentItem.identificacao;
        }

        if (PlayerItensController.instance.anel1.currentItem != null)
        {
            anel1 = PlayerItensController.instance.anel1.currentItem.identificacao;
        }

        if (PlayerItensController.instance.anel2.currentItem != null)
        {
            anel2 = PlayerItensController.instance.anel2.currentItem.identificacao;
        }

        if (PlayerItensController.instance.colar.currentItem != null)
        {
            colar = PlayerItensController.instance.colar.currentItem.identificacao;
        }


        DataStatusInGame.SaveInGameItensEquipaveis(elmo, peito, calça, luva, bota, arma, anel1, anel2, colar);
    }
}
