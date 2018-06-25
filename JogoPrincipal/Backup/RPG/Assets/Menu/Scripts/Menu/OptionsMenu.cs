using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    private float mute = 0;
    private bool ver = false;

    public void setVolume(float volume)
    {
        if(volume <= -40)
        {
            ver = true;
            mute = -40;
        }else if(volume > -80 && ver == true){
            mute = 0.01f;
            ver = false;
        }

        audioMixer.SetFloat("volume",(volume + mute));
    }

    public void setQualidade(int qualidade)
    {
        QualitySettings.SetQualityLevel(qualidade);
    }
}
