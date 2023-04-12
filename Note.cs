using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    double timeInstanciated;
    public float assignedTime;
    

    // Start is called before the first frame update
    void Start()
    {
        timeInstanciated = DrumManager.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstanciated = DrumManager.GetAudioSourceTime() - timeInstanciated;
        float t = (float)(timeSinceInstanciated / (DrumManager.Instance.noteTime * 2));
    }
}
