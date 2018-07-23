using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pergaminho : ItensBase {

    private PlayerBehaviour player;

    private void Start()
    {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        valorDoItem = 3;
        identificacao = 2;
    }
    public override void AfterUse()
    {
        Teletransporte();
        RemoveItem();
    }

    private void Teletransporte()
    {
        player.gameObject.transform.position = new Vector3(-193.5f, -216f, -1.12f);

    }

    public override void TxtAtributos()
    {
        UIController.instancer.atributosItens.text = "Pergaminho de teletransporte te leva em um instante para a cidade de Grutópolis";
    }
}
