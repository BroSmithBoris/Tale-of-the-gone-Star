using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;
using System;

public class ControlSettings : MonoBehaviour
{
    Text text;
    bool visible;
    int index;
    string[] textControls = { "Move left - ", "Move right - ", "Jump - " };
    KeyCode[] controls = { Move.left, Move.right, Move.jump };


    public void ButtonClick()
    {
        visible = true;
    }


    void OnGUI()
    {
        if (visible)
        {
            GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 300, 200), "Press any key");

            if (Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
            {
                controls[index] = Event.current.keyCode;
                visible = false;
                text.text = textControls[index] + controls[index].ToString();
            }

            if (Event.current.keyCode == KeyCode.Escape) visible = false;
        }
    }
}
