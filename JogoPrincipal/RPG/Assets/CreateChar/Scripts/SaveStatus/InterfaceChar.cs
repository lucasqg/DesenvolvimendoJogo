using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceChar : MonoBehaviour {

    public string CharNome;
    public string CharClasse;
    public string indexHead, indexBody, indexLegs;

    public void OnLoad()
    {
        string[] loadingData = DataBasePerfil.LoadDataChar();
        CharNome = loadingData[0];
        CharClasse = loadingData[1];
        indexHead = loadingData[2];
        indexBody = loadingData[3];
        indexLegs = loadingData[4];

        Debug.Log(CharNome + "/" + CharClasse);
    }
     
}
