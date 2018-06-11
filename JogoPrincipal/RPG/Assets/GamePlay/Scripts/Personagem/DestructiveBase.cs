
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestructiveBase : MonoBehaviour {
    //dos status base:
    public float currentLife;
    public float totalLife;
    public float currentMana;
    public float totalMana;
    public float currentStamina;
    public float totalStamina;
    public int currentSkills;
    //das armas:
    public int danoTotal;
    public float velTotal;
    public float defTotal;
    // atributos variaveis a arma/set
    public SlotEquipavel arma, elmo, peito, bota, luva, calça, colar, anel1, anel2;

	void Start () {
        

    }
	
	void Update () {
		
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


    public abstract void OnDestroyed();
} 
