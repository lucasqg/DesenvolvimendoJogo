using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pergaminho : ItensBase {

    public int amountLiquid;
    private PlayerBehaviour player;

    private void Start()
    {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
    }
    public override void AfterUse()
    {
        Teletransporte();
        RemoveItem();
    }

    private void Teletransporte()
    {
        player.gameObject.transform.position = new Vector3(-0.78f,-30f, -0.28f);

    }

    public override void TxtAtributos()
    {
        UIController.instancer.atributosItens.text = "Pergaminho de teletransporte te leva em um instante para a cidade de Grutópolis";
    }
}
