using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustScript : MonoBehaviour {

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10,100,100,30), "health up"))
        {
            GameControl.control.health += 10;
        }

        if (GUI.Button(new Rect(10, 140, 100, 30), "health down"))
        {
            GameControl.control.health -= 10;
        }

        if (GUI.Button(new Rect(10, 180, 100, 30), "Exp up"))
        {
            GameControl.control.experience += 10;
        }

        if (GUI.Button(new Rect(10, 220, 100, 30), "Exp down"))
        {
            GameControl.control.experience -= 10;
        }

        if (GUI.Button(new Rect(10, 260, 100, 30), "Save"))
        {
            GameControl.control.Save();
        }

        if (GUI.Button(new Rect(10, 300, 100, 30), "Load"))
        {
            GameControl.control.Load();
        }
    }
}
