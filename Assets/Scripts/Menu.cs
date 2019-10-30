using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour
{
    [HideInInspector] public float x;
    [HideInInspector] public float y;
    [HideInInspector] public float z;

    public static bool isFullScreen;
    public GameObject noSave;
    //public ScreenFader screenFader;
    //public Slider valueMusic;
    //public Slider valueSound;
    //public static float volumeMusic;
    //public static float volumeSound;

    public void NewGamePressed()
    {
        StreamWriter sw = new StreamWriter("Save.txt");
        sw.WriteLine(0);
        sw.Close();
        //screenFader.fadeState = ScreenFader.FadeState.In;
        //Invoke("LoadScene", 1 / screenFader.fadeSpeed);
        LoadScene();
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
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

    public void LoadGamePressed()
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
            {
                StreamWriter sw = new StreamWriter("Save.txt");
                sw.WriteLine(1);
                sw.Close();
                LoadScene();
            }
            else
                noSave.SetActive(true);
        }       
        sr.Close();
    }

    void Start()
    {
        Time.timeScale = 1f;
        isFullScreen = Screen.fullScreen;
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
