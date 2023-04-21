using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using Melanchall.DryWetMidi.Standards;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public Transform camara;
    public Transform vista1;
    public Transform vista2;
    public Transform vista3;

    public void MoverCamara(Transform vista, Vector3 posicion)
    {
        camara.position = posicion;
        camara.LookAt(vista);
    }

    void Start()
    {
        MoverVista1();
    }

    public void MoverVista1()
    {
        MoverCamara(vista1, new Vector3(0.3f, 2.34f, -0.26f));
    }

    public void MoverVista2()
    {
        MoverCamara(vista2, new Vector3(-0.3338434f, 2.13f, 1.08f));
    }

    public void MoverVista3()
    {
        MoverCamara(vista3, new Vector3(-0.6667855f, 1.743848f, 0.9126078f));
    }
}