using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    FMODUnity.StudioEventEmitter emisorcuts, emisorsnap;
    void Start()
    {
        emisorcuts = GameObject.Find("cutscene_open").GetComponent<FMODUnity.StudioEventEmitter>();
        emisorsnap = GameObject.Find("snap").GetComponent<FMODUnity.StudioEventEmitter>();
        emisorsnap.Play();
        emisorcuts.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
