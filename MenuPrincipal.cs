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
    static string rutaMIDI;
    static string rutaMP3;
    static float volumen = 1f;
    static int velocidad = 0;
    public TextMeshProUGUI textoError;
    public TextMeshProUGUI archivoMP3;
    public TextMeshProUGUI archivoMIDI;

    void Start()
    {
        if (rutaMIDI != null && rutaMP3 != null)
        {
            archivoMP3.text = rutaMP3;
            archivoMIDI.text = rutaMIDI;
        }
    }
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
        PlayerPrefs.SetFloat("volumen", volumen);
        PlayerPrefs.SetInt("velocidad", velocidad);
    }

    public void ActualizarVolumen(float nuevoVolumen)
    {
        volumen = nuevoVolumen;
    }

    public void ActualizarVelocidad(string nuevaVelocidad)
    {
        try
        {
            int n = int.Parse(nuevaVelocidad);
            if (n >= 0 && n <= 100)
            {
                velocidad = n;
                textoError.text = "";
            }
            else
            {
                textoError.text = "Solo puedes introducir números comprendidos entre 0 y 100";
            }

        } catch (FormatException) {
            textoError.text = "Solo puedes introducir números comprendidos entre 0 y 100";
        }
    }
}