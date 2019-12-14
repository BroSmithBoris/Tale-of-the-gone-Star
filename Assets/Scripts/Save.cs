using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Save : MonoBehaviour
{
    public string filename;

    void Start()
    {
        if (filename == "") filename = "Position.txt";
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(1);
            sw.Close();
            SceneManager.LoadScene(1);
        }
    }
}
