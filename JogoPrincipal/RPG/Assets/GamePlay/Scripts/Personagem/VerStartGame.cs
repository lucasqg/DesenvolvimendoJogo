using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerStartGame : MonoBehaviour {


    void Start()
    {

        int flag = PlayerPrefs.GetInt("NewOrLoad");

        if (flag == 1)
        {
            this.GetComponent<LoadGame>().CarregaGame();
        }
        else {}

    }

    public void OnSaveGame()
    {
        this.GetComponent<SalvaGame>().SaveGame();
    }

    public void OnLoadGame()
    {
        this.GetComponent<LoadGame>().CarregaGame();
    }
}
