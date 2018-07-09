using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour {

    public GameObject Inventario;

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
        int i = 0;


        for(i = 0; i<IDItens.Length; i++)
        {
            if (Inventario.GetComponent<ContoleDeInventario>().InventarioSlots[i].currentItem != null)
            {
                Inventario.GetComponent<ContoleDeInventario>().InventarioSlots[i].currentItem.identificacao = IDItens[i];
            }
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