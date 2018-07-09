using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour {

    public GameObject Inventario;

    public void CarregaGame()
    {
        LoadMissoes();
        LoadGameStatus();
        LoadItens();

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

    public void LoadItens()
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
}