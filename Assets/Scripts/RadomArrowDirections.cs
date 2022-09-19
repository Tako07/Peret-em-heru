using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class RadomArrowDirections : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas canvasFather;
    [SerializeField] GameObject arrow;
    public int arrowQuantity;
    private int[] arrowDirections;
    private int nextArrow;
    FMODUnity.StudioEventEmitter emisorflechas, emisorcuts, emisorsnap, emisorwhoosh;
    public string interactableObject;
    [SerializeField] GameObject cutscene1;

    private CharacterInput arrowControls;
    private Player player;
    private void Awake(){
        arrowControls = new CharacterInput();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.enableMovement = false;
    }
    private void OnEnable() {
        arrowControls.Enable();
        generateNewArrows();
    }

    private void OnDisable() {
        arrowControls.Disable();
        player.enableMovement = true;
    }

    // Update is called once per frame
    void Update(){
        arrowControls.Arrows.Down.performed += DownPressed;
        arrowControls.Arrows.Up.performed += UpPressed;
        arrowControls.Arrows.Left.performed += LeftPressed;
        arrowControls.Arrows.Right.performed += RightPressed;
    }

    private int RandomDirection(){
        int[] directions = new int[4] {0, 90, 180, -90};
        
        int randomPosition = Random.Range(0,4);
        return directions[randomPosition];
    }
        //sonido de flechas


    private void DownPressed(InputAction.CallbackContext context){
        //reproduce sonido



        emisorflechas = GameObject.Find("flecha_abajo").GetComponent<FMODUnity.StudioEventEmitter>();
        emisorwhoosh = GameObject.Find("whoosh").GetComponent<FMODUnity.StudioEventEmitter>();
        emisorflechas.Play();




        if (arrowDirections[nextArrow] == 180){
            if (riddleCompleted())
                emisorwhoosh.Play();
                Debug.Log("Empezar cinematica");
        }
        else{
            gameObject.SetActive(false);
        }
    }

    private void UpPressed(InputAction.CallbackContext context){

        emisorflechas = GameObject.Find("flecha_arriba").GetComponent<FMODUnity.StudioEventEmitter>();
        emisorwhoosh = GameObject.Find("whoosh").GetComponent<FMODUnity.StudioEventEmitter>();
        emisorflechas.Play();

        if (arrowDirections[nextArrow] == 0){
            if (riddleCompleted())
                emisorwhoosh.Play();
                Debug.Log("Empezar cinematica");
        }
        else{
            gameObject.SetActive(false);
        }
    }

    private void LeftPressed(InputAction.CallbackContext context){

        emisorflechas = GameObject.Find("flecha_izquierda").GetComponent<FMODUnity.StudioEventEmitter>();
        emisorwhoosh = GameObject.Find("whoosh").GetComponent<FMODUnity.StudioEventEmitter>();
        emisorflechas.Play();

        if (arrowDirections[nextArrow] == 90){
            if (riddleCompleted())
                emisorwhoosh.Play();
                Debug.Log("Empezar cinematica");
        }
        else{
            gameObject.SetActive(false);
        }
    }

    private void RightPressed(InputAction.CallbackContext context){

        emisorflechas = GameObject.Find("flecha_derecha").GetComponent<FMODUnity.StudioEventEmitter>();
        emisorwhoosh = GameObject.Find("whoosh").GetComponent<FMODUnity.StudioEventEmitter>();
        emisorflechas.Play();

        if (arrowDirections[nextArrow] == -90){
            if (riddleCompleted())
                emisorwhoosh.Play();
                Debug.Log("Empezar cinematica");
        }
        else{
            gameObject.SetActive(false);
        }
    }

    private void generateNewArrows(){
        Vector3 newArrowPosition = Vector3.zero;
        arrowDirections = new int[arrowQuantity];
        nextArrow = 0;
        //Sonido para cuando se abre la ventana
        for (int i = 0; i < arrowQuantity; i++){
            int direction = RandomDirection();
            arrowDirections[i] = direction;
            GameObject newArrow = Instantiate(arrow, newArrowPosition, transform.rotation) as GameObject;
            newArrow.transform.SetParent(this.transform, false);
            newArrow.transform.rotation = Quaternion.Euler(Vector3.forward * direction);
            newArrowPosition += new Vector3(100f, 0, 0);
        }
    }

    private bool riddleCompleted(){
        if(nextArrow < arrowDirections.Length -1 ){
            nextArrow += 1;
            return false;
        }
        else{
            gameObject.SetActive(false);
            switch (interactableObject){
                case "escriba":
                    emisorcuts = GameObject.Find("cutscene_1").GetComponent<FMODUnity.StudioEventEmitter>();
                    emisorsnap = GameObject.Find("snap").GetComponent<FMODUnity.StudioEventEmitter>();
                    emisorsnap.Play();
                    emisorcuts.Play();
                    cutscene1.SetActive(true);
                break;
            }
            return true;
        }
    }
}
