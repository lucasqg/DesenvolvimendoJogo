using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabeloVerde : MonoBehaviour {
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

        if (missaoAtiva)
        {
            MissaoAtiva();
            DerrotaDeMissao();
        }
    }

    public void MissaoAtiva()
    {
        ContadorDeTempo += 1;
        if(ContadorDeTempo >= tempoMaximoMissao)
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
                conversa.text = "Por favor, me ajude :(";
                break;
            case 2:
                conversa.text = "Tenho uma fazenda que abastece a cidadela com comida, mas os monstros estão se direcionando para ataca-la, preciso de um verdadeiro heroi para salvar minha fazenda!";
                break;
            case 3:
                conversa.text = "Siga na estrada a direita até o final e defenda a bandeira vermelha, se um monstro chegar até ela, tudo estará acabado! \n<b>PROTEJA MINHA FAZENDA!</b>\n\nDizem que sua reputação subirá ao terminar isso, ah e te darei um pouquinho de ouro pela ajuda! ";
                break;
            case 4:
                IniciarMissao();
                break;
        }

    }

    public void IniciarMissao()
    {
        bandeiraAtiva = Instantiate(bandeira, new Vector3(75.09f, -24.36f, -1), Quaternion.identity);
        //bandeira.SetActive(true); // liga a bandeira e inicia a missão
        Time.timeScale = defaultTimeScale;
        fala.gameObject.SetActive(false);//liga e desliga o inventario
        this.gameObject.SetActive(false);
        missaoAtiva = true;
    }

    public void FinalizarMissao()
    {
        //condições de vitoria
        Destroy(bandeiraAtiva);
        PlayerStatsController.AddReputation(10);
        player.SetNivelDeMissao("missao2");
    }

    public void DerrotaDeMissao()
    {
       if(bandeira.GetComponent<NpcBase>().currentLife <= 10)
        {
            Destroy(bandeiraAtiva);
            PlayerStatsController.AddReputation(-10);
            missaoAtiva = false;
        }
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
