using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TypeCharacter
{
    Guerreiro=0, 
    Bomber=1,
    Pistoleiro=2
}
public class PlayerBehaviour : CharacterBase {
    private TypeCharacter type;
    //UI
    public UIController UI;
    protected void Start () {
        currentLevel = PlayerStatsController.GetCurrentLevel();
        PlayerStatsController.SetTypeCharacter(TypeCharacter.Guerreiro);
        type = PlayerStatsController.GetTypeCharacter();
        basicStats = PlayerStatsController.instance.GetBasicStatsPlayer(type);
        base.Start();
        TipoDeSlider();
    }

    public void TipoDeSlider()
    {
        if (GetTypeChar() == TypeCharacter.Guerreiro)
        {
            UI.objectSliderMana.SetActive(false);
        }
        else if (GetTypeChar() == TypeCharacter.Bomber)
        {
            UI.objectSliderStamina.SetActive(false);
        }
        else if (GetTypeChar() == TypeCharacter.Pistoleiro)
        {
            UI.objectSliderStamina.SetActive(false);
        }
    }

    public TypeCharacter GetTypeChar()
    {
        return type;
    }
	
    public void levelUP()
    {

    }

    void Update () {
        Destroyer();
        /*if (Input.GetKeyDown(KeyCode.K))
        {
            currentLife -= Random.Range(1, 10);
        }*/
        UI.SetExperiencia(PlayerStatsController.GetNextXp(), PlayerStatsController.GetCurrentXp());
        UI.SetLife(totalLife, currentLife);
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "CidadaoMutante")
        {
            NpcBase monster = collision.GetComponent<NpcBase>();
            UI.SetLifeMonster(monster.totalLife, monster.currentLife);
            UI.objectSliderMonster.SetActive(true);
        }
        else if (collision.tag == "Morcego")
        {
            NpcBase monster = collision.GetComponent<NpcBase>();
            UI.SetLifeMonster(monster.totalLife, monster.currentLife);
            UI.objectSliderMonster.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CidadaoMutante")
        {
            UI.objectSliderMonster.SetActive(false);
        }
        else if(collision.tag == "Morcego")
        {
            UI.objectSliderMonster.SetActive(false);
        }
    }
}
