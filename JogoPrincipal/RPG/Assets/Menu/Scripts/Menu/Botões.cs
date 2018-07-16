using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botões : MonoBehaviour {

    public GameObject start;
    public GameObject exit;
    public AudioClip selectAudio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStart()
    {
        
        AudioG.inst.PlayAudio(selectAudio);
        PlayerPrefs.SetInt("Reputação", 0);
        PlayerPrefs.SetInt("currentLevel", 0);
        PlayerPrefs.SetInt("NewOrLoad", 0);
        this.GetComponent<LoadCene>().Load = "CreateChar";
        this.GetComponent<LoadCene>().OnStart();
    }

    public void OnLoad()
    {
        AudioG.inst.PlayAudio(selectAudio);
        PlayerPrefs.SetInt("NewOrLoad", 1);
        this.GetComponent<LoadCene>().Load = "Loader";
        this.GetComponent<LoadCene>().OnStart();
    }

    public void OnOptions()
    {
        AudioG.inst.PlayAudio(selectAudio);
    }

    public void BackMenu()
    {
        AudioG.inst.PlayAudio(selectAudio);
    }

    public void OnExit()
    {
        AudioG.inst.PlayAudio(selectAudio);
        Application.Quit();
    }
}
