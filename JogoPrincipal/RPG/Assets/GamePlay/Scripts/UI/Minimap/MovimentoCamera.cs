using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoCamera : MonoBehaviour {

    public Transform player;

    private void LateUpdate()
    {
        Vector3 NovaPosicao = player.position;
        NovaPosicao.y = player.position.y;
        transform.position = NovaPosicao;

    }
}
