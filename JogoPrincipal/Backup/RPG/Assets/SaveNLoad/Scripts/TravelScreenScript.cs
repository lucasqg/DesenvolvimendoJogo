using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelScreenScript : MonoBehaviour {

    public int cenaLoad;

    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 80, 100, 30), "Current Scene " + (Application.loadedLevel + 1));
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 50, 100, 40), "Load Scene " + (cenaLoad+1)))
        {
            Application.LoadLevel(cenaLoad);
        }
    }
}
