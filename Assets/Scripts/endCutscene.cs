using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject endCutsceneVideo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            endCutsceneVideo.SetActive(true);
        }
    }
}
