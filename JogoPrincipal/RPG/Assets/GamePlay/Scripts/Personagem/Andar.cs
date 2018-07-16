using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour {
    private float vel = 2f;
    public Animator anim;
    public Transform player;
    private bool andando=true;


    //Parte Visual
    [Space(10)]
    public GameObject Visual;

    [Space(10)]
    public GameObject Head;
    public GameObject Body;
    public GameObject Legs;

    string HeadNome;
    string BodyNome;
    string LegNome;

    public int IndexHeadP, IndexBodyP, IndexLegsP;

    // Use this for initialization
    void Start () {
        player = GetComponent<Transform>();
       
        anim.SetBool("Parado", true);
        anim.SetBool("DireitaAndando", false);
        anim.SetBool("EsquerdaAndando", false);
        anim.SetBool("FrenteAndando", false);
        anim.SetBool("CostasAndando", false);

        string[] loadingData = DataBasePerfil.LoadDataChar();
        IndexHeadP = int.Parse(loadingData[2]);
        IndexBodyP = int.Parse(loadingData[3]);
        IndexLegsP = int.Parse(loadingData[4]);

        HeadNome = Visual.GetComponent<DataBaseVisual>().Heads[IndexHeadP].name;
        BodyNome = Visual.GetComponent<DataBaseVisual>().Bodys[IndexBodyP].name;
        LegNome = Visual.GetComponent<DataBaseVisual>().Legs[IndexLegsP].name;
 
    }
	// Update is called once per frame
	void Update () {
        //if (morto == false)
        // {

        if (andando == true)
        {
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && andando == true)
            {
                anim.SetBool("Parado", false);
                anim.SetBool("DireitaAndando", true);
                anim.SetBool("EsquerdaAndando", false);
                anim.SetBool("FrenteAndando", false);
                anim.SetBool("CostasAndando", false);
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));

                attVisualDireita();


            }
            else if ((Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow)) && andando == true)
            {
                anim.SetBool("Parado", false);
                anim.SetBool("EsquerdaAndando", true);
                anim.SetBool("FrenteAndando", false);
                anim.SetBool("CostasAndando", false);
                anim.SetBool("DireitaAndando", false);
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));

                attVisualEsquerda();
            }
            else if ((Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow)) && andando == true)
            {
                anim.SetBool("Parado", false);
                anim.SetBool("CostasAndando", true);
                anim.SetBool("DireitaAndando", false);
                anim.SetBool("EsquerdaAndando", false);
                anim.SetBool("FrenteAndando", false);
                transform.Translate(new Vector2(0, vel * Time.deltaTime));

                attVisualCima();
            }
            else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && andando == true)
            {
                anim.SetBool("Parado", false);
                anim.SetBool("FrenteAndando", true);
                anim.SetBool("DireitaAndando", false);
                anim.SetBool("EsquerdaAndando", false);
                anim.SetBool("CostasAndando", false);
                transform.Translate(new Vector2(0, -vel * Time.deltaTime));

                attVisualBaixo();
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow)
                || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
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


    void attVisualDireita()
    {
        //attHead
        {
            if (HeadNome == "HeadDownHEAD1" || HeadNome == "HeadUpHEAD1" || HeadNome == "HeadRightHEAD1" || HeadNome == "HeadLeftHEAD1")
            {
                Head.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Heads1[1];
            }

            if (HeadNome == "HeadDownHEAD2" || HeadNome == "HeadUpHEAD2" || HeadNome == "HeadRightHEAD2" || HeadNome == "HeadLeftHEAD2")
            {
                Head.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Heads2[1];
            }

            if (HeadNome == "HeadDownHEAD3" || HeadNome == "HeadUpHEAD3" || HeadNome == "HeadRightHEAD3" || HeadNome == "HeadLeftHEAD3")
            {
                Head.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Heads3[1];
            }
        }

        //attBody
        {
            if (BodyNome == "BodyDownBODY1" || BodyNome == "BodyUpBODY1" || BodyNome == "BodyRightBODY1" || BodyNome == "BodyLeftBODY1")
            {
                Body.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Body1[1];
            }

            if (BodyNome == "BodyDownBODY2" || BodyNome == "BodyUpBODY2" || BodyNome == "BodyRightBODY2" || BodyNome == "BodyLeftBODY2")
            {
                Body.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Body2[1];
            }

            if (BodyNome == "BodyDownBODY3" || BodyNome == "BodyUpBODY3" || BodyNome == "BodyRightBODY3" || BodyNome == "BodyLeftBODY3")
            {
                Body.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Body3[1];
            }
        }

        //attLeg
        {
            if (LegNome == "LegsDownLEGS1" || LegNome == "LegsUpLEGS1" || LegNome == "LegsRightLEGS1" || LegNome == "LegsLeftLEGS1")
            {
                Legs.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Leg1[1];
            }

            if (LegNome == "LegsDownLEGS2" || LegNome == "LegsUpLEGS2" || LegNome == "LegsRightLEGS2" || LegNome == "LegsLeftLEGS2")
            {
                Legs.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Leg2[1];
            }

            if (LegNome == "LegsDownLEGS3" || LegNome == "LegsUpLEGS3" || LegNome == "LegsRightLEGS3" || LegNome == "LegsLeftLEGS3")
            {
                Legs.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Leg3[1];
            }
        }


    }

    void attVisualEsquerda()
    {
        //attHead
        {
            if (HeadNome == "HeadDownHEAD1" || HeadNome == "HeadUpHEAD1" || HeadNome == "HeadRightHEAD1" || HeadNome == "HeadLeftHEAD1")
            {
                Head.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Heads1[2];
            }

            if (HeadNome == "HeadDownHEAD2" || HeadNome == "HeadUpHEAD2" || HeadNome == "HeadRightHEAD2" || HeadNome == "HeadLeftHEAD2")
            {
                Head.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Heads2[2];
            }

            if (HeadNome == "HeadDownHEAD3" || HeadNome == "HeadUpHEAD3" || HeadNome == "HeadRightHEAD3" || HeadNome == "HeadLeftHEAD3")
            {
                Head.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Heads3[2];
            }
        }

        //attBody
        {
            if (BodyNome == "BodyDownBODY1" || BodyNome == "BodyUpBODY1" || BodyNome == "BodyRightBODY1" || BodyNome == "BodyLeftBODY1")
            {
                Body.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Body1[2];
            }

            if (BodyNome == "BodyDownBODY2" || BodyNome == "BodyUpBODY2" || BodyNome == "BodyRightBODY2" || BodyNome == "BodyLeftBODY2")
            {
                Body.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Body2[2];
            }

            if (BodyNome == "BodyDownBODY3" || BodyNome == "BodyUpBODY3" || BodyNome == "BodyRightBODY3" || BodyNome == "BodyLeftBODY3")
            {
                Body.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Body3[2];
            }
        }

        //attLeg
        {
            if (LegNome == "LegsDownLEGS1" || LegNome == "LegsUpLEGS1" || LegNome == "LegsRightLEGS1" || LegNome == "LegsLeftLEGS1")
            {
                Legs.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Leg1[2];
            }

            if (LegNome == "LegsDownLEGS2" || LegNome == "LegsUpLEGS2" || LegNome == "LegsRightLEGS2" || LegNome == "LegsLeftLEGS2")
            {
                Legs.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Leg2[2];
            }

            if (LegNome == "LegsDownLEGS3" || LegNome == "LegsUpLEGS3" || LegNome == "LegsRightLEGS3" || LegNome == "LegsLeftLEGS3")
            {
                Legs.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Leg3[2];
            }
        }

    }

    void attVisualCima()
    {
        //attHead
        {
            if (HeadNome == "HeadDownHEAD1" || HeadNome == "HeadUpHEAD1" || HeadNome == "HeadRightHEAD1" || HeadNome == "HeadLeftHEAD1")
            {
                Head.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Heads1[0];
            }

            if (HeadNome == "HeadDownHEAD2" || HeadNome == "HeadUpHEAD2" || HeadNome == "HeadRightHEAD2" || HeadNome == "HeadLeftHEAD2")
            {
                Head.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Heads2[0];
            }

            if (HeadNome == "HeadDownHEAD3" || HeadNome == "HeadUpHEAD3" || HeadNome == "HeadRightHEAD3" || HeadNome == "HeadLeftHEAD3")
            {
                Head.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Heads3[0];
            }
        }

        //attBody
        {
            if (BodyNome == "BodyDownBODY1" || BodyNome == "BodyUpBODY1" || BodyNome == "BodyRightBODY1" || BodyNome == "BodyLeftBODY1")
            {
                Body.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Body1[0];
            }

            if (BodyNome == "BodyDownBODY2" || BodyNome == "BodyUpBODY2" || BodyNome == "BodyRightBODY2" || BodyNome == "BodyLeftBODY2")
            {
                Body.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Body2[0];
            }

            if (BodyNome == "BodyDownBODY3" || BodyNome == "BodyUpBODY3" || BodyNome == "BodyRightBODY3" || BodyNome == "BodyLeftBODY3")
            {
                Body.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Body3[0];
            }
        }

        //attLeg
        {
            if (LegNome == "LegsDownLEGS1" || LegNome == "LegsUpLEGS1" || LegNome == "LegsRightLEGS1" || LegNome == "LegsLeftLEGS1")
            {
                Legs.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Leg1[0];
            }

            if (LegNome == "LegsDownLEGS2" || LegNome == "LegsUpLEGS2" || LegNome == "LegsRightLEGS2" || LegNome == "LegsLeftLEGS2")
            {
                Legs.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Leg2[0];
            }

            if (LegNome == "LegsDownLEGS3" || LegNome == "LegsUpLEGS3" || LegNome == "LegsRightLEGS3" || LegNome == "LegsLeftLEGS3")
            {
                Legs.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Leg3[0];
            }
        }


    }

    void attVisualBaixo()
    {

        Head.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Heads[IndexHeadP];
        Body.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Bodys[IndexBodyP];
        Legs.GetComponent<SpriteRenderer>().sprite = Visual.GetComponent<DataBaseVisual>().Legs[IndexLegsP];

    }
}
