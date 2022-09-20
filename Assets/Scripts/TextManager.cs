using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TextManager : MonoBehaviour
{

    [SerializeField] TMP_Text canvasText;
    [SerializeField] GameObject dialogsPanel;
    public bool is_active;
    public string nearObject;
    private int dialogNumber;
    CharacterInput playerControls;
    private string [] currentDialog;
    private string [] startLevel = new string[] {
        "¿Dónde… dónde estoy?",
        "Qué calor… todo es tan raro. Ni animales, ni plantas, ni ruido. Nadie más que yo  el excelente…",
        "...",
        "¡¡¡¿Cuál es mi nombre?!!!",
        "¡No recuerdo nada! ¡Esto es la nada, el Nun [océano primordial]! ¡Aquí no hay vida… ¿Cómo, cómo llegue aquí?",
        "¡Oh Dioses de las dos Tierras ayúdenme",
        "Pero no... no puede ser, sin… sin mi nombre, jamás oirán mis suplicas. ¿Qué haré?"
    };
    private string [] nearShip = new string[]{
        "¿y esta barca… cómo llegó a este lugar?",
        "Vaya viaje que tuviste para terminar así… aquí. ",
        "Creo que ambos necesitamos un poco de agua… ¡o cerveza! ¡Cuánto calor tengo… para ser de noche!",
        "Espera ¿Qué hay debajo de aquellas maderas?"
    };
    private string [] nearEscriba = new string[]{
        "No es arena… ¿Qué es? Un rollo de papiro, ¡seco y de excelente calidad! ",
        "Parece que hay algo dentro del rollo.",
        "Esto se siente bien, se siente familiar y parece que este cáñamo aún tiene tinta fresca… ¡Mucho mejor!",

    };
    private string [] escribaRiddleCompleted = new string[]{
        "Intenta recordar... memoriza y anota el orden correcto"
    };

    private string [] afterEscriba = new string[]{
        "Claro, aquí dice Escriba…",
        "Así es… ¡Yo soy un Escriba! ",
        "Y uno excelente... pero ¿a qué costo?"
    };
    // Start is called before the first frame update
    void Start()
    {
        is_active = false;
        dialogNumber = 0;

    }
    private void Awake() {
        playerControls = new CharacterInput();    
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(nearObject != null){
            playerControls.Player.NextDialog.performed += NextDialog;
        }else{
            dialogNumber= 0;
        }
        
    }

    public void DialogNearShip(){
        Debug.Log("Starting dialog");
        GetCurrentDialog("ship");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogNearEscriba(){
        Debug.Log("Starting dialog");
        GetCurrentDialog("near_escriba");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogNearCopa(){
        Debug.Log("Starting dialog");
        GetCurrentDialog("near_escriba");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogNearTopper(){
        Debug.Log("Starting dialog");
        GetCurrentDialog("near_escriba");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogNearBoomerang(){
        Debug.Log("Starting dialog");
        GetCurrentDialog("near_escriba");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogNearStatua(){
        Debug.Log("Starting dialog");
        GetCurrentDialog("near_escriba");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    void NextDialog(InputAction.CallbackContext context){
        dialogNumber += 1;
        if(dialogNumber >= currentDialog.Length){
            GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = true;
            dialogsPanel.SetActive(false);
        }
        else{
            canvasText.text = currentDialog[dialogNumber];
        }

    }
    void GetCurrentDialog(string nearObjectToCheck){
        switch (nearObjectToCheck){
            case "ship":
                currentDialog = nearShip;
            break;
            case "near_escriba":
                currentDialog =  nearEscriba;
            break;
        }
    }

    
}
