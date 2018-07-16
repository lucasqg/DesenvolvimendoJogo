using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabeloVerde : MonoBehaviour {
    public Text Descricao;
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
    public GameObject bandeira, bandeiraAtiva;
    public PlayerBehaviour player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        missaoAtiva = false;
        tempoMaximoMissao = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        if (falando)
        {
            TentaConversar();
            Conversando(i);
            PLAYER = player1;
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
        switch (op)
        {
            case 1:
                conversa.text = "Por favor, me ajude :(";
                break;
            case 2:
                conversa.text = "Minha ovelha desapareceu, já procurei por toda a cidade e não encontro em lugar nenhum\n Talvez ela tenha fugido pelas escadas\n Por favor, a encontre e a mantenha segur!" +
                    "\nSalve a qualquer custo!!!!";
                break;
            case 3:
                conversa.text = "Encontre e defenda a ovelha, não deixe os lobos se aproximarem pois tudo estará acabado! \n<b>PROTEJA MINHA OVELHA...</b>\n ";
                Descricao.text = "Encontre a ovelha\n Não deixe que nenhum lobo mate ela.. e também não morra!";
                break;
            case 4:

                falando = false;
                
                IniciarMissao(); // inicia a missao
                break;
        }

    }

    public void IniciarMissao()
    {
        falando = false;
        bandeiraAtiva = Instantiate(bandeira, new Vector3(-147.32f, -93.13f, -2), Quaternion.identity);
        bandeiraAtiva.GetComponent<SpawnLoboMissao2>().boneca = this;
        bandeiraAtiva.SetActive(true); // liga a bandeira e inicia a missão
        Time.timeScale = defaultTimeScale; // pausa o game
        fala.gameObject.SetActive(false);//liga e desliga a fala
        missaoAtiva = true;
        i = 0;
    }

    public void FinalizarMissao()
    {
        missaoAtiva = false;
        //condições de vitoria
        Destroy(bandeiraAtiva);
        PlayerStatsController.AddReputation(20);
        player.SetNivelDeMissao("missao2");
    }

    public void DerrotaDeMissao()
    {
       
            PlayerStatsController.AddReputation(-15);
            missaoAtiva = false;
        
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
