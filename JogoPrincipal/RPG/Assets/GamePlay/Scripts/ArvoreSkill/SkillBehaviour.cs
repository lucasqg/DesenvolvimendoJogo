﻿using System.Collections;
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
                descricao.text = "Explode o campo em que a espada passar, causando o dobro de dano";
            }
            else if (tipoDeSkill.code == 2)
            {
                descricao.text = "Desfere 3 golpes rapidamente causando o triplo de dano de um ataque comum";
            }
            else if (tipoDeSkill.code == 3)
            {
                descricao.text = "Libera um spray reveitalizante que lhe permite ganhar defesa por um determinado tempo";
            }
            else if (tipoDeSkill.code == 4)
            {
                descricao.text = "Percebe-se que a vida não é so isto, ao habilitar esta passiva você ganha uma certa quantidade de HP permanentemente";
            }
            else if (tipoDeSkill.code == 5)
            {
                descricao.text = "Por que ficar atacando de perto se posso jogar a espada?\n Atira a espada para sua frente, causando dano na área em que passar";
            }
            else if (tipoDeSkill.code == 6)
            {
                descricao.text = "Parece que isto funciona como uma academia sem esteroides, ao ativa-lá você ganha força permanentemente";
            }
            else if (tipoDeSkill.code == 7)
            {
                descricao.text = "Cada primeiro ataque de um monstro lhe causará a metade de sua vida ";
            }
            else if (tipoDeSkill.code == 8)
            {
                descricao.text = "Seu sangue ferve no campo de batalha." +
                    "\nApartir daqui, você recebe um pouco de Vida e Stamina a cada 5 segundo";
            }
            else if (tipoDeSkill.code == 9)
            {
                descricao.text = "Sua espada gira em seu redor por 3 segundos causando dano a quem estiver perto";
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
                    tipoDeSkill.ativaImagemSemCadeado(DH);
                    tipoDeSkill = null;
                }
            }
            else if( tipoDeSkill.code == 1)
            {
                // Explosion
                if(explosion == false)
                {
                    Explosion();
                    tipoDeSkill.ativaImagemSemCadeado(EX);
                    tipoDeSkill = null;
                }
            }
            else if (tipoDeSkill.code == 2)
            {
                // hit Triplo
                if (hitTriplo == false)
                {
                    HitTriplo();
                    tipoDeSkill.ativaImagemSemCadeado(TH);
                    tipoDeSkill = null;
                }
            }
            else if (tipoDeSkill.code == 3)
            {
                // buff defesa
                if (buffDefesa == false)
                {
                    BuffDefesa();
                    tipoDeSkill.ativaImagemSemCadeado(BD);
                    tipoDeSkill = null;
                }
            }
            else if (tipoDeSkill.code == 4)
            {
                // aumento hp
                if (aumentoHP == false)
                {
                    AumentoHP();
                    tipoDeSkill.ativaImagemSemCadeado(AH);
                    tipoDeSkill = null;
                }
            }
            else if (tipoDeSkill.code == 5)
            {
                // lança espada
                if (lançarEspada == false)
                {
                    LançarEspada();
                    tipoDeSkill.ativaImagemSemCadeado(LE);
                    tipoDeSkill = null;
                }
            }
            else if (tipoDeSkill.code == 6)
            {
                // aumento atack guerreiro
                if (aumentoAtackGuerreiro == false)
                {
                    AumentoAtackGuerreiro();
                    tipoDeSkill.ativaImagemSemCadeado(AAG);
                    tipoDeSkill = null;
                }
            }
            else if (tipoDeSkill.code == 7)
            {
                // passiva de ivunerabilidade
                if (passivaIvulnerabilidade == false)
                {
                    PassivaIvulnerabilidade();
                    tipoDeSkill.ativaImagemSemCadeado(PIB);
                    tipoDeSkill = null;
                }
            }
            else if (tipoDeSkill.code == 8)
            {
                // passiva de ivunerabilidade
                if (regeneracaoHPStamina == false)
                {
                    RegeneraçãoHPStamina();
                    tipoDeSkill.ativaImagemSemCadeado(RH);
                    tipoDeSkill = null;
                }
            }
            else if (tipoDeSkill.code == 9)
            {
                // passiva de ivunerabilidade
                if (giroDoInfinito == false)
                {
                    GiroDoInfinito();
                    tipoDeSkill.ativaImagemSemCadeado(GI);
                    tipoDeSkill = null;
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
