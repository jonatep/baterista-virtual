using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Interaction;
using System.Linq;
public class Instrument : MonoBehaviour
{

    public Melanchall.DryWetMidi.Standards.GeneralMidi2RoomPercussion[] noteRestriction;
    public GameObject notePrefab;
    public List<double> timeStamps;

    public Transform parteCuerpo;

    public string direccionMirar;

    int spawnIndex = 0;
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array, int velocidad)
    {
        int [] restrictions = noteRestriction.Select(s => (int) s).ToArray();
        foreach (var note in array)
        {
            if (restrictions.Contains(note.NoteNumber + 12) && note.Velocity >= velocidad)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan> (note.Time, DrumManager.midiFile.GetTempoMap());
                double timing = (double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f;
                timeStamps.Add(timing-2);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(parteCuerpo.name == "Drumstick_Right" || parteCuerpo.name == "Drumstick_Left")
        {
            AnimationHand animator = FindObjectOfType<AnimationHand>();
            animator.setTargets(notePrefab, parteCuerpo);
        }
        else
        {
            AnimationFoot animatorFoot = FindObjectOfType<AnimationFoot>();
            animatorFoot.setTargets(notePrefab, parteCuerpo); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnIndex < timeStamps.Count)
        {
            if (DrumManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - DrumManager.Instance.noteTime)
            {
                if(parteCuerpo.name == "Drumstick_Right" || parteCuerpo.name == "Drumstick_Left")
                {
                    AnimationHand animator = FindObjectOfType<AnimationHand>();
                    animator.moveHand(notePrefab, parteCuerpo, direccionMirar);
                }
                else
                {
                    AnimationFoot animatorFoot = FindObjectOfType<AnimationFoot>();
                    animatorFoot.moveFoot(notePrefab, parteCuerpo); 
                }
                spawnIndex++;
            }
        }
    }
}
