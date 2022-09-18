using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaccion_objetosfx : MonoBehaviour
{
    FMODUnity.StudioEventEmitter emisorintobjeto;
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
        emisorintobjeto = GameObject.Find("interaccion_objeto").GetComponent<FMODUnity.StudioEventEmitter>();

        if (!emisorintobjeto.IsPlaying()) emisorintobjeto.Play();
    }

}
