using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArvoreSkillController : MonoBehaviour {

    public Sprite imagemSlot;
    public Text descrition;
    public Image arvoreSkill;
    public bool isActived;
    // Use this for initialization

    void Start()
    {
        arvoreSkill.gameObject.SetActive(false);
        isActived = false;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K) && isActived == false)
        {
            isActived = true;
            arvoreSkill.gameObject.SetActive(true); // liga e desliga a arvore skill
        }
        else if(Input.GetKeyDown(KeyCode.K) && isActived == true)
        {
            isActived = false;
            arvoreSkill.gameObject.SetActive(false); // liga e desliga a arvore skill
        }
    }

    public void OnClick()
    {

    }
}