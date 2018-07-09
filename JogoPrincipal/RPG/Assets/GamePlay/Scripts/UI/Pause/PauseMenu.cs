using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool JogoPause = false;
    public GameObject pauseMenu;
    public GameObject popUpDie;

    public PlayerBehaviour player;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JogoPause)
            {
                resume();
            }else
                pause();
            
        }
	}

    
    public void resume()
    {
        pauseMenu.SetActive(false);
        JogoPause = false;
        Time.timeScale = 1f;
    }

    void pause()
    {
        pauseMenu.SetActive(true);
        JogoPause = true;
        Time.timeScale = 0f;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void teleporte()
    {
        player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;

        player.gameObject.transform.position = new Vector3(-0.78f, -30f, -0.28f);

        player.addLife(30);

        popUpDie.gameObject.SetActive(false);
    }
}
