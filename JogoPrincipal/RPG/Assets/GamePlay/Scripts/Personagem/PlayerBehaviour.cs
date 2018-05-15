using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        PlayerStatsController.SetTypeCharacter(TypeCharacter.Pistoleiro);
        type = PlayerStatsController.GetTypeCharacter();
        basicStats = PlayerStatsController.instance.GetBasicStatsPlayer(type);
        base.Start();

    }

    public TypeCharacter GetTypeChar()
    {
        return type;
    }
	
    

    void Update () {
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            currentLife -= Random.Range(1, 10);
        }
        UI.SetLife(basicStats.startLife, currentLife);
    }
}
