﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStatsNpc
{
    public float startLife; //vida inicial
    public float startStamina;
    public float mana;
    public int forca;
    public int inteligencia;
    public int precisão;
    public int baseDefense;
    public int baseAttack;
    public string nameNpc;
}
public class NpcBase : NpcDestructiveBase {
    public int currentLevel;
    public BasicStatsNpc basicStats;

    protected void Start()
    {
        Inicialization();
    }

    protected void Update()
    {
        DestroiMonster();   // testa se o monstro deve morrer
    }

    public void Inicialization()
    {
        currentLife = basicStats.startLife;
        totalLife = currentLife;
        currentMana = basicStats.mana;
        totalMana = currentMana;
        currentStamina = basicStats.startStamina;
        totalStamina = basicStats.startStamina;
    }

    public void applyDamage(int danoMin, int danoMax)
    {

        int random = Random.Range(1, 2);
        if(random == 1)
        {
            if((defesaTotal - danoMin) > 0 )
                currentLife = currentLife - (defesaTotal - danoMin);
        }
        else if(random == 2)
        {
            if ((defesaTotal - danoMax) > 0)
                currentLife = currentLife - (defesaTotal - danoMax);
        }
    }

    public void DestroiMonster()
    {
        if(currentLife < 0)
        {
            Destroy(this);
        }
    }
    public override void OnDestroyed()
    {
        //throw new System.NotImplementedException();
    }
}
