using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalaNpcs : MonoBehaviour
{
    public Text instrucoes;
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
    public GameObject cientista;
    public GameObject cien;
    public bool pergaminhoEntregue, encontrouMochila;
    public CarrocaDaMochila carroca;
    private bool ativaCientista;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        missaoAtiva = false;
        tempoMaximoMissao = 5000;
        nivelDeMissao = player.GetNivelDeMissao("missaoPrincipal");
    }
	
	// Update is called once per frame
	void Update () {
        if (falando)
        {
            nivelDeMissao = player.GetNivelDeMissao("missaoPrincipal");
            TentaConversar();
            FalaMestreDaVila(i);
            PLAYER = player1;
            NPC.sprite = npc;

        }

        if (pergaminhoEntregue)
        {
            pergaminhoEntregue = false;
            player.SetNivelDeMissao("missaoPrincipal");
            instrucoes.text = "Fale com o mestre da vila";
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
                nomeNpc.text = "MestreDaVila";

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

    public void FalaMestreDaVila(int op=1)
    {
        switch (op)
        {
            case 1:
                if (PlayerStatsController.GetCurrentReputation() <= 100)
                {
                    conversa.text = "Olá amigo\n As regras são claras, siga-as e você terá futuro em nossa civilização.\n Saia daqui e volte quando conseguir!";
                  
                }
                else if (PlayerStatsController.GetCurrentReputation() >= 100 && nivelDeMissao == 0)
                {
                    conversa.text = "Meu garoto, você se mostrou digno de confiança!\n" +
                        "Seu destino foi traçado a muito tempo atrás. Mostre que você é digno desta reputação.";
                }
                
                else if (PlayerStatsController.GetCurrentReputation() >= 100 && nivelDeMissao == 1)
                {
                    conversa.text = "Oh não o cientista se esqueceu da mochila, nela está contida a unica receita que pode destruir o fungo e os equipamentos necessarios para fazer este feito!\n" +
                    "Por favor, volte até la e encontre a mochila.";
                    instrucoes.text = "Encontre a mochila!";
                    buscarMochila();
                }
                else if (PlayerStatsController.GetCurrentReputation() >= 100 && nivelDeMissao == 2)
                {
                    conversa.text = "Finalmente, achei que tivesse morrido...\n" +
                    "Você trouxe a mochiça?";
                }
                break;
            case 2:
                if (PlayerStatsController.GetCurrentReputation() >= 100 && nivelDeMissao == 4)
                {
                    conversa.text = "Ótimo, agora só basta esperar para o cientista concluir a receita e nós seremos livres novamente!\n Muito obrigado!";
                    break;
                }
                else if (PlayerStatsController.GetCurrentReputation() >= 100 && nivelDeMissao == 0)
                {
                    conversa.text = "Nosso amado cientista está perdido (Se já não estiver morto)\n" +
                    "Encontre-o e o leve um pergaminho de teletransporte. Você é nossa unica esperança. Não nos desaponte!";
                    instrucoes.text = "Compre e leve um pergaminho até o cientista que está perdido.";
                    iniciaMissaoSalvamento();
                    break;
                }
                else
                {
                    
                }
                break;
            case 3:
                i = 0;
                    fechaTudo();
                break;
        }
    }
    private void buscarMochila()
    {
        carroca.ativarMissao = true;
    }
    private void iniciaMissaoSalvamento()
    {
        if (ativaCientista == false)
        {
            cientista = Instantiate(cien, new Vector3(1.08f, -61.42f, -1.12f), Quaternion.identity);
            cientista.GetComponent<CientistaLouco>().mestre = this;
            ativaCientista = true;
        }
    }

    public void fechaTudo()
    {
        Time.timeScale = defaultTimeScale; //despausa o game
        fala.gameObject.SetActive(false);//liga e desliga a fala
        missaoAtiva = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (nivelDeMissao == 1) foreach (SlotInventarioBehaviour slot in ContoleDeInventario.instance.InventarioSlots)
                {
                    if (slot.currentItem != null && slot.currentItem.identificacao == 23)
                    {
                        slot.currentItem.DestroiItem();
                        encontrouMochila = true;
                        instrucoes.text = "Fale com o Mestre";
                        player.SetNivelDeMissao("missaoPrincipal");
                        break;
                    }
                }
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
