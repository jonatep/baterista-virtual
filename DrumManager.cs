using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using Melanchall.DryWetMidi.Standards;
using UnityEngine.SceneManagement;

public class DrumManager : MonoBehaviour
{

    public static DrumManager Instance;
    public AudioSource audioSource;
    public float songDelayInSeconds;
    public int inputDelayInMillieconds;
    public string fileLocation;
    public float noteTime;

    public static MidiFile midiFile;

    public Lane[] lanes;

    private string rutaMIDI;
    private string rutaMP3;
    private float volumen;
    private int velocidad;
    private void OnEnable() 
    {
        rutaMIDI = PlayerPrefs.GetString("rutaMIDI");
        rutaMP3 = PlayerPrefs.GetString("rutaMP3");
        volumen = PlayerPrefs.GetFloat("volumen");
        velocidad = PlayerPrefs.GetInt("velocidad");
    }
    
    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(rutaMIDI);
        GetDataFromMidi();
    }
    IEnumerator ChangeAudioClip()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(rutaMP3, AudioType.MPEG))
        {
        
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = myClip;
                audioSource.volume = volumen;
                ReadFromFile();
            }
        }
    }
    public void GetDataFromMidi()
    {
        var allNotes = midiFile.GetNotes();
        var notes = new List<Melanchall.DryWetMidi.Interaction.Note>();
        foreach (var note in allNotes)
        {
            if(note.Channel == 10 || note.Channel == 9) //Canal 10 es de la percusión
            {
                notes.Add(note);
            }
        }
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array, velocidad);
        Invoke(nameof(StartSong), songDelayInSeconds);
    }

    public void StartSong()
    {
        audioSource.Play();
    }

    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        StartCoroutine(ChangeAudioClip());
    }

    // Update is called once per frame
    public void SalirAnimacion()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}