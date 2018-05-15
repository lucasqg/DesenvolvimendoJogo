using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada_Costas : MonoBehaviour
{
    public GameObject Espada__costas;
    public Transform Personagem;
    public GameObject Local;
    public int posicao=4;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        posicaoPlayer();

        if (Input.GetKeyDown(KeyCode.M)) {
            if (posicao == 3)
            {
                Instantiate(Espada__costas, transform.position,transform.rotation, Personagem);
            }
        }
        
    }

    public void posicaoPlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            posicao = 1; // direita
        }
        else if (Input.GetKey(KeyCode.A))
        {
            posicao = 2; //esquerda
        }
        else if (Input.GetKey(KeyCode.W))
        {
            posicao = 3; //costas
        }
        else if (Input.GetKey(KeyCode.S))
        {
            posicao = 4; //frente
        }
    }
}
