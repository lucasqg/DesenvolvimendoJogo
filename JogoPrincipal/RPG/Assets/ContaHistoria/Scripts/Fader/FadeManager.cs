using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    public static FadeManager Instance { set; get; }

    public Image FadeImage;
    private bool isInTransition;
    private float transition;
    private bool isShow;
    private float duration;

    private void Awake()
    {
        Instance = this;
    }

    public void Fade(bool show, float duration)
    {
        isShow = show;
        isInTransition = true;
        this.duration = duration;
        transition = (isShow) ? 0 : 1;
    }

    private void Update()
    {
        if (!isInTransition)
        {
            return;
        }

        transition += (isShow) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        FadeImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);

        if(transition > 1 || transition < 0)
        {
            isInTransition = false;
        }
    }
}
