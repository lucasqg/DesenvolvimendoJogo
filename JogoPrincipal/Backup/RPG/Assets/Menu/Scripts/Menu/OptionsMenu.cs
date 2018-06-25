using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;


    private float mute = 0;
    private bool ver = false;

    public Dropdown resolucao;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolucao.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);


            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolucao.AddOptions(options);
        resolucao.value = currentResolutionIndex;
        resolucao.RefreshShownValue();
    }

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

    public void setTelaCheia(bool fullS)
    {
        Screen.fullScreen = fullS;
    }
}
