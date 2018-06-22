using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabeloVerde : MonoBehaviour {
    public Text abrirJanela;
    public Text conversa, nomeNpc;
    public Canvas fala;
    public float defaultTimeScale;
    public Image player;
    public Image PLAYER;
    public Sprite npc;
    public Image NPC;
    public bool falando = false;
    private int i = 1;
    public GameObject bandeira;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
        bandeira.SetActive(true); // liga a bandeira e inicia a missão
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
