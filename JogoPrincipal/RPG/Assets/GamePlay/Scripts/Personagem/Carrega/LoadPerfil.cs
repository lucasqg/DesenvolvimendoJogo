using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPerfil : MonoBehaviour {

    public string NomePersonagem, ClassePersonagem;
    public int IndexHeadP, IndexBodyP, IndexLegsP;
    [Space(10)]
    public GameObject Head;
    public GameObject Body;
    public GameObject Legs;
    [Space(10)]
    public GameObject Visual;


    // Use this for initialization
    void Start () {
        string[] loadingData = DataBasePerfil.LoadDataChar();
        NomePersonagem = loadingData[0];
        ClassePersonagem = loadingData[1];
        IndexHeadP = int.Parse(loadingData[2]);
        IndexBodyP = int.Parse(loadingData[3]);
        IndexLegsP = int.Parse(loadingData[4]);

        
        Head.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Heads[IndexHeadP];
        Body.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Bodys[IndexBodyP];
        Legs.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Legs[IndexLegsP];


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
