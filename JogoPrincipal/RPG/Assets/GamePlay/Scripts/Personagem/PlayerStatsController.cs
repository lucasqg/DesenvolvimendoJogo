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
    public float xpFirstLevel = 100;
    public float difficultFactor = 1.5f;

    public List<BasicInfoChars> baseInfoChars;



    // Use this for initialization
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        Application.LoadLevel("GamePlay"); //Chama a cena apoós o menu

    }

    void Update()
    {

    }

    public static void AddXp(float xpAdd)
    {
        float newXp = (GetCurrentXp() + xpAdd) * PlayerStatsController.instance.xpMultiply;
        while(newXp >= GetNextXp())
        {
            newXp -= GetNextXp();
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

    public static void addLevel()
    {
        int newLevel = GetCurrentLevel() + 1;
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

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), "Current Xp" + GetCurrentXp());
        GUI.Label(new Rect(0, 50, 100, 50), "Current Level" + GetCurrentLevel());
        GUI.Label(new Rect(0, 100, 100, 50), "Current Next Level" + GetNextXp());
    }
}
