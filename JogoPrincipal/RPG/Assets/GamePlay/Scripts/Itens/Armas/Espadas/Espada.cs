using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour {
    private int posicao;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            posicao = 1; // direita
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            posicao = 2; //esquerda
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            posicao = 3; //costas
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            posicao = 4; //frente
        }
    }
    public int GetPosicao()
    {
        return posicao;
    }
}
