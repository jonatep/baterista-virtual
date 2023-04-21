using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using System.Text.RegularExpressions;
using System;
public class MenuAjustes : MonoBehaviour
{
    static float volumen = 1f;
    static int velocidad = 0;
    public TextMeshProUGUI textoError;
    public Slider barraVolumen;
    public TextMeshProUGUI inputVelocidad;
    private void OnDisable() 
    {
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

    public void ActualizarValores()
    {
        barraVolumen.value = volumen;
        inputVelocidad.text = velocidad.ToString();
    }
}