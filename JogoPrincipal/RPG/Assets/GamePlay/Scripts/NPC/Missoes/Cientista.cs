using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cientista : MonoBehaviour {
    public Text abrirJanela;
    public Text conversa, nomeNpc;
    public Canvas fala;
    public float defaultTimeScale;
    public Image player1;
    public Image PLAYER;
    public Sprite npc;
    public Image NPC;
    public bool falando = false;
    private int i = 1;
    public bool missaoAtiva;
    public int ContadorDeTempo = 0, tempoMaximoMissao;
    public PlayerBehaviour player;
    private int nivelDeMissao;

    public GameObject esqueletoOSSO, esqueleto;
    public float X, Y;

    void Start () {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        missaoAtiva = false;
        tempoMaximoMissao = 5000;
    }
	
	void Update () {
        if (falando)
        {
            TentaConversar();
            Conversando(i);
            PLAYER = player1;
            NPC.sprite = npc;
        }

        if (missaoAtiva)
        {
            MissaoAtiva();
            DerrotaDeMissao();
        }
    }

    public void MissaoAtiva()
    {
        ContadorDeTempo += 1;
        if (ContadorDeTempo >= tempoMaximoMissao)
        {
            FinalizarMissao();
            missaoAtiva = false;
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
                nomeNpc.text = "Cabelo Verde";

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
        nivelDeMissao += 1;
        switch (op)
        {
            case 1:
                conversa.text = "Olá companheiro, estou feliz em ver você por aqui";
                break;
            case 2:
                conversa.text = "Vejo que você busca um trabalho...\n Estou construindo um novo filtro para melhorar o ar da cidadela e preciso de materiais!\n Faça o que eu mando no tempo exato que você será bem recompensado!";
                break;
            case 3:
                if (nivelDeMissao == 1 || nivelDeMissao > 3) {
                    conversa.text = "Vá pela estrada da esquerda e mate os esqueletos até encontrar um osso bem forte para que eu possa queimar e o transformar em carvão para o filtro!\n Vou precisar de muitos, mas por hora... Só quero um :";
                }
                else if (nivelDeMissao ==2)
                {
                    conversa.text = "Vá pela estrada a esquerda, caminhe até encontrar uma carroça tombada, nela talvez você encontre um regulador de ar. Não me pergunte como ela foi parar lá... \n E não esqueça de trazer o item para mim, mas seja rapido";
                }
                else if (nivelDeMissao == 3)
                {
                    conversa.text = "Vá pela estrada a esquerda, em um lugar não tão distante existe um homem que carrega uma engrenagem, não sei para que ele carrega isso, mas, ME TRAGA!!! ";
                }
                break;
            case 4:
                IniciarMissao(); // inicia a missao
                break;
        }

    }

    public void IniciarMissao()
    {
        if (nivelDeMissao == 1 || nivelDeMissao > 3)
        {
            GameObject SpawnEsqueletoOSSO = Instantiate(esqueletoOSSO, new Vector3(X, Y, -1), Quaternion.identity);
        }
        else if (nivelDeMissao == 2)
        {
            GameObject SpawnEsqueleto = Instantiate(esqueleto, new Vector3(X, Y, -1), Quaternion.identity);
        }
        else if (nivelDeMissao == 3)
        {
            GameObject SpawnEsqueleto = Instantiate(esqueleto, new Vector3(X, Y, -1), Quaternion.identity);
        }
        // bandeiraAtiva = Instantiate(bandeira, new Vector3(75.09f, -24.36f, -1), Quaternion.identity);
        //bandeiraAtiva.GetComponent<SpawnLoboMissao2>().boneca = this;
        //bandeira.SetActive(true); // liga a bandeira e inicia a missão
        Time.timeScale = defaultTimeScale; // pausa o game
        fala.gameObject.SetActive(false);//liga e desliga o inventario
        this.gameObject.SetActive(false); // boneca desaparece
        missaoAtiva = true;
    }

    public void FinalizarMissao()
    {
        this.gameObject.SetActive(true);
        missaoAtiva = false;
        //condições de vitoria
       // Destroy(bandeiraAtiva);
        PlayerStatsController.AddReputation(10);
        player.SetNivelDeMissao("missao2");
    }

    public void DerrotaDeMissao()
    {
        //if (bandeira.GetComponent<NpcBase>().currentLife <= 10)
       // {
         //   Destroy(bandeiraAtiva);
            PlayerStatsController.AddReputation(-10);
        //    missaoAtiva = false;
       // }
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
