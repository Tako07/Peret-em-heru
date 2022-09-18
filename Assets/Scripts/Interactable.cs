using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isInRange;
    public UnityEvent interactAction;
    CharacterInput playerControls;
    private void Awake(){
        playerControls = new CharacterInput();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }
    // Update is called once per frame
    void Update(){

        bool isInteractable = playerControls.Player.InteractObjects.ReadValue<float>() > 0.1f;
        if(isInRange && isInteractable){
            interactAction.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("here");
        if (other.gameObject.CompareTag("Player")){
            isInRange = true;
            Debug.Log("is in range now");
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            isInRange = false;
            Debug.Log("is not in range now");
        }
    }
}

