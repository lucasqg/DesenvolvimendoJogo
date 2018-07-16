using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotoesClasse : MonoBehaviour {

    private string classe;
    private string nome;
    public int IndexHead, IndexBody, IndexLegs;
    [Space(10)]
    public GameObject GetIndexChar;
    public GameObject Load;
    [Space(10)]
    public InputField InputTmp;


    //Botoes
	public void OnGuerreiro()
    {
        classe = "Guerreiro";
    }

    public void OnPistoleiro()
    {
        classe = "Pistoleiro";
    }

    public void OnBomber()
    {
        classe = "Bomber";
    }

    public void OnCriarPesonagem()
    {
        nome = InputTmp.text;

        bool preenchido = checkClass();

        if (preenchido)
        {
            IndexHead = GetIndexChar.GetComponent<EditarPersonagem>().indexH;
            IndexBody = GetIndexChar.GetComponent<EditarPersonagem>().indexB;
            IndexLegs = GetIndexChar.GetComponent<EditarPersonagem>().indexL;
            DataBasePerfil.SaveDataChar(nome, classe, IndexHead, IndexBody, IndexLegs);

            Load.GetComponent<LoadCene>().OnStart();
            
        }
    }


    //Função para checkar se os campos foram preenchidos corretamente
    private bool checkClass()
    {
        if (nome.Length > 2)
        {
            Debug.Log(nome + " / " + classe);
            if (classe == "Guerreiro" || classe == "Pistoleiro" || classe == "Bomber")
            {
                Debug.Log(nome + " / " + classe);
                return true;
            }
        }

        Debug.Log("Falta alguma");
        return false;
    }
}
