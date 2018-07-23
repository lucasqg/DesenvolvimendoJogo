using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerreiroButtonAnim : MonoBehaviour {

    public Animator BotãoGuerreiro;
    public Animator SobreGuerreiro;
    public GameObject SobreGuerreiroObj;
    public GameObject ButtonPitoleiro;
    public GameObject ButtonBomber;
    private bool Ativado;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBotãoGuerreiro()
    {   
        
        if (!Ativado)
        {
            Ativado = true;
            BotãoGuerreiro.SetBool("Ativa", false);
            SobreGuerreiroObj.gameObject.SetActive(true);
            SobreGuerreiro.SetBool("AtivaSobre", true);
        }else if (Ativado)
        {
            Ativado = false;
            BotãoGuerreiro.SetBool("Ativa", true);
            SobreGuerreiro.SetBool("AtivaSobre", false);
            SobreGuerreiroObj.gameObject.SetActive(false);
            ButtonPitoleiro.gameObject.SetActive(true);
            ButtonBomber.gameObject.SetActive(true);
        }
    }

}
