using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerreiroButtonAnim : MonoBehaviour {

    public Animator BotãoGuerreiro;
    public Animator SobreGuerreiro;
    public GameObject SobreGuerreiroObj;
    public bool Ativado = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBotãoGuerreiro()
    {
        if (Ativado)
        {
            Ativado = false;
            BotãoGuerreiro.SetBool("AtivaAnim", true);
            SobreGuerreiroObj.gameObject.SetActive(true);
            SobreGuerreiro.SetBool("AtivaSobreGuerreiro", true);
        }else if (!Ativado)
        {
            Ativado = true;
            BotãoGuerreiro.SetBool("AtivaAnim", false);
            SobreGuerreiro.SetBool("AtivaSobreGuerreiro", false);
            SobreGuerreiroObj.gameObject.SetActive(false);
        }
    }

}
