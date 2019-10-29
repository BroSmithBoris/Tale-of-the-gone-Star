using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Pause : MonoBehaviour
{
    public GameObject player;
    public GameObject menu;
    float timer;
    [HideInInspector] public bool isPause;

    [HideInInspector] public float x;
    [HideInInspector] public float y;
    [HideInInspector] public float z;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            menu.SetActive(isPause);
        }

        if (isPause)
            timer = 0;
        else
            timer = 1f;

        Cursor.visible = isPause;
    }

    public void ResumePressed()
    {
        menu.SetActive(false);
        isPause = false;
    }

    public void SavePressed()
    {
        StreamWriter sw = new StreamWriter("Position.txt");
        sw.WriteLine(player.transform.position.x);
        sw.WriteLine(player.transform.position.y);
        sw.WriteLine(player.transform.position.z);
        sw.Close();
    }

    public void LoadPressed()
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
            sr.Close();
            if (x != 0 && y != 0 && z != 0)
                player.transform.position = new Vector3(x, y, z);
            ResumePressed();
        }
    }

    public void BackToMenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
