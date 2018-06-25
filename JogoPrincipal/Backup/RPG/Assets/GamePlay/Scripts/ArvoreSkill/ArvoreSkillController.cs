using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArvoreSkillController : MonoBehaviour {

    public Sprite imagemSlot;
    public Text descrition;
    public Image arvoreSkill;
    public bool isActived;
    public SkillBehaviour skill;
    // Use this for initialization

    void Start()
    {
        arvoreSkill.gameObject.SetActive(false);
        isActived = false;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O) && isActived == false)
        {
            isActived = true;
            arvoreSkill.gameObject.SetActive(true); // liga e desliga a arvore skill
        }
        else if(Input.GetKeyDown(KeyCode.O) && isActived == true)
        {
            isActived = false;
            arvoreSkill.gameObject.SetActive(false); // liga e desliga a arvore skill
        }
    }

    public void AtivadorSkill()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // ataque básico
        {

        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && skill.hitDuplo == true)
        {
            skill.AtivarDuploHit();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && skill.explosion == true)
        {

        }
        if(Input.GetKeyDown(KeyCode.Alpha4) && skill.hitTriplo == true)
        {

        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && skill.lançarEspada == true)
        {

        }
        if(Input.GetKeyDown(KeyCode.Alpha6) && skill.giroDoInfinito == true)
        {

        }
    }

    public void OnClick()
    {

    }
}