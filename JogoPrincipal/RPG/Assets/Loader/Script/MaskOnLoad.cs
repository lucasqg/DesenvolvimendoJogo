using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskOnLoad : MonoBehaviour
{

    public Texture texturaFundo;

    private void Start()
    {
    }

    private void OnGUI()
    {

        //Textura do Fundo
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texturaFundo);

    }
}

