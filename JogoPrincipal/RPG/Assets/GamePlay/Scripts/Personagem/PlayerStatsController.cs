using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BasicInfoChars
{
    public BasicStats baseInfo;
    public TypeCharacter typeChar;
}

public class PlayerStatsController : MonoBehaviour{
    public static PlayerStatsController instance;
    public int level;
    public int xpMultiply = 1;
    public int pontosSkill;
    public int pontosAtributos;
    public float xpFirstLevel = 100;
    public float difficultFactor = 1.5f;
    public PlayerBehaviour player;
    public List<BasicInfoChars> baseInfoChars;



    // Use this for initialization
    void Start()
    {

        //RESET PLAYER PREFS;
        /*
        PlayerPrefs.SetFloat("currentXp", 0);
        PlayerPrefs.SetInt("currentLevel", 0);
        PlayerPrefs.SetInt("pontosSkill", 0);
        PlayerPrefs.SetInt("Reputação", 0);
        */
        instance = this;
        DontDestroyOnLoad(gameObject);
        Application.LoadLevel("GamePlay"); //Chama a cena apoós o menu
        
        
    }

    void Update()
    {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
        /*
        if (Input.GetKey(KeyCode.X))
        {
            AddXp(100);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            AddReputation(100);
        }*/
    }

    public static void AddXp(float xpAdd)
    {
        float newXp = (GetCurrentXp() + xpAdd) * PlayerStatsController.instance.xpMultiply;
        int pSkill = (GetCurrentPontosSkill() + 1);
        while (newXp >= GetNextXp())
        {
            newXp -= GetNextXp();
            pSkill += GetCurrentPontosSkill();
            addLevel();
           
        }
        PlayerPrefs.SetFloat("currentXp", newXp);
    }
    public static float GetCurrentXp()
    {
        return PlayerPrefs.GetFloat("currentXp");
    }
    public static int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("currentLevel");
    }

    public static int GetCurrentPontosSkill()
    {
        return PlayerPrefs.GetInt("pontosSkill");
    }

    public static void addLevel()
    {
        int newLevel = GetCurrentLevel() + 1;
        instance.player.currentSkills += 1;
        instance.player.currentPontos += 5;
        PlayerPrefs.SetInt("currentLevel", newLevel);
    }
    public static float GetNextXp()
    {
        return PlayerStatsController.instance.xpFirstLevel * (GetCurrentLevel() + 1) * PlayerStatsController.instance.difficultFactor;
    }
    public static TypeCharacter GetTypeCharacter()
    {
        int typeId = PlayerPrefs.GetInt("TypeCharacter");
        if (typeId == 0)
        {
            return TypeCharacter.Guerreiro;
        }
        else if (typeId == 1)
        {
            return TypeCharacter.Bomber;
        }
        else if (typeId == 2)
        {
            return TypeCharacter.Pistoleiro;
        }

        return TypeCharacter.Guerreiro;
    }

    public static void SetTypeCharacter(TypeCharacter newType)
    {
        PlayerPrefs.SetInt("TypeCharacter", (int)newType);
    }

   public BasicStats GetBasicStatsPlayer(TypeCharacter type)
    {
        foreach(BasicInfoChars info in baseInfoChars)
        {
            if(info.typeChar == type)
            {
                return info.baseInfo;
            }
        }
        return baseInfoChars[0].baseInfo;
    } 
    
    public static void AddReputation(int reputation) // Adiciona a o novo valor de reputação a playerPrefs
    {
        int newReputarion = PlayerPrefs.GetInt("Reputação") + reputation;

        PlayerPrefs.SetInt("Reputação", newReputarion);

        if(PlayerPrefs.GetInt("Reputação") == -20)
        {
            //GAME OVER
        }
       
    }

    //metodo que retorna a quantidade de reputação do personagem
    public static int GetCurrentReputation()  
    {
        return PlayerPrefs.GetInt("Reputação");
    }
    
    private void OnGUI()
    {
        //GUI.Label(new Rect(0, 0, 100, 50), "Current Xp" + GetCurrentXp());
        GUI.Label(new Rect(0, 0, 150, 50), "Level: " + GetCurrentLevel());
        //GUI.Label(new Rect(0, 100, 100, 50), "Current Next Level" + GetNextXp());
        GUI.Label(new Rect(0, 30, 150, 50), "Reputação: " + GetCurrentReputation());
        GUI.Label(new Rect(0, 60, 150, 50), "Nome: " + PlayerPrefs.GetString("CharNome"));
    }
    
    
}
