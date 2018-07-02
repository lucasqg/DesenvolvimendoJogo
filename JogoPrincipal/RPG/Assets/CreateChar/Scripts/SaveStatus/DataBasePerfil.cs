using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBasePerfil {

    public static void SaveDataChar(string nome, string classe, int head, int body, int legs)
    {
        PlayerPrefs.SetString("CharNome", nome);
        PlayerPrefs.SetString("CharClasse", classe);
        PlayerPrefs.SetInt("Head", head);
        PlayerPrefs.SetInt("Body", body);
        PlayerPrefs.SetInt("Legs", legs);

    }

    public static string[] LoadDataChar()
    {

        return new string[] { PlayerPrefs.GetString("CharNome", ""), PlayerPrefs.GetString("CharClasse", ""),
        PlayerPrefs.GetInt("Head").ToString(),
        PlayerPrefs.GetInt("Body").ToString(),
        PlayerPrefs.GetInt("Legs").ToString(),
        };
    }
}
