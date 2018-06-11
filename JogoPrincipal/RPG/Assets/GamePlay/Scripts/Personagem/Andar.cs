using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour {
    private float vel = 2f;
    public Animator anim;
    public Transform player;
    private bool andando=true;


	// Use this for initialization
	void Start () {
        player = GetComponent<Transform>();
       
        anim.SetBool("Parado", true);
        anim.SetBool("DireitaAndando", false);
        anim.SetBool("EsquerdaAndando", false);
        anim.SetBool("FrenteAndando", false);
        anim.SetBool("CostasAndando", false);
    }

    
	
	// Update is called once per frame
	void Update () {
        //if (morto == false)
        // {

        if (andando == true)
        {
            if (Input.GetKey(KeyCode.D) && andando == true)
            {
                anim.SetBool("Parado", false);
                anim.SetBool("DireitaAndando", true);
                anim.SetBool("EsquerdaAndando", false);
                anim.SetBool("FrenteAndando", false);
                anim.SetBool("CostasAndando", false);
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
            }
            else if (Input.GetKey(KeyCode.A) && andando == true)
            {
                anim.SetBool("Parado", false);
                anim.SetBool("EsquerdaAndando", true);
                anim.SetBool("FrenteAndando", false);
                anim.SetBool("CostasAndando", false);
                anim.SetBool("DireitaAndando", false);
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
            }
            else if (Input.GetKey(KeyCode.W) && andando == true)
            {
                anim.SetBool("Parado", false);
                anim.SetBool("CostasAndando", true);
                anim.SetBool("DireitaAndando", false);
                anim.SetBool("EsquerdaAndando", false);
                anim.SetBool("FrenteAndando", false);
                transform.Translate(new Vector2(0, vel * Time.deltaTime));
            }
            else if (Input.GetKey(KeyCode.S) && andando == true)
            {
                anim.SetBool("Parado", false);
                anim.SetBool("FrenteAndando", true);
                anim.SetBool("DireitaAndando", false);
                anim.SetBool("EsquerdaAndando", false);
                anim.SetBool("CostasAndando", false);
                transform.Translate(new Vector2(0, -vel * Time.deltaTime));
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
                andando = false;
        }

        else
        {
            andando = true;
            anim.SetBool("Parado", true);
            anim.SetBool("DireitaAndando", false);
            anim.SetBool("EsquerdaAndando", false);
            anim.SetBool("FrenteAndando", false);
            anim.SetBool("CostasAndando", false);
        }
        // }
    }
}
