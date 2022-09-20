using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endVideo : MonoBehaviour
{
    // Start is called before the first frame update
    FMODUnity.StudioEventEmitter emisorcuts;
    void Start()
    {
        emisorcuts = GameObject.Find("cutscene_end").GetComponent<FMODUnity.StudioEventEmitter>();
        emisorcuts.Play();
        gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().loopPointReached += endVideoPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void endVideoPlayer(UnityEngine.Video.VideoPlayer vp){
        SceneManager.LoadScene("MainMenu");
    }
}
