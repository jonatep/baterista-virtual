using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using Melanchall.DryWetMidi.Standards;
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
    
    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
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

        foreach (var lane in lanes) lane.SetTimeStamps(array);

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
        ReadFromFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
