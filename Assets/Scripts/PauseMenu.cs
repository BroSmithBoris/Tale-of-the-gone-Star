using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    float timer;
    [HideInInspector] public bool isPause;
    int menuType = 0;
    float h = Screen.height;
    float w = Screen.width;
    float buttonWidth = 150f;
    float buttonHeight = 45f;
    public string[] textOfSave = new string[4];

    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
                isPause = false;
            else
                isPause = true;

            menuType = 0;
        }
        if (isPause)
            timer = 0;
        else
            timer = 1f;
    }

    void OnGUI()
    {
        if (isPause)
        {
            Cursor.visible = true;

            switch (menuType)
            {
                case 0: drawMainMenu(); break;
                case 1: drawSaveMenu(); break;
                case 2: drawLoadMenu(); break;
            }
        }
        else Cursor.visible = false;
    }

    void drawMainMenu()
    {
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 150f, buttonWidth, buttonHeight), "Resume"))
        {
            isPause = false;
            Cursor.visible = false;
        }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 100f, buttonWidth, buttonHeight), "Save"))
        {
            menuType = 1;
        }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 50f, buttonWidth, buttonHeight), "Load"))
        {
            menuType = 2;
        }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2), buttonWidth, buttonHeight), "Back to Menu"))
        {
            SceneManager.LoadScene("Menu");
        }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) + 50f, buttonWidth, buttonHeight), "Exit"))
        {
            isPause = false;
            Application.Quit();
        }
    }

    void drawSaveMenu()
    {
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 150f, buttonWidth, buttonHeight), textOfSave[0]))
        { }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 100f, buttonWidth, buttonHeight), textOfSave[1]))
        { }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 50f, buttonWidth, buttonHeight), textOfSave[2]))
        { }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2), buttonWidth, buttonHeight), textOfSave[3]))
        { }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) + 50f, buttonWidth, buttonHeight), "Back"))
        {
            menuType = 0;
        }
    }

    void drawLoadMenu()
    {
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 150f, buttonWidth, buttonHeight), textOfSave[0]))
        { }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 100f, buttonWidth, buttonHeight), textOfSave[1]))
        { }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 50f, buttonWidth, buttonHeight), textOfSave[2]))
        { }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2), buttonWidth, buttonHeight), textOfSave[3]))
        { }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) + 50f, buttonWidth, buttonHeight), "Back"))
        {
            menuType = 0;
        }
    }
}
