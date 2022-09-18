using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papirosfx : MonoBehaviour
{
    FMODUnity.StudioEventEmitter emisorpapiro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reproducirSonido()
    {
        emisorpapiro = GameObject.Find("papiro").GetComponent<FMODUnity.StudioEventEmitter>();

        if (!emisorpapiro.IsPlaying()) emisorpapiro.Play(); 
    } 

}
