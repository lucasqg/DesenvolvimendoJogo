using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreinadorCampo : MonoBehaviour {

    public Text descricao;
    public Text abrirJanela;
    public Text conversa, nomeNpc;
    public Canvas fala;
    public float defaultTimeScale;
    public Image npc, player;
    public int quantidadeDeFalas = 5;
    public int tipoDeMissao = 0;
    private int i=1;
    public bool missao1 = false;
    public bool missao0 = true;

    public GameObject elmo;
    public GameObject peito;
    public GameObject calça;
    public GameObject bota;
    public GameObject luva;

    public bool falar = false;
    public bool dizendo = false;
    public GameObject potion;
    public GameObject espada;
    public GameObject morcego;
    public Transform playert;
    public bool spawn = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            falar = true;
        }
    }

    public void ConversaInicial(int i)
    {

        if (i == 0)
        {
            conversa.text = "Olá meu jovem, eu vou lhe ensinar o básico para sobreviver a este mundo cruel!!!\n" +
                "Tudo bem, vamos começar com os comandos básicos, vou direto ao assunto para não tornar a sua experiencia ruim!\n Movimentação: [W, A, S, D] " +
                "\nAtaque Básico: Tecla [1]\n" +
                "Para utilizar as Skills (Somente após aprender alguma) teclas [2, 3, 4, 5, 6]\n" +
                "Para abrir/fechar o inventario [I]\n" +
                "Para ativar uma SKILL [O]\n" +
                "Para pegar itens no chão e conversar com NPCS [E, F]";
        }
        if (i == 1)
        {
            conversa.text = "Vamos fazer assim, tenho uma missão para você, pegue está espada que jogarei no chão ( APERTE [E] PARA PEGAR DO CHÃO) e bata no saco de pancadas até ele desaparecer, quando concluir a missão, volte aqui que lhe ensinarei outras coisinhas!";
            descricao.text = "-Pegue a espada do chão\nAbra o inventario [i]\n-Equipe a espada\n-Mate pelo menos um boneco de treino";
        }
        if (i == 2)
        {
            tipoDeMissao = 1;
            Time.timeScale = defaultTimeScale;
            fala.gameObject.SetActive(false);
            dizendo = false;
            GameObject espadaa = Instantiate(espada, playert.position, playert.rotation);
            espada.GetComponent<ArmasBehaviour>().GerarAleatorio(0);
            PlayerStatsController.AddXp(150);
            missao0 = false;
        }
    }

    public void ConversaAposPrimeiraMissão(int i)
    {
            if (i == 3)
            {
                conversa.text = "Meus parabéns, você bateu em um boneco sem vida, parece que você está se tornando um nobre guerreiro, não é mesmo?";
            }
            if (i == 4)
            {
                conversa.text = "Tudo bem, agora vou lhe dizer sobre o sistema de reputação, antes de você continuar a seguir seu destino.\n" +
                    "Nós desenvolvemos um sistema de reputação, que serve para você jovem, mostrar que é capaz de honrar com seus serviços e " +
                    "trazer a paz tão esperada a Grutópolis.";
            }
            if(i == 5)
            {
                conversa.text = "Como funciona? hmmm... digamos que assim:\n" +
                    "Para obter uma melhor reputação, conclua missões com pessoas na cidade ou fora dela, você saberá que pode fazer uma missão deste tipo" +
                    "quando aparecer um interrogação em cima da cabeça da pessoa.. Estranho não? Mas enfim, ao concluir uma missão bem sucedida, você nobre guerreiro pode ganhar pontos de reputação, mas cuidado, caso você não consiga concluir a missão você irá perder pontos." +
                    "Ahh já ia me esquecendo, quem possui pontos de reputação inferior a -20 é forçado a se retirar do jogo!";
            }
            if(i == 6)
            {
                conversa.text = "Você deveria começar comigo, vou lhe dar uma missão!";
            }
            if (i == 7)
            {
                conversa.text = "Um morcego horripilante entrou na sala de treinamento e sua nova missão é acabar com ele." +
                    " Lhe darei apenas 1 ponto de reputação, mas é porque está missão é muito facil...\n Tome aqui, lhe darei roupas novas para lhe ajudar nesta jornada, pois está frio lá fora. Além disto, lhe darei uma poção! Utilize-a com sabedoria :)\n" +
                    "Pegue os itens do chão pressionando [E]";
            }
        if (i == 8)
        {
            conversa.text = "Ahhh, ja ia me esquecendo..\n Não é necessario voltar aqui após matar o morcego, siga em frente e fale com o chefe de vila, ele te dirá os proximos passos! Boa sorte amigo!";
            descricao.text = "\n OPCIONAL\n-Pegue os itens do chão\nAbra o inventario [i]\n-Equipe os itens\n-Mate o morcego\n-Vá até uma banca e compre poções de vida\n -Procure um npc na cidade para fazer missões";

            if (spawn)
            {
                GameObject morcegoo = Instantiate(morcego, new Vector3(-274.51f, -222.33f, -1.45f), Quaternion.identity);
                GameObject elmoo = Instantiate(elmo, playert.position, playert.rotation);
                elmoo.GetComponent<ElmoGuerreiro>().GerarAleatorio(0);
                GameObject peitoo = Instantiate(peito, playert.position, playert.rotation);
                peito.GetComponent<PeitoGuerreiro>().GerarAleatorio(0);
                GameObject calcaa = Instantiate(calça, playert.position, playert.rotation);
                calcaa.GetComponent<CalçaGuerreiro>().GerarAleatorio(0);
                GameObject luvaa = Instantiate(luva, playert.position, playert.rotation);
                luvaa.GetComponent<LuvaGuerreiro>().GerarAleatorio(0);
                GameObject botaa = Instantiate(bota, playert.position, playert.rotation);
                botaa.GetComponent<BotaGuerreiro>().GerarAleatorio(0);
                GameObject potion1 = Instantiate(potion, playert.position, playert.rotation);
                potion1.SetActive(true);
                GameObject potion2 = Instantiate(potion, playert.position, playert.rotation);
                potion2.SetActive(true);
                GameObject potion3 = Instantiate(potion, playert.position, playert.rotation);
                potion3.SetActive(true);
                GameObject potion4 = Instantiate(potion, playert.position, playert.rotation);
                potion4.SetActive(true);
                GameObject potion5 = Instantiate(potion, playert.position, playert.rotation);
                potion5.SetActive(true);
                GameObject potion6 = Instantiate(potion, playert.position, playert.rotation);
                potion6.SetActive(true);
                PlayerStatsController.AddXp(50);

                spawn = false;
            }
        }
            if (i == 9)
            {
            Time.timeScale = defaultTimeScale;
            dizendo = false;
            fala.gameObject.SetActive(false);
            }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            falar = false;
            abrirJanela.gameObject.SetActive(false);
        }
    }
    

    void Start () {
        abrirJanela.gameObject.SetActive(false);
        fala.gameObject.SetActive(false);
        i = 0;
    }


    public void Conversando()
    {
        if (falar)
        {
            abrirJanela.text = "Pressione [F] para conversar";
            if (Input.GetKeyDown(KeyCode.F))
            {
                fala.gameObject.SetActive(true); // liga e desliga o inventario
                nomeNpc.text = "Treinador";
                dizendo = true;
                if (missao0)
                {
                    conversa.text = "Olá meu jovem, eu vou lhe ensinar o básico para sobreviver a este mundo cruel!!!\n" +
                "Tudo bem, vamos começar com os comandos básicos, vou direto ao assunto para não tornar a sua experiencia ruim!\n Movimentação: [W, A, S, D] " +
                "\nAtaque Básico: Tecla [1]\n" +
                "Para utilizar as Skills (Somente após aprender alguma) teclas [2, 3, 4, 5, 6]\n" +
                "Para abrir/fechar o inventario [I]\n" +
                "Para ativar uma SKILL [O]\n" +
                "Para pegar itens no chão e conversar com NPCS [E, F]";
                }
                if (missao1)
                {
                    conversa.text = "Meus parabéns, você bateu em um boneco sem vida, parece que você está se tornando um nobre guerreiro, não é mesmo?";
                }
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
            
        }
        /*if (missao1)
        {
            falar = true;
        }*/
        if (dizendo)
        { 
            falar = false;
            if (Input.GetKeyUp(KeyCode.KeypadEnter) && fala.gameObject.activeSelf)
            {
                i++;

                if (i <= 2 && fala.gameObject.activeSelf && missao1 == false)
                {

                    ConversaInicial(i);
                }

                else if (i > 2 && i <= 9 && fala.gameObject.activeSelf && missao1 == true)
                {
                    ConversaAposPrimeiraMissão(i);
                }
                else if (fala.gameObject.activeSelf && i > 10)
                {
                    Time.timeScale = defaultTimeScale;
                    fala.gameObject.SetActive(false);
                }
            }
        }
    }

    private void Update()
    {

        if (missao0)
        {
            Conversando();
        }
        else if (missao1)
        {
            Conversando();
        }
        

    }

}
