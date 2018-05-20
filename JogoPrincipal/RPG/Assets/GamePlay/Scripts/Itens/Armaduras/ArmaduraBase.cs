using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaduraBase : ItensBase {
    //atributos básicos
    public int defesaBase;
    public int minLevel;
    public int minFor;
    public int minPres;
    public int minInt;
    //atributos adicionais
    public int adicionalHP;
    public int adicionalDano;
    public int adicionalMago;
    public int adicionalDefesa;
    public float velocidadeMovimento;


    public override void TxtAtributos()
    {
        UIController.instancer.atributosItens.text = "\n"; // apaga tudo
        if (defesaBase > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "Defesa: " + defesaBase.ToString();
        }
        if (velocidadeMovimento > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nVelocidade de Movimento: " + velocidadeMovimento.ToString();
        }
        if (minLevel >= 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nNivel Minimo: " + minLevel.ToString();
        }
        if (minFor > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nForça minima: " + minFor.ToString();
        }
        if (minPres > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nPrecisão minima: " + minPres.ToString();
        }
        if (minInt > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nInteligência minima: " + minInt.ToString();
        }
        if(adicionalHP > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nHP adicional: " + adicionalHP.ToString();
        }
        if (adicionalDano > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nDano adicional: " + adicionalDano.ToString();
        }
        if (adicionalDefesa > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nDefesa adicional: " + adicionalDefesa.ToString();
        }
        if (adicionalMago > 0)
        {
            UIController.instancer.atributosItens.text = UIController.instancer.atributosItens.text + "\nMagia adicional: " + adicionalMago.ToString();
        }
    }
}
