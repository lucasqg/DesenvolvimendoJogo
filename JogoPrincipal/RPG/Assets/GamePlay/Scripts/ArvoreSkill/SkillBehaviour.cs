using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBehaviour : MonoBehaviour {
    public PlayerBehaviour player;
    public List<string> skillType;
    public AtivadorEspada espada;
    public Sprite iconSkillWarrior;
    public Sprite iconSkillPistoleiro;
    public Sprite iconSkillBomber;
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

    public void Start()
    {
        botão.image.overrideSprite = iconSkillWarrior;
    }
    public void Update()
    {
        botão.image.sprite = iconSkillWarrior;
    }
    //Arvores skill class guerreiro
    //variaveis de cada classe:
    public void HitDuplo()
    {
        if(player.currentSkills >= 1)
        {
            player.currentSkills--;     //retiro 1 ponto skill
            skillType.Add("HitDuplo");  //adiciona o skill duplo 
            //habilita animação skill ativada
        }
        else  
        {
            //informa pontos skill insuficiente;
        }
    }

    public void TiposDeSkill() // apresenta na arvore de skill todas imagens
    {
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
        int valorTeste = 0;
        foreach (string skillz in skillType)
        {
            if(skillz == "HitDuplo") // verifica se a skill anterior já foi aprendida
            {
                valorTeste++;
            }
        }
        if (player.currentSkills >= 2 && valorTeste==1)
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
        int valorTeste = 0;
        foreach (string skillz in skillType)
        {
            if (skillz == "HitDuplo")
            {
                valorTeste++;
            }
            if(skillz == "Explosion")
            {
                valorTeste++;
            }
        }
        if (player.currentSkills >= 2 && valorTeste == 2)
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
        int valorTeste = 0;
        foreach (string skillz in skillType)
        {
            if (skillz == "Explosion")
            {
                valorTeste++;
            }
            
        }
        if (player.currentSkills >= 1)
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
        int valorTeste = 0;
        foreach (string skillz in skillType)
        {
            if (skillz == "HitTriplo")
            {
                valorTeste++;
            }
        }
        if (player.currentSkills >= 3 && valorTeste ==1)
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
        int valorTeste = 0;
        foreach (string skillz in skillType)
        {
            if (skillz == "HitTriplo")
            {
                valorTeste++;
            }
            if (skillz == "BuffDefesa")
            {
                valorTeste++;
            }
        }
        if (player.currentSkills >= 3 && valorTeste == 2)
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
        int valorTeste = 0;
        foreach (string skillz in skillType)
        {
            if (skillz == "BuffDefesa")
            {
                valorTeste++;
            }
            if (skillz == "AumentoHP")
            {
                valorTeste++;
            }
        }

        if (player.currentSkills >= 3 && valorTeste==2)
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
        int valorTeste = 0;
        foreach (string skillz in skillType)
        {
            if (skillz == "AumentoHP")
            {
                valorTeste++;
            }
        }
        if (player.currentSkills >= 3 && valorTeste ==1)
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
        int valorTeste = 0;
        foreach (string skillz in skillType)
        {
            if (skillz == "LançarEspada")
            {
                valorTeste++;
            }
            if (skillz == "AumentoAtack")
            {
                valorTeste++;
            }
            if (skillz == "Ivulnerabilidade")
            {
                valorTeste++;
            }
            if (skillz == "RegeneraçãoHPStamina")
            {
                valorTeste++;
            }   
        }
        if (player.currentSkills >= 2 && valorTeste == 4)
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
