using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour {

    public List<Button> Adicionar; // 4 elementos
    public List<Text> PontosTotais;
    public List<Text> StatusTotais;
    public Text pontos;
    public List<Button> Mais;

    private PlayerBehaviour player;

	// Use this for initialization
	void Start () {

        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        AtualizaPontos();
    }
	
	// Update is called once per frame
	void Update () {
        TextUpdateStatus();

    }

    public void ForcaMAIS()
    {
        if (player.currentPontos >= 3)
        {
            player.basicStats.forca++;
            PontosTotais[0].text = player.basicStats.forca.ToString();
            player.danoTotal++;
            player.currentPontos-=3;
        }
    }

    public void PrecisaoMAIS()
    {
        if (player.currentPontos >= 4)
        {
            player.currentPontos -= 4;
            player.basicStats.precisão++;
            player.danoTotal++;
            PontosTotais[1].text = player.basicStats.precisão.ToString();
        }
    }

    public void InteligenciaMAIS()
    {
        if (player.currentPontos >= 1)
        {
            player.currentPontos--;
            player.basicStats.inteligencia++;
            PontosTotais[2].text = player.basicStats.inteligencia.ToString();
        }
    }

    public void ConstituiçãoMAIS()
    {
        if (player.currentPontos >= 1)
        {
            player.currentPontos--;
            player.basicStats.constituicao++;
            player.totalLife++;
            PontosTotais[3].text = player.basicStats.constituicao.ToString();
        }
    }

    public void AtualizaPontos()
    {
        PontosTotais[0].text = player.basicStats.forca.ToString();
        PontosTotais[1].text = player.basicStats.precisão.ToString();
        PontosTotais[2].text = player.basicStats.inteligencia.ToString();
        PontosTotais[3].text = player.basicStats.constituicao.ToString();
    }

    public void TextUpdateStatus()
    {
        pontos.text = player.currentPontos.ToString();
        StatusTotais[0].text = player.danoTotal.ToString();
        StatusTotais[1].text = player.defTotal.ToString();
        StatusTotais[2].text = player.totalStamina.ToString();
        StatusTotais[3].text = player.totalLife.ToString();
        StatusTotais[4].text = PlayerStatsController.GetCurrentLevel().ToString();
        StatusTotais[5].text = PlayerStatsController.GetCurrentReputation().ToString();

    }


}
