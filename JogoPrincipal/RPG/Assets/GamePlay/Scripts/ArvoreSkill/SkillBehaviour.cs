using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBehaviour : MonoBehaviour {
    public PlayerBehaviour player;
    public List<string> skillType;
    public AtivadorEspada espada;
    public Sprite iconCadeado;
    public Sprite DH, EX, TH, BD, AH, LE, AAG, PIB, RH, GI;
    public Button botão;
    public bool explosion = false;
    public bool hitDuplo = false;
    public bool hitTriplo = false;
    public bool buffDefesa = false;
    public bool aumentoHP = false;
    public bool lançarEspada = false;
    public bool aumentoAtackGuerreiro = false;
    public bool regeneracaoHPStamina = false;
    public bool passivaIvulnerabilidade = false;
    public bool giroDoInfinito = false;
    //public SkillAtivador um, dois, tres, quatro, cinco, seis;
    public SkillAtivador tipoDeSkill;

    //UI
    public Text descricao;
    public Text pontos;
    public void Start()
    {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
    }
    public void Update() { 
        DescricaoDeSkill();
        pontos.text = player.currentSkills.ToString();
        //pontos.text = PlayerStatsController.GetCurrentPontosSkill().ToString();
        
    }
    public void SelectedSkill(SkillAtivador Selecionado)
    {
        tipoDeSkill = Selecionado;
    }

    public void DescricaoDeSkill()
    {
        if (tipoDeSkill != null)
        { 
            if(tipoDeSkill.code == 0)
            {
                descricao.text = "Desfere 2 golpes rapidamente causando um dano duplo";
            }
            else if(tipoDeSkill.code == 1)
            {
                descricao.text = "Explode o monstro em que a espada tocar, causando um certo dano adicional";
            }
            else if (tipoDeSkill.code == 2)
            {
                descricao.text = "Desfere 3 golpes rapidamente causando o triplo de dano de um ataque comum";
            }
            else if (tipoDeSkill.code == 3)
            {
                descricao.text = "Libera um spray reveitalizante que lhe permite ganhar defesa para sempre";
            }
            else if (tipoDeSkill.code == 4)
            {
                descricao.text = "Percebe-se que a vida não é so isto, ao habilitar esta passiva você ganha uma certa quantidade de HP permanentemente";
            }
            else if (tipoDeSkill.code == 5)
            {
                descricao.text = "Sua espada gira ao seu redor causando dano a quem estiver por perto";
            }
            else if (tipoDeSkill.code == 6)
            {
                descricao.text = "Parece que isto funciona mesmo, ao ativa-lá você ganha dano permanentemente";
            }
            else if (tipoDeSkill.code == 7)
            {
                descricao.text = "Cada primeiro ataque de um monstro lhe causará a metade de sua vida ";
            }
            else if (tipoDeSkill.code == 8)
            {
                descricao.text = "Seu sangue ferve no campo de batalha." +
                    "\nApartir daqui, você recebe um pouco de Vida e Stamina a cada intervalo de um certo tempo";
            }
            else if (tipoDeSkill.code == 9)
            {
                descricao.text = "Sua espada chama suas amigas que giram em seu redor por determinado tempo causando dano a quem encostar nelas";
            }
        }

    
    }

    public void CompraSkill()
    {
        if(tipoDeSkill != null)
        {
            if(tipoDeSkill.code == 0)
            {
                //duplo hit
                if (hitDuplo == false)
                {
                    HitDuplo();
                    
                }
            }
            else if( tipoDeSkill.code == 1)
            {
                // Explosion
                if(explosion == false)
                {
                    Explosion();
                    
                }
            }
            else if (tipoDeSkill.code == 2)
            {
                // hit Triplo
                if (hitTriplo == false)
                {
                    HitTriplo();
                }
            }
            else if (tipoDeSkill.code == 3)
            {
                // passiva defesa
                if (buffDefesa == false)
                {
                    BuffDefesa();
                }
            }
            else if (tipoDeSkill.code == 4)
            {
                // aumento hp
                if (aumentoHP == false)
                {
                    AumentoHP();
                }
            }
            else if (tipoDeSkill.code == 5)
            {
                // lança espada
                if (lançarEspada == false)
                {
                    LançarEspada();
                }
            }
            else if (tipoDeSkill.code == 6)
            {
                // aumento atack guerreiro
                if (aumentoAtackGuerreiro == false)
                {
                    AumentoAtackGuerreiro();
                }
            }
            else if (tipoDeSkill.code == 7)
            {
                // passiva de ivunerabilidade
                if (passivaIvulnerabilidade == false)
                {
                    PassivaIvulnerabilidade();
                }
            }
            else if (tipoDeSkill.code == 8)
            {
                // passiva de ivunerabilidade
                if (regeneracaoHPStamina == false)
                {
                    RegeneraçãoHPStamina();
                }
            }
            else if (tipoDeSkill.code == 9)
            {
                // regeneração HP e Stamina
                if (giroDoInfinito == false)
                {
                    GiroDoInfinito();
                }
            }
        }
    }
    //Arvores skill class guerreiro
    //variaveis de cada classe:
    public void HitDuplo()
    {
        if(player.currentSkills >= 1)
        {
            player.currentSkills--;     //retiro 1 ponto skill
            skillType.Add("HitDuplo");  //adiciona o skill duplo 
            hitDuplo = true;
            //habilita animação skill ativada
            //um.ativaImagem(iconGuerreiro1);
            tipoDeSkill.ativaImagemSemCadeado(DH, true);
            tipoDeSkill = null;
        }
        else  
        {
            //informa pontos skill insuficiente;
        }
    }

    // INICIO SKILL GUERREIRO
    public void Explosion()
    {
        if(player.currentSkills >= 1)
        {
            player.currentSkills--;
            skillType.Add("Explosion");
            explosion = true; //ativa a skill 
            //habilita animação skill ativada
            tipoDeSkill.ativaImagemSemCadeado(EX, true);
            tipoDeSkill = null;
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void HitTriplo()
    {

        
        if (player.currentSkills >= 2 && hitDuplo==true)
        {
            player.currentSkills -= 2;
            skillType.Add("HitTriplo");
            hitTriplo = true;

            tipoDeSkill.ativaImagemSemCadeado(TH, true);
            tipoDeSkill = null;
            //habilita animação skill ativada
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void BuffDefesa()//
    {
        if (player.currentSkills >= 2 && hitDuplo == true && explosion == true)
        {
            player.currentSkills -= 2;
            skillType.Add("BuffDefesa");
            buffDefesa = true;

            player.defTotal += 4;
            tipoDeSkill.ativaImagemSemCadeado(BD, false);
            tipoDeSkill = null;
            //habilita animação skill ativada
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void AumentoHP()//
    {
        if (player.currentSkills >= 1 && explosion == true)
        {
            player.currentSkills -= 2;
            skillType.Add("AumentoHP");
            aumentoHP = true;

            player.totalLife += 20;
            tipoDeSkill.ativaImagemSemCadeado(AH, false);
            tipoDeSkill = null;
            //habilita animação skill ativada
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void LançarEspada()//
    {
        if (player.currentSkills >= 3 && hitTriplo == true)
        {
            player.currentSkills -= 3;
            skillType.Add("LançarEspada");
            lançarEspada = true;

            tipoDeSkill.ativaImagemSemCadeado(LE, true);
            tipoDeSkill = null;
            //habilita animação skill ativada
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }
    public void AumentoAtackGuerreiro()//
    {
        if (player.currentSkills >= 3 && hitTriplo== true && buffDefesa== true)
        {
            player.currentSkills -= 3;
            skillType.Add("AumentoAtack");
            aumentoAtackGuerreiro = true;

            player.danoTotal += 3;
            tipoDeSkill.ativaImagemSemCadeado(AAG, false);
            tipoDeSkill = null;
            //habilita animação skill ativada
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void PassivaIvulnerabilidade()//
    {

        if (player.currentSkills >= 3 && buffDefesa == true && aumentoHP == true)
        {
            player.currentSkills -= 3;
            skillType.Add("Ivulnerabilidade");
            passivaIvulnerabilidade = true;

            tipoDeSkill.ativaImagemSemCadeado(PIB, false);
            tipoDeSkill = null;
            //habilita animação skill ativada
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

     public void RegeneraçãoHPStamina()//
    {
        if (player.currentSkills >= 3 && aumentoHP == true)
        {
            player.currentSkills -= 3;
            skillType.Add("RegeneraçãoHPStamina");
            regeneracaoHPStamina = true;

            tipoDeSkill.ativaImagemSemCadeado(RH, false);
            tipoDeSkill = null;
            //habilita animação skill ativada
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void GiroDoInfinito()
    {
        if (player.currentSkills >= 2 && lançarEspada == true && aumentoHP == true && passivaIvulnerabilidade == true && regeneracaoHPStamina == true)
        {
            player.currentSkills -= 3;
            skillType.Add("GiroDoInfinito");
            giroDoInfinito = true;

            tipoDeSkill.ativaImagemSemCadeado(GI, true);
            tipoDeSkill = null;
            //habilita animação skill ativada
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    public void AtivarDuploHit()
    {
        espada.AtivadorHitSkill(2);
    }
    public void AtivadorTriploHit()
    {
        espada.AtivadorHitSkill(3);
    }
    public void AtivadorExplosion()
    {

    }
    public void ativadorLançarEspada()
    {
       
    }
    public void AtivadorGiroDoInfinito()
    {

    }
    //ativador de skill
    // FIM SKILLS GUERREIRO




}
