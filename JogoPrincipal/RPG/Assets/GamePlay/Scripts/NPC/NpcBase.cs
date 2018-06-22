using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStatsNpc
{
    public float startLife = 10; //vida inicial
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
    public string nameNPC;
    

    public virtual void Start()
    {
        Inicialization();
    }

    public virtual void Update()
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
            addLife(-(danoMin - defesaTotal));
        }
        else 
        {
            //if ((defesaTotal - danoMax) > 0)
            addLife(-(danoMax - defesaTotal));
        }
    }

    public virtual void DestroiMonster()
    {
        if(currentLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public override void OnDestroyed()
    {
        //throw new System.NotImplementedException();
    }
    public void Destroi()
    {
        Destroy(this.gameObject);
    }
}
