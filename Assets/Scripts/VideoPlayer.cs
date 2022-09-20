using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().loopPointReached += endVideoPlayer ;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().enableMovement = false;
        
    }

    // Update is called once per frame
    void endVideoPlayer(UnityEngine.Video.VideoPlayer vp){
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().enableMovement = true;
        gameObject.SetActive(false);
    }
}
