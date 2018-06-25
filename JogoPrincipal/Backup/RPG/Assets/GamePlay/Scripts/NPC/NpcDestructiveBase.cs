using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NpcDestructiveBase : MonoBehaviour {
    //dos status base:
    public float currentLife;
    public float totalLife;
    public float currentMana;
    public float totalMana;
    public float currentStamina;
    public float totalStamina;
    public int defesaTotal;
    public int danoTotal;
    public int velTotal;

    void Start()
    {

    }

    void Update()
    {

    }

    public void addLife(int life)  //o mob se cura??
    {
        currentLife += life;
        if (currentLife > totalLife)
        {
            currentLife = totalLife;
        }
    }

    public void addMana(int mana) // o mob possui mana?
    {
        currentMana += mana;
        if (currentMana > totalMana)
        {
            currentMana = totalMana;
        }
    }

    public void addStamina(int stamina) // o mob possui stamina?
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
