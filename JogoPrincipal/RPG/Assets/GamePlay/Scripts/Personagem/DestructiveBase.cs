
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
    //das armas:
    public float danoTotal;
    public float magiaTotal;
    public float velTotal;

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

    public abstract void OnDestroyed();
} 
