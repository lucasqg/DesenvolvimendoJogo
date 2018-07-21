using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillAtivador : MonoBehaviour {

    public SkillBehaviour arvore;
    public PlayerBehaviour player;
    public Button skill;
    public int code;

	// Use this for initialization

	void Start () {
        skill.image.overrideSprite = arvore.iconCadeado; // coloca o icone do cadeado
        //arvore= FindObjectOfType(typeof(SkillBehaviour)) as SkillBehaviour;
        skill = this.GetComponent<Button>();
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        ativaImagem();
    }
	
	// Update is called once per frame
	void Update () {
        //skill.image.overrideSprite = istancer.botão.image.sprite; // coloca como imagem o icone de arvore skill 
    }

    public void ativaImagem()
    {
        skill.image.overrideSprite = arvore.iconCadeado;
    }
    public void ativaImagemSemCadeado( Sprite image)
    {
        skill.image.overrideSprite = image;
    }
    public void tipoDeSkill()
    {
        if (this.tag == "Skill1")
        {
            if(arvore.hitDuplo == true)
            {
                //skill.image.overrideSprite;
            }
        }
    }

    public void onClick()
    {
        arvore.SelectedSkill(this);
        
    }
}
