
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public abstract class DestructiveBase : MonoBehaviour {
    //dos status base:
    public float currentLife;
    public float totalLife;
    public float currentMana;
    public float totalMana;
    public float currentStamina;
    public float totalStamina;
    public int currentSkills;
    public int currentPontos;
    //das armas:
    public Image destructive; 
    public int danoTotal;
    public float velTotal;
    public float defTotal;
    // atributos variaveis a arma/set
    public SlotEquipavel arma, elmo, peito, bota, luva, calça, colar, anel1, anel2;

    //Controle de missões
    public List<int> missoes;

	void Start () {
        

    }
	
	void Update () {

    }
    public void MontarMissoes()
    {
        missoes.Add(0);
        missoes.Add(0);
        missoes.Add(0);
        missoes.Add(0);
    }
    
    public int GetNivelDeMissao(string missao) // 
    {
        if (missao == "Missão1" || missao == "missao1" || missao == "missão1" || missao == "missaoUM")
            return missoes[0];
        else if (missao == "Missão2" || missao == "missao2" || missao == "missão2" || missao == "missaoDOIS")
            return missoes[1];
        else if (missao == "Missão3" || missao == "missao3" || missao == "missão3" || missao == "missaoTRES")
            return missoes[2];
        else if (missao == "MissaoPrincipal" || missao == "missaoPrincipal" || missao == "MissãoPrincipal")
            return missoes[3];
        return 0;
    }

    public void SetNivelDeMissao(string missao) //adiciona 1 na missao que foi concluida
    {
        if (missao == "Missão1" || missao == "missao1" || missao == "missão1")
           missoes[0] +=1;
        else if (missao == "Missão2" || missao == "missao2" || missao == "missão2")
            missoes[1] += 1;
        else if (missao == "Missão3" || missao == "missao3" || missao == "missão3")
            missoes[2] += 1;
        else if (missao == "Missão4" || missao == "missao4" || missao == "missão4")
            missoes[3] += 1;
        else if (missao == "MissaoPrincipal" || missao == "missaoPrincipal" || missao == "MissãoPrincipal")
            missoes[4] += 1;
    }

    public void SetNivelDeMissaoTotal(string missao) //adiciona 1 na missao que foi concluida
    {
        if (missao == "Missão1" || missao == "missao1" || missao == "missão1")
            missoes[0] += 1;
        else if (missao == "Missão2" || missao == "missao2" || missao == "missão2")
            missoes[1] += 1;
        else if (missao == "Missão3" || missao == "missao3" || missao == "missão3")
            missoes[2] += 1;
        else if (missao == "Missão4" || missao == "missao4" || missao == "missão4")
            missoes[3] += 1;
        else if (missao == "MissaoPrincipal" || missao == "missaoPrincipal" || missao == "MissãoPrincipal")
            missoes[4] += 1;
    }

    public void SetTodasMissoes() //adiciona 1 na missao que foi concluida
    {
            missoes[0] = GetNivelDeMissao("missão1");
            missoes[1] = GetNivelDeMissao("missão2");
            missoes[2] = GetNivelDeMissao("missão3");
            missoes[3] = GetNivelDeMissao("missão4");
            missoes[4] = GetNivelDeMissao("missaoPrincipal");
    }

    public void addLife(int life)
    {
        currentLife += life; 
        if(currentLife > totalLife)
        {
            currentLife = totalLife;
        }
    }

    public void addMana(int mana)
    {
        currentMana += mana;
        if (currentMana > totalMana)
        {
            currentMana = totalMana;
        }
    }

    public void addStamina(int stamina)
    {
        currentStamina += stamina;
        if (currentStamina > totalStamina)
        {
            currentStamina = totalStamina;
        }
    }

    public void ApplayDamage(int damage)
    {
        currentLife -= damage;
        if (currentLife <= 0)
        {
            OnDestroyed();
        }
    }


    public void AppAtributosItens()
    {
       // elmo.currentItem
    }


    public void Destroyer()
    {
        
       
        if (currentLife <= 2)
        {
            destructive.gameObject.SetActive(true);
            
            Destroy(this.gameObject);

        }
    }

    public abstract void OnDestroyed();
} 
