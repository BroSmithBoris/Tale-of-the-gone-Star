using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;
using System;

public class ControlSettings : MonoBehaviour
{
    public Text[] text = new Text[3];
    bool visible;
    int index;

    public void ButtonClick(int i)
    {
        visible = true;
        index = i;
    }


    void OnGUI()
    {
        if (visible)
        {
            GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 300, 200), "Press any key");

            if (Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
            {
                switch (index)
                {
                    case 0:
                        Move.left = Event.current.keyCode;
                        text[0].text = Move.left.ToString();
                        break;
                    case 1:
                        Move.right = Event.current.keyCode;
                        text[1].text = Move.right.ToString();
                        break;
                    case 2:
                        Move.jump = Event.current.keyCode;
                        text[2].text = Move.jump.ToString();
                        break;

                }
                visible = false;
            }

            if (Event.current.keyCode == KeyCode.Escape) visible = false;
        }
    }
}
