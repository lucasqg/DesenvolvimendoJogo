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
    public bool missaoAtiva, verificaSlot;
    public int ContadorDeTempo = 0, tempoMaximoMissao;
    public PlayerBehaviour player;
    private int nivelDeMissao;
    public Text texto;
    //public GameObject Spawn;

    void Start () {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        missaoAtiva = false;
        tempoMaximoMissao = 5000;
    }
	
	void Update () {
        if (falando && !missaoAtiva)
        {
            TentaConversar();
            Conversando(i);
        }

        if (missaoAtiva && falando)
        {
           /* MissaoAtiva();
            DerrotaDeMissao();
            */
            TentaConversar();
            ConversandoPosMissao(i);
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
                nomeNpc.text = "Cientista";

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
            if (Input.GetKeyDown(KeyCode.Return))
            {
                i++;
            }
        }
    }

    public void Conversando(int op = 1)
    {
       
            //nivelDeMissao += 1;
            switch (op)
        {
            case 0:
                conversa.text = "";
                break;
            case 1:
                conversa.text = "Olá companheiro, estou feliz em ver você por aqui";
                break;
            case 2:
                conversa.text = "Vejo que você busca um trabalho...\n Estou construindo um novo filtro para melhorar o ar da cidadela e preciso de materiais!\n Faça o que eu mando no tempo exato que você será bem recompensado!";
                break;
            case 3:
               // if (nivelDeMissao == 1 || nivelDeMissao > 3) {
                    conversa.text = "Vá pela estrada da direita e mate os esqueletos até encontrar alguns ossos bem fortes para que eu possa queimar e o transformar em carvão para o filtro!\n Vou precisar de muitos, mas por hora... Só quero um :";
                /*  }
                  else if (nivelDeMissao ==2)
                  {
                      conversa.text = "Vá pela estrada a esquerda, caminhe até encontrar uma carroça tombada, nela talvez você encontre um regulador de ar. Não me pergunte como ela foi parar lá... \n E não esqueça de trazer o item para mim, mas seja rapido";
                  }
                  else if (nivelDeMissao == 3)
                  {
                      conversa.text = "Vá pela estrada a esquerda, em um lugar não tão distante existe um homem que carrega uma engrenagem, não sei para que ele carrega isso, mas, ME TRAGA!!! ";
                  }*/
                //texto.text = "Mate os esqueletos até encontrar ossos";
                break;
            case 4:
                IniciarMissao(); // inicia a missao
                break;
        }

    }

    public void ConversandoPosMissao(int op = 1)
    {

        foreach (SlotInventarioBehaviour slot in ContoleDeInventario.instance.InventarioSlots)
        {
            if (slot.currentItem != null && slot.currentItem.identificacao == 22)
            {
                slot.currentItem.DestroiItem();
                verificaSlot = true;
            }
        }
        switch (op)
        {
            case 0:
                conversa.text = "";
                break;
            case 1:
                conversa.text = "Você conseguiu??";
                break;
            case 2:
                if (verificaSlot) {
                    conversa.text = "Obrigado, tome aqui sua recompensa..";
                    FinalizarMissao();
                    verificaSlot = false;
                    falando = false;
                    fala.gameObject.SetActive(false);
                    Time.timeScale = defaultTimeScale;

                }
                else
                {
                    conversa.text = "Volte quando acabar..";
                    falando = false;
                    fala.gameObject.SetActive(false);

                    Debug.Log("Janelation");
                    i = 0;
                    Time.timeScale = defaultTimeScale;
                }
                break;
        }

    }

    public void IniciarMissao()
    {
        Time.timeScale = defaultTimeScale; //despausa o game
        fala.gameObject.SetActive(false);//liga e desliga a fala
        missaoAtiva = true;
        i = 0;
        //this.gameObject.SetActive(false); // boneca desaparece
       /* missaoAtiva = true;
        if (nivelDeMissao == 1 || nivelDeMissao > 3)
        {
            Spawn.GetComponent<SpawnEsqueleto>().missaoDrop = true;
        }
        else if (nivelDeMissao == 2)
        {
            Spawn.GetComponent<SpawnEsqueleto>().missaoDrop = false;
        }
        else if (nivelDeMissao == 3)
        {
            Spawn.GetComponent<SpawnEsqueleto>().missaoDrop = false;
        }*/
        
    }

    public void FinalizarMissao()
    {
        this.gameObject.SetActive(true);
        missaoAtiva = false;
        i = 0;
        //Spawn.GetComponent<SpawnEsqueleto>().missaoDrop = false;
        PlayerStatsController.AddReputation(20);
        player.SetNivelDeMissao("missao2");
        texto.text = " ";
    }

    public void DerrotaDeMissao()
    {
        //if (bandeira.GetComponent<NpcBase>().currentLife <= 10)
        // {
       // Spawn.GetComponent<SpawnEsqueleto>().missaoDrop = false;
       // Spawn.GetComponent<SpawnEsqueleto>().missaoDrop = false;
        //   Destroy(bandeiraAtiva);
        PlayerStatsController.AddReputation(-10);
        missaoAtiva = false;
        foreach (SlotInventarioBehaviour slot in ContoleDeInventario.instance.InventarioSlots)
        {
            if (slot.currentItem != null && slot.currentItem.identificacao == 22)
            {
                slot.currentItem.DestroiItem();
                verificaSlot = true;
            }
        }
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
