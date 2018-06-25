using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversasBehaviour : MonoBehaviour {

    public Canvas falas;
    public bool isActived;
    public bool falando = false;
    public SkillBehaviour skill;
    // Use this for initialization

    void Start()
    {
        falas.gameObject.SetActive(false);
        isActived = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(falando == true)
        {
            falas.gameObject.SetActive(true); // liga e desliga a arvore skill
        }
        else
        {
            falas.gameObject.SetActive(false); // liga e desliga a arvore skill
        }
    }
}
