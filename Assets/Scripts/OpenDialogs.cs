using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenDialogs : MonoBehaviour{
    public UnityEvent interactAction;
    public bool isInRange;
    private bool willOpen;
    // Start is called before the first frame update
    private void Start() {
        isInRange = false;
        willOpen = true;
    }
     void Update(){
        if(isInRange && willOpen){
            willOpen = false;
            interactAction.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && willOpen){
            isInRange = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        isInRange = false;
        willOpen = true;
    }
}
