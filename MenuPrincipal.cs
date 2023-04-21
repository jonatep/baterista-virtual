using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using System.Text.RegularExpressions;
using System;
public class MenuPrincipal : MonoBehaviour
{
    static string rutaMIDI = null;
    static string rutaMP3 = null;
    public TextMeshProUGUI textoError;
    public TextMeshProUGUI archivoMP3;
    public TextMeshProUGUI archivoMIDI;

    public void ComienzoAnimacion()
    {
        if (rutaMIDI == null || rutaMP3 == null)
        {
            textoError.text = "Debes seleccionar tanto un archivo MIDI como MP3 antes de comenzar";
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void SalirAPP()
    {
        Application.Quit();
    }

    private void ComprobarArchivos()
    {
        if (rutaMIDI != null && rutaMP3 != null)
            {
                textoError.text = "";
            }
    }

    public void SeleccionarMIDI()
    {
        string path = EditorUtility.OpenFilePanel("Seleccionar MIDI", "", "mid");
        if (path.Length != 0)
        {
            rutaMIDI = path;
            archivoMIDI.text = path;
            ComprobarArchivos();
        }
    }

    public void SeleccionarMP3()
    {
        string path = EditorUtility.OpenFilePanel("Seleccionar MP3", "", "mp3");
        if (path.Length != 0)
        {
            rutaMP3 = "file:///" +  path;
            archivoMP3.text = path;
            ComprobarArchivos();
        }
    }

    private void OnDisable() 
    {
        PlayerPrefs.SetString("rutaMIDI", rutaMIDI);
        PlayerPrefs.SetString("rutaMP3", rutaMP3);
    }
}