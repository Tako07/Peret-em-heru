using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    FMODUnity.StudioEventEmitter emisorwhoosh;
    public string item;
    void Start()
    {
        gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().loopPointReached += endVideoPlayer;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().enableMovement = false;
        
    }

    // Update is called once per frame
    void endVideoPlayer(UnityEngine.Video.VideoPlayer vp){
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().enableMovement = true;
        TextManager dialogManager = GameObject.Find("DialogManager").GetComponent<TextManager>();
        if (item != null){
            dialogManager.nearObject = item;
        }
        switch (item){
            case "escriba":
                dialogManager.DialogEndEscriba();
            break;
            case "boomerang":
                dialogManager.DialogEndBoomerang();
            break;
            case "topper":
                dialogManager.DialogEndTopper();
            break;
            case "copa":
                dialogManager.DialogEndCopa();
            break;
            case "statua":
                dialogManager.DialogEndStatua();
            break;
        }
        gameObject.SetActive(false);
    }
}
