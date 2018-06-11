using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public PolygonCollider2D colisor;
    public CidadãoMutante cidadao;
    public Esqueleto esqueleto;
    public LoboDecomposto loboDecomposto;
    public LoboSelvagem loboSelvagem;
    public MorcegoMutado morcego;
    public RatoMutado rato;
    public PlayerBehaviour player;
    // Use this for initialization
    void Start () {
		
	}
    public void applyDamageMonster(NpcBase monster)
    {
        monster.applyDamage(10, 100);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ois");
        if (collision.tag == "CidadaoMutante")
        {
            applyDamageMonster(cidadao);
        }
        if (collision.tag == "Esqueleto")
        {
            applyDamageMonster(esqueleto);
        }
        if (collision.tag == "LoboDecomposto")
        {
            applyDamageMonster(loboDecomposto);
        }
        if (collision.tag == "LoboSelvagem")
        {
            applyDamageMonster(loboSelvagem);
        }
        if (collision.tag == "MorcegoMutado")
        {
            applyDamageMonster(morcego);
        }
        if (collision.tag == "RatoMutado")
        {
            applyDamageMonster(rato);
        }
    }
}
