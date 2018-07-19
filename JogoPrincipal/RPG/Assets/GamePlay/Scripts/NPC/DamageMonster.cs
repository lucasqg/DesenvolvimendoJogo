using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMonster : MonoBehaviour
{
    public PlayerBehaviour player;
    public NpcBase monstro;
    public int ContadorDeTempo = 0;
    // Use this for initialization

    void Start () {
        monstro = this.GetComponent<NpcBase>();
	}

    public void applyDamagePlayer(int dano)
    {
        if(((int)player.defTotal - dano) < 0)
            player.addLife((int)player.defTotal - dano);
    }
    public void applyDamageNPC(int dano, Carroceiro carroceiro)
    {
            carroceiro.addLife(- dano);
    }
    public void applyDamageOvelha(int dano, SpawnLoboMissao2 ovelha)
    {
        if (((int)ovelha.defesaTotal - dano) < 0)
            ovelha.addLife((int)player.defTotal - dano);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        ContadorDeTempo += 1;

        if (collision.tag == "Player" && ContadorDeTempo > monstro.velTotal)
        {
            player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
            applyDamagePlayer(monstro.danoTotal);
            ContadorDeTempo = 0;
        }
        else if (collision.tag == "Carroceiro" && ContadorDeTempo > monstro.velTotal)
        {
            applyDamageNPC(monstro.danoTotal, collision.GetComponent<Carroceiro>());
            ContadorDeTempo = 0;
        }
        else if (this.gameObject.tag == "LoboSelvagem" && collision.tag == "Ovelha")
        {
            applyDamageOvelha(monstro.danoTotal, collision.GetComponent<SpawnLoboMissao2>());
            ContadorDeTempo = 0;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
