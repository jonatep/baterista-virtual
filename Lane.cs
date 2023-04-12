using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Interaction;
using System.Linq;
public class Lane : MonoBehaviour
{

    public Melanchall.DryWetMidi.Standards.GeneralMidi2RoomPercussion[] noteRestriction;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps;

    public Transform parteCuerpo;


    int spawnIndex = 0;
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        int [] restrictions = noteRestriction.Select(s => (int) s).ToArray();
        foreach (var note in array)
        {
            // if (note.NoteNumber + 12 == (int) noteRestriction[0])
            if (restrictions.Contains(note.NoteNumber + 12))
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan> (note.Time, DrumManager.midiFile.GetTempoMap());
                double timing = (double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f;
                timeStamps.Add(timing - 1);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnIndex < timeStamps.Count)
        {
            if (DrumManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - DrumManager.Instance.noteTime)
            {
                Animation animator = FindObjectOfType<Animation>();
                animator.moveHand(notePrefab, parteCuerpo);
                spawnIndex++;
            }
        }
        // if (spawnIndex < raiseHandTimings.Count)
        // {
        //     if (DrumManager.GetAudioSourceTime() >= raiseHandTimings[spawnIndex] - DrumManager.Instance.noteTime - 10)
        //     {
        //         Animation animator = FindObjectOfType<Animation>();
        //         animator.moveHand(notePrefab, true);
        //         spawnIndex++;
        //     }
        // }
    }
}
