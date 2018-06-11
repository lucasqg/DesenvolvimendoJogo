using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBehaviour : MonoBehaviour {

    public PlayerBehaviour player;
    public List<string> skillType;

    public Sprite iconSkillWarrior;
    public Sprite iconSkillPistoleiro;
    public Sprite iconSkillBomber;
    public Button botão;

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
            //habilita animação skill ativada
        }
        else
        {
            //informa pontos skill insuficientes;
        }
    }

    // FIM SKILLS GUERREIRO




}
