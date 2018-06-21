using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarroceiroFalas : MonoBehaviour {

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
        if (falando)
        {
            TentaConversar();
            Conversando(i);
            PLAYER = player;
            NPC.sprite = npc;
        }
    }

    public void TentaConversar()
    {
        if (falando)
        {
            abrirJanela.text = "Pressione [F] para conversar";
            if (Input.GetKeyDown(KeyCode.F))
            {
                fala.gameObject.SetActive(true); // liga e desliga o inventario
                nomeNpc.text = "Carroceiro";

                if (fala.gameObject.activeSelf)//CONDICIONAL QUE PAUSE O GAME.
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = defaultTimeScale;
                }
            }
            abrirJanela.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                i++;
            }
        }
    }

    public void Conversando(int op = 1)
    {
        switch (op)
        {
            case 1:
                conversa.text = "Me ajudeeee !!?!!!";
                
                break;
            case 2:
                conversa.text = "Escolte eu e minha carroça até a plantação de macieiras e lhe darei reputação";
                break;
            case 3:
                conversa.text = "Cuidado existem muitos monstros em volta! \n<b>ME PROTEJA!</b> ";
                break;
            case 4:
                IniciarMissao();
                break;
        }

    }

    public void IniciarMissao()
    {
        Instantiate(carroceiro, transform.position, transform.rotation);
        Time.timeScale = defaultTimeScale;
        fala.gameObject.SetActive(false);//liga e desliga o inventario
        this.gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            falando = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            falando = false;
            abrirJanela.gameObject.SetActive(false);
        }
    }

}
