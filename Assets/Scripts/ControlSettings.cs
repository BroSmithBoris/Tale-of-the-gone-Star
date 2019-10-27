using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ControlSettings : MonoBehaviour
{
    public Text text;
    bool visible;
    bool visible1;
    public KeyCode left;
    public KeyCode right;

    public void ButtonClick()
    {
        visible = true;
    }

    public void ButtonClick1()
    {
        visible1 = true;
    }

    void OnGUI()
    {
        if (visible)
        {
            GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 300, 200), "Press any key");

            if (left != KeyCode.None)
            {
                left = KeyCode.None;
                text.text = "Move left - " + left.ToString();
            }
            else
            {
                if (Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
                {
                    left = Event.current.keyCode;
                    visible = false;
                    text.text = "Move left - " + left.ToString();
                }
            }

            if (Event.current.keyCode == KeyCode.Escape)
                visible = false;
        }

    }
}
