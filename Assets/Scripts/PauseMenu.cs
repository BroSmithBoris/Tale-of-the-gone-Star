using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class PauseMenu : MonoBehaviour
{
    float timer;
    [HideInInspector] public bool isPause;
    int menuType = 0;
    float h = Screen.height;
    float w = Screen.width;
    float buttonWidth = 150f;
    float buttonHeight = 45f;
    public GameObject player;

    [HideInInspector] public float x;
    [HideInInspector] public float y;
    [HideInInspector] public float z;

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
                case 1: break;
                case 2: break;
            }
        }
        else Cursor.visible = false;
    }

    void drawMainMenu()
    {
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 150f, buttonWidth, buttonHeight), "Resume"))
        {
            Cursor.visible = false;
            isPause = false;
        }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 100f, buttonWidth, buttonHeight), "Save"))
        {
            StreamWriter sw = new StreamWriter("Position.txt");
            sw.WriteLine(player.transform.position.x);
            sw.WriteLine(player.transform.position.y);
            sw.WriteLine(player.transform.position.z);
            sw.Close();
        }
        if (GUI.Button(new Rect((w / 2) - 75f, (h / 2) - 50f, buttonWidth, buttonHeight), "Load"))
        {
            StreamReader sr = new StreamReader("Position.txt");
            if (sr != null)
            {
                while (!sr.EndOfStream)
                {
                    x = System.Convert.ToSingle(sr.ReadLine());
                    y = System.Convert.ToSingle(sr.ReadLine());
                    z = System.Convert.ToSingle(sr.ReadLine());
                }
                if (x != 0 && y != 0 && z != 0)
                    player.transform.position = new Vector3(x, y, z);

                Cursor.visible = false;
                isPause = false;
            }
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
}
