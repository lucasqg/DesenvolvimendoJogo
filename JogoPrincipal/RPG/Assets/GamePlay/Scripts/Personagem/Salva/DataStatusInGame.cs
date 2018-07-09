using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataStatusInGame
{
    //Saves

    //Salva os AtributosBase
    public static void SaveInGameStatusBase(int forca, int inteligencia, int precisão, 
        int constituicao, int currentPontos, int pontosSkill)
    {                                     
        PlayerPrefs.SetInt("Forca", forca);   
        PlayerPrefs.SetInt("Inteligencia", inteligencia);   
        PlayerPrefs.SetInt("Precisao", precisão);   
        PlayerPrefs.SetInt("Constituicao", constituicao);   
        PlayerPrefs.SetInt("currentPontos", currentPontos);
        PlayerPrefs.SetInt("pontosSkill", pontosSkill);
    }

    public static void SaveInGameItens(int[] Itens)
    {
        string Item = "Item";
        int i = 0;

        foreach(int idElemento in Itens)
        {
            Item = "Item" + i;
            PlayerPrefs.SetInt(Item, idElemento);
            i++;
        }
        PlayerPrefs.SetInt("QtItem", i);
    }

    //Salva o estado de cada missão
    public static void SaveInGameMissoes(int MS1, int MS2, int MS3, int MP)
    {
        Debug.Log(MS1 + "/" + MS2);
        PlayerPrefs.SetInt("MS1", MS1);
        PlayerPrefs.SetInt("MS2", MS2);
        PlayerPrefs.SetInt("MS3", MS3);
        PlayerPrefs.SetInt("MP", MP);
    }



    //Loads

    //Load das Missões
    public static int[] LoadInGameMissoes()
    {
        return new int[] {
            PlayerPrefs.GetInt("MS1"),
            PlayerPrefs.GetInt("MS2"),
            PlayerPrefs.GetInt("MS3"),
            PlayerPrefs.GetInt("MP"),
        };
    }

    //Load dos StatusBase
    public static int[] LoadInGameStatusBase()
    {
        return new int[]
        {
        PlayerPrefs.GetInt("Forca"),
        PlayerPrefs.GetInt("Inteligencia"),
        PlayerPrefs.GetInt("Precisao"),
        PlayerPrefs.GetInt("Constituicao"),
        PlayerPrefs.GetInt("currentPontos"),
        PlayerPrefs.GetInt("pontosSkill")
        };
    }

    //Load dos Itens
    public static int[] LoadInGameItens()
    {

        int qtsItem = PlayerPrefs.GetInt("QtItem");
        string item = "Item";
        int[] Itens = new int[20];

        for (int i = 0; i < qtsItem; i++) {
            item = "Item" + i;
            Itens[i] = PlayerPrefs.GetInt(item);
        }

        return Itens;
    }
}
