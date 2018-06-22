using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMonster : MonoBehaviour
{
    public PlayerBehaviour player;
    public NpcBase monstro;
    public int velAtack = 1500;
    public int ContadorDeTempo = 0;
    // Use this for initialization

    void Start () {
	}

    public void applyDamagePlayer(int dano)
    {
        player.addLife(-dano);
    }
    public void applyDamageNPC(int dano, Carroceiro carroceiro)
    {
        carroceiro.addLife(-dano);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        ContadorDeTempo += 1;

        if (collision.tag == "Player" && ContadorDeTempo>velAtack)
        {
            player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
            applyDamagePlayer(monstro.danoTotal);
            ContadorDeTempo = 0;
        }
        else if(collision.tag == "Carroceiro" && ContadorDeTempo > velAtack)
        {
            applyDamageNPC(monstro.danoTotal, collision.GetComponent<Carroceiro>());
            ContadorDeTempo = 0;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
