﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour
{
    int saveScene = 0;

    public static bool isFullScreen;
    //public ScreenFader screenFader;
    //public Slider valueMusic;
    //public Slider valueSound;
    //public static float volumeMusic;
    //public static float volumeSound;

    public void PlayPressed()
    {
        //screenFader.fadeState = ScreenFader.FadeState.In;
        //Invoke("LoadScene", 1 / screenFader.fadeSpeed);
        LoadScene();
    }

    void LoadScene()
    {
        SceneManager.LoadScene(saveScene, LoadSceneMode.Single);
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    
    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    void Start()
    {
        Time.timeScale = 1f;
        isFullScreen = Screen.fullScreen;
        StreamReader sr = new StreamReader("Position.txt");
        if (sr != null)
        {
            saveScene = System.Convert.ToInt32(sr.ReadLine());
        }
        //screenFader.fadeState = ScreenFader.FadeState.Out;
    }

    /*
    void Update()
    {
        volumeMusic = valueMusic.value;
        volumeSound = valueSound.value;
        /AudioListener.volume = volumeMusic;
    }
    */
}
