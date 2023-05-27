using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using System.Text.RegularExpressions;
using System;
using AnotherFileBrowser.Windows;
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
        var bp = new BrowserProperties(); 
        bp.filter = "midi files (*.mid)|*.mid";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            if (path.Length != 0)
            {
                rutaMIDI = path;
                archivoMIDI.text = path;
                ComprobarArchivos();
            }
        });
    }

    public void SeleccionarMP3()
    {
        var bp = new BrowserProperties(); 
        bp.filter = "mp3 files (*.mp3)|*.mp3";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            if (path.Length != 0)
            {
                rutaMP3 = "file:///" +  path;
                archivoMP3.text = path;
                ComprobarArchivos();
            }
        });

    }

    private void OnDisable() 
    {
        PlayerPrefs.SetString("rutaMIDI", rutaMIDI);
        PlayerPrefs.SetString("rutaMP3", rutaMP3);
    }
}