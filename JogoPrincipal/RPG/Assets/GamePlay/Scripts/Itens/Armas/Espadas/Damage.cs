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
    // Use this for initialization
    void Start () {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;

    }

    public void applyDamageMonster(NpcBase monster)
    {
        monster.applyDamage(player.danoTotal -2, player.danoTotal);
    }
   
    public void OnTriggerExit2D(Collider2D collision)
    {
       
            if (collision.tag == "CidadaoMutante")
            {
                Debug.Log("Cidadao Mutante levando DAMAGE");
                cidadao = FindObjectOfType(typeof(CidadãoMutante)) as CidadãoMutante;
                player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
                applyDamageMonster(cidadao);
            }
            else if (collision.tag == "Esqueleto")
            {
                applyDamageMonster(monstro);
            }
        else if (collision.tag == "LoboDecomposto")
            {
                applyDamageMonster(monstro);
            }
        else if(collision.tag == "LoboSelvagem")
            {
                applyDamageMonster(monstro);
            }
        else if(collision.tag == "Morcego")
            {
            Debug.Log("Morcego levando DANO");
            morcego = FindObjectOfType(typeof(MorcegoMutado)) as MorcegoMutado;
            player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
            applyDamageMonster(morcego);
        }
        else if (collision.tag == "RatoMutado")
        {
            applyDamageMonster(monstro);
        }
        else if(collision.tag == "BonecoDeTreino")
        {
            Debug.Log("Saco de pancadas levando DANO");
            boneco = FindObjectOfType(typeof(BonecoDeTreino)) as BonecoDeTreino;
            player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
            applyDamageMonster(boneco);
        }

    }
}
