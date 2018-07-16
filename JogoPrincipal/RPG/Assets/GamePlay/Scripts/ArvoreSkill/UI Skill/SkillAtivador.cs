using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillAtivador : MonoBehaviour {

    public SkillBehaviour istancer;
    public PlayerBehaviour player;
    public Button skill;
    public Image cadeado;

	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        skill.image.overrideSprite = istancer.botão.image.sprite; // coloca como imagem o icone de arvore skill 
    }

    public void tipoDeSkill()
    {
        if (this.tag == "Skill1")
        {
            if(istancer.hitDuplo == true)
            {
                skill.image.overrideSprite 
            }
        }
    }
}
