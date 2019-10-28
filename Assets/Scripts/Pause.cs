using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject menu;
    float timer;
    [HideInInspector] public bool isPause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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

    public void BackToMenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    
}
