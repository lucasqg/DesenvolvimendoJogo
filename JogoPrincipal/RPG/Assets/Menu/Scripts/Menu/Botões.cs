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
    }

    public void OnLoad()
    {
        AudioG.inst.PlayAudio(selectAudio);
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
