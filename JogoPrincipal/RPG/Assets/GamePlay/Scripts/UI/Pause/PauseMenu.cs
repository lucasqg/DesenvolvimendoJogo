using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool JogoPause = false;
    public GameObject pauseMenu;
    public GameObject inventario;
    public GameObject arvoreSkill;
    public GameObject falas;

    public PlayerBehaviour player;

    public bool arvore, inv, fala; 

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        inv = inventario.gameObject.activeSelf;
        arvore = arvoreSkill.gameObject.activeSelf;
        fala = falas.gameObject.activeSelf;

        if ( Input.GetKeyDown(KeyCode.Escape) && !inventario.gameObject.activeSelf && !arvoreSkill.gameObject.activeSelf && !falas.gameObject.activeSelf)
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

        //popUpDie.gameObject.SetActive(false);
    }
}
