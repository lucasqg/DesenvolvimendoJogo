using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioG : MonoBehaviour {

    public AudioSource Sons;
    public static AudioG inst = null;

    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }else if (inst != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudio(AudioClip clipAudio)
    {
        Sons.clip = clipAudio;
        Sons.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
