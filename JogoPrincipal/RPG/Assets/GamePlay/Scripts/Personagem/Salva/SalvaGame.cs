using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvaGame : MonoBehaviour {

    public GameObject Inventario;

    public void SaveGame(){

        SaveMissoes();
        SaveGameStatus();
        SaveItens();

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

    public void SaveItens()
    {
        List<SlotInventarioBehaviour> inventario;
        int[] IDItens = new int[20];
        int i = 0;

        inventario = Inventario.GetComponent<ContoleDeInventario>().InventarioSlots;

        foreach (SlotInventarioBehaviour slot in inventario)
        {
            Debug.Log(i);

            if(slot.currentItem != null)
            {
                IDItens[i] = slot.currentItem.GetId();
            }
            i++;
        }

        DataStatusInGame.SaveInGameItens(IDItens);
    }
}
