using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDie : MonoBehaviour {

    public GameObject player;
    public AudioClip click;

	public void onIrCidade()
    {
        AudioG.inst.PlayAudio(click);
        player.gameObject.GetComponent<PlayerBehaviour>().currentLife = player.gameObject.GetComponent<PlayerBehaviour>().totalLife;
        player.gameObject.transform.position = new Vector3(-193.5f, -216f, -1.12f);
        this.gameObject.SetActive(false);
    }
    
    public void Menu()
    {
        AudioG.inst.PlayAudio(click);
    }

    public void onQuit()
    {
        AudioG.inst.PlayAudio(click);
        Application.Quit();
    }
}
