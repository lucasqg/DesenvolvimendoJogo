using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBehaviour : MonoBehaviour {
    public PlayerBehaviour player;
    public List<string> skillType;
    public AtivadorEspada espada;
    public Sprite iconCadeado;
    public Sprite iconGuerreiro1, iconGuerreiro2, iconGuerreiro3, iconGuerreiro4, iconGuerreiro5, iconGuerreiro6;
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
    public SkillAtivador um, dois, tres, quatro, cinco, seis;
    public SkillAtivador tipoDeSkill;
    public void Start()
    {
        
    }
    public void Update()
    {
        
    }

    public void DescricaoDeSkill()
    {
        // aki fica a descricao das skills
    }

    public void CompraSkill()
    {
        if(tipoDeSkill != null)
        {
            DescricaoDeSkill();
            if(tipoDeSkill.code == 0)
            {
                //duplo hit
                if (hitDuplo == false)
                {
                    HitDuplo();
                    tipoDeSkill = null;
                }
            }
            else if( tipoDeSkill.code == 1)
            {
                // Explosion
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
            um.ativaImagem(iconGuerreiro1);
        }
        else  
        {
            //informa pontos skill insuficiente;
        }
    }

    public void TiposDeSkill() // apresenta na arvore de skill todas imagens
    {/*
        if(player.GetType().ToString() == "Guerreiro")
        {
            botão.image.overrideSprite = iconSkillWarrior;
        }
        else if (player.GetType().ToString() == "Pistoleiro")
        {
            botão.image.overrideSprite = iconSkillPistoleiro;
        }
        else if(player.GetType().ToString() == "Bomber")
        {
            botão.image.overrideSprite = iconSkillBomber;
        }
        else
        {
            botão.image.overrideSprite = iconSkillWarrior;
        }*/
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

    public void BuffDefesa()
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

    public void AumentoHP()
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

    public void LançarEspada()
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
    public void AumentoAtackGuerreiro()
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

    public void PassivaIvulnerabilidade()
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

     public void RegeneraçãoHPStamina()
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
