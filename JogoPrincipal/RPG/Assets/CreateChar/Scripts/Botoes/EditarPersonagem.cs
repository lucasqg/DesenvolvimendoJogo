using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditarPersonagem : MonoBehaviour {

    public Sprite[] Heads;
    public Sprite[] Bodys;
    public Sprite[] Legs;
    [Space(10)]
    public Image Head;
    public Image Body;
    public Image Leg;
    [Space(10)]
    public GameObject GObjectHead;
    public GameObject GObjectBody;
    public GameObject GObjectLeg;

    public int indexH = 0, indexB = 0, indexL = 0;


    //Botões para Head
    public void nextSpriteHead()
    {

        if (indexH < Heads.Length-1)
        {
            indexH++;
            Head.sprite = Heads[indexH];
            GObjectHead.GetComponent<SpriteRenderer>().sprite = Heads[indexH];
        }
        else
        {
            indexH = 0;
            Head.sprite = Heads[indexH];
            GObjectHead.GetComponent<SpriteRenderer>().sprite = Heads[indexH];
        }
    }

    public void previousSpriteHead()
    {
        if (indexH > 0)
        {
            indexH--;
            Head.sprite = Heads[indexH];
            GObjectHead.GetComponent<SpriteRenderer>().sprite = Heads[indexH];
        }
        else
        {
            indexH = Heads.Length-1;
            Head.sprite = Heads[indexH];
            GObjectHead.GetComponent<SpriteRenderer>().sprite = Heads[indexH];
        }
    }


    //Botoes para Body
    public void nextSpriteBody()
    {

        if (indexB < Heads.Length-1)
        {
            indexB++;
            Body.sprite = Bodys[indexB];
            GObjectBody.GetComponent<SpriteRenderer>().sprite = Bodys[indexB];
        }
        else
        {
            indexB = 0;
            Body.sprite = Bodys[indexB];
            GObjectBody.GetComponent<SpriteRenderer>().sprite = Bodys[indexB];
        }
    }

    public void previousSpriteBody()
    {
        if (indexB > 0)
        {
            indexB--;
            Body.sprite = Bodys[indexB];
            GObjectBody.GetComponent<SpriteRenderer>().sprite = Bodys[indexB];
        }
        else
        {
            indexB = Heads.Length-1;
            Body.sprite = Bodys[indexB];
            GObjectBody.GetComponent<SpriteRenderer>().sprite = Bodys[indexB];
        }
    }


    //Botoes para Legs
    public void nextSpriteLeg()
    {

        if (indexL < Heads.Length-1)
        {
            indexL++;
            Leg.sprite = Legs[indexL];
            GObjectLeg.GetComponent<SpriteRenderer>().sprite = Legs[indexL];
        }
        else
        {
            indexL = 0;
            Leg.sprite = Legs[indexL];
        }
    }

    public void previousSpriteLeg()
    {
        if (indexL > 0)
        {
            indexL--;
            Leg.sprite = Legs[indexL];
            GObjectLeg.GetComponent<SpriteRenderer>().sprite = Legs[indexL];
        }
        else
        {
            indexL = Heads.Length-1;
            Leg.sprite = Heads[indexL];
            GObjectLeg.GetComponent<SpriteRenderer>().sprite = Legs[indexL];
        }
    }
}
