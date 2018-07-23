using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public PolygonCollider2D colisor;
    public NpcBase monstro;
    public CidadãoMutante cidadao;
    public BonecoDeTreino boneco;
    public PlayerBehaviour player;
    public MorcegoMutado morcego;
    public bool explosionActivation;
    public GameObject explosion;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
    }

    public void applyDamageMonster(NpcBase monster)
    {
        if (explosionActivation)
        {
            monster.IstantiateExplosion(explosion);
            explosionActivation = false;
            monster.applyDamage(player.danoTotal + 4, player.danoTotal + 4);
        }
        else
            monster.applyDamage(player.danoTotal, player.danoTotal);
    }
   
    public void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.tag == "CidadaoMutante" && collision.GetComponent<BoxCollider2D>() == collision)
            {
                Debug.Log("Cidadao Mutante levando DAMAGE");
                player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
                applyDamageMonster(collision.GetComponent<NpcBase>());
            }
        else if (collision.tag == "Esqueleto" && collision.GetComponent<BoxCollider2D>() == collision)
            {
                applyDamageMonster(collision.GetComponent<NpcBase>());
            }
        else if (collision.tag == "LoboDecomposto" && collision.GetComponent<BoxCollider2D>() == collision)
            {
                applyDamageMonster(collision.GetComponent<NpcBase>());
            }
        else if(collision.tag == "LoboSelvagem" && collision.GetComponent<BoxCollider2D>() == collision)
            {
                applyDamageMonster(collision.GetComponent<NpcBase>());
            }
        else if(collision.tag == "Morcego" && collision.GetComponent<BoxCollider2D>() == collision)
            {
            Debug.Log("Morcego levando DANO");
            player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
            applyDamageMonster(collision.GetComponent<NpcBase>());
        }
        else if (collision.tag == "RatoMutado" && collision.GetComponent<BoxCollider2D>() == collision)
        {
            applyDamageMonster(monstro);
        }
        else if(collision.tag == "BonecoDeTreino" && collision.GetComponent<BoxCollider2D>() == collision)
        {
            Debug.Log("Saco de pancadas levando DANO");
            player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
            applyDamageMonster(collision.GetComponent<NpcBase>());
        }

    }
}
