using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class MenuPrincipal : MonoBehaviour
{

    static string rutaMIDI;
    static string rutaMP3;

    public void ComienzoAnimacion()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SalirAPP()
    {
        Application.Quit();
    }

    public void SeleccionarMIDI()
    {
        string path = EditorUtility.OpenFilePanel("Seleccionar MIDI", "", "mid");
        if (path.Length != 0)
        {
            rutaMIDI = path;
        }
    }

    public void SeleccionarMP3()
    {
        string path = EditorUtility.OpenFilePanel("Seleccionar MP3", "", "mp3");
        if (path.Length != 0)
        {
            rutaMP3 = "file:///" +  path;
        }
    }

    private void OnDisable() 
    {
        PlayerPrefs.SetString("rutaMIDI", rutaMIDI);
        PlayerPrefs.SetString("rutaMP3", rutaMP3);
    }
}