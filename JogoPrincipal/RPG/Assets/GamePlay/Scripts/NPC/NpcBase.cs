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
    public GameObject moeda, potionHP;
    public PlayerBehaviour player;
    private bool morto;
    public bool explosionIsActive;

    public void IstantiateExplosion(GameObject explosion)
    {
        GameObject explosionObject = Instantiate(explosion, this.transform.position, this.transform.rotation);
    }
    public virtual void InicializacaoDeStatus()
    {
        // status atribuido dentro do monstro
    }


    public virtual void Start()
    {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
    }

    public virtual void Update()
    {
        DestroiMonster();   // testa se o monstro deve morrer
    }

    public void Inicialization()
    {
        currentLife = basicStats.startLife;
        totalLife = basicStats.startLife;
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
        if(currentLife <= 0 && !morto)
        {
            morto = true;
            DropItem();
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

    public virtual void DropItem()
    {
        int random = Random.Range(1, 10);
        if (random == 2) //10% chance de acertar o valor
        {
            GameObject mooeda =Instantiate(moeda, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
        }
        int randomico = Random.Range(1, 8);
        if (randomico == 1) //10% chance de acertar o valor
        {
            Instantiate(potionHP, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity).SetActive(true);
        }
        Destroy(this.gameObject);
    }
}
