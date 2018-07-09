using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasBehaviour : ItensBase{
    //atributos minimos;
    private PlayerBehaviour player;

    public float velAtaque;
    public int danoBase;
    public int minLevel;
    public int minFor;
    public int minPres;
    public int minInt;
    //atributos adicionais
    public int adicionalHP;
    public int adicionalDano;
    public int adicionalMago;
    public int adicionalVel;
    

    private void Start()
    {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        GeraAtributos();
    }
    public override void TxtAtributos()
    {
        UIController.instancer.atributosItens.text ="\n"; // apaga tudo
        if(minLevel >= 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "Nivel Minimo: " + minLevel.ToString();
        }
        if (velAtaque > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text +"\nVelocidade de ataque: " + velAtaque.ToString();
        }
        if(danoBase > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nDano: " + danoBase.ToString();
        }
        if (minFor > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nForça minima: " + minFor.ToString();
        }
        if (minPres > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nPrecisão minima: " + minPres.ToString();
        }
        if(minInt > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nInteligência minima: " + minInt.ToString();
        }
    }
    public override void StatusArma()
    {
        player.danoTotal += adicionalDano + danoBase;
    }
    public void GeraAtributos()
    {
        danoBase= Random.Range(0, 4);
        adicionalDano = Random.Range(0, 5);
        adicionalHP = Random.Range(0, 20);
    }


}
