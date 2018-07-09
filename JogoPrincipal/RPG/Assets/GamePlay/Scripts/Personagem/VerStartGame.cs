using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerStartGame : MonoBehaviour {

    public GameObject verifica;

    void Start()
    {

        int flag = PlayerPrefs.GetInt("NewOrLoad");

        if (flag == 1)
        {
            verifica.GetComponent<LoadGame>().CarregaGame();
        }
        else {
            verifica.GetComponent<SalvaGame>().SaveGame();
        }

    }

    public void OnSaveGame()
    {
        StartCoroutine(wait());
        verifica.GetComponent<SalvaGame>().SaveGame();
    }

    public void OnLoadGame()
    {
        StartCoroutine(wait());
        verifica.GetComponent<LoadGame>().CarregaGame();
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }
}
