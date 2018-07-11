using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BasicStats
{
    public float startLife; //vida inicial
    public float startStamina;
    public float mana;
    public int forca;
    public int inteligencia;
    public int precisão;
    public int constituicao;
    public int baseDefense;
    public int baseAttack;
    public int pontosSkill;
}

public abstract class CharacterBase : DestructiveBase {
    public int currentLevel;
    public BasicStats basicStats;


    public void AtualizaçãoDeStatus()
    {
       /* danoTotal = danoTotal + (basicStats.forca / 10) ;
        danoTotal = danoTotal + (basicStats.precisão / 10);
        totalLife = basicStats.constituicao;*/
    }

    // Use this for initialization
    protected void Start () {
        Inicialization();
    }

    // Update is called once per frame
    protected void Update () {
        AtualizaçãoDeStatus();

    }

    public override void OnDestroyed()
    {
        //throw new System.NotImplementedException();
    }

    public void Inicialization()
    {
        currentLife = basicStats.startLife;
        totalLife = currentLife;
        currentMana = basicStats.mana;
        totalMana = currentMana;
        currentStamina = basicStats.startStamina;
        totalStamina = basicStats.startStamina;
        danoTotal = basicStats.baseAttack;
        defTotal = basicStats.baseDefense;
    }
}
