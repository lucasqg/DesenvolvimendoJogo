using System.Collections;
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

    public void Inicialization()
    {
        currentLife = basicStats.startLife;
        totalLife = currentLife;
        currentMana = basicStats.mana;
        totalMana = currentMana;
        currentStamina = basicStats.startStamina;
        totalStamina = basicStats.startStamina;
    }

    public override void OnDestroyed()
    {
        //throw new System.NotImplementedException();
    }
}
