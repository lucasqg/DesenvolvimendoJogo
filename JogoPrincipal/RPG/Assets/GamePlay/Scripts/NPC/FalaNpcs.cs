using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalaNpcs : NpcBase {

    public Text abrirJanela;
    public Text conversa, nomeNpc;
    public Canvas fala;
    public float defaultTimeScale;
    public Image player;
    public Image PLAYER;
    public Sprite npc;
    public Image NPC;
    public GameObject carroceiro;
    public bool falando = false;
    private int i = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DetectNPC()
    {
        if(nameNPC == "MestreDaVila")
        {
            FalaMestreDaVila();
        }

    }

    public void FalaMestreDaVila()
    {
        switch (i)
        {
            case 1:
                conversa.text = "Olá amigo\n As regras são claras, siga-as e você terá futuro em nossa civilização.\n Saia daqui e suba sua reputação!";
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        falando = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        falando = false;
    }
}
