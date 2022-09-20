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
    private string [] riddleDialog = new string[]{
        "Intenta recordar... memoriza y anota el orden correcto"
    };

    private string [] afterEscriba = new string[]{
        "Claro, aquí dice Escriba…",
        "Así es… ¡Yo soy un Escriba! ",
        "Y uno excelente... pero ¿a qué costo?"
    };

    private string [] memoryBoomerangBegins = new string[] {
        "Tan silencioso… como extraño lir a las bellas marismas, refrescarme en las aguas y cazar palomas… ¡o un ganso! ",
        "Como quisiera volver a probar una oca a la parrilla…",
        "Pero si es mi viejo qmA [arma-bastón], mi acompañante en tantas cacerías.",
        "Sal... de esos... arbustos. ",
        "Mucho mejor, ese no es lugar para tan fino qmA... regalo de mi querida hija, Ahmose... espera ¿tengo una hija?"
    };
    private string [] memoryBoomerangEnds = new string[] {
        "Te hubiera dejado jugar ese día, al menos así ahora podría recordarte feliz antes de enfrentarme a este vacío."
    };
    
    private string [] memoryCopaBegins = new string[] {
        "Es esto…. ¿un loto? Tan azul… buen compañero en fiestas. Espera, ¡si es mi copa favorita!",
        "Por fin podré aplacar la sed… ¡agua, cerveza o con un poco de suerte… algo más fuerte...para aplacar los nervios! ",
        "Ni una gota de nada... pero esta copa me recuerda algo."
    };
    private string [] memoryCopaEnds = new string[] {
        "Promesas vacías como esta copa",
        "¿Será mi castigo recordar lo peor de mi, sin saber si quiera mi propio nombre?",
        "Aquella tormenta de la que hablaba... ",
        "No importa, será mejor que continúe."
    };
    
    private string [] memoryTopperBegins = new string[] {
        "¿Seré tragado por las arenas del isefet [caos]? ¡¿Vagaré por siempre sin ofrendas de pan y cerveza para mi pobre bah [espíritu]?!",
        "Espera... ¡Yo recuerdo esa caja con forma de ganso! ¡Dentro debe estar un buen ganso para comer!",
        "Aquí dice 'una ofrenda que da el rey a N---- de Abydos. Él da una ofrenda de aves y de todas las cosas buenas y puras para el ka [fuerza vital] del justo de voz.'"
    };
    private string [] memoryTopperEnds = new string[] {
        "¡Hathsepsut, Ahmose!",
        "¡¿Porqué no estuve a su lado cuando podía?!",
        "Siento la segunda muerte acercarse y ni siquiera cuento con el consuelo de tener memorias suyas para enfrentarla."
    };
    
        private string [] memoryEstatuaBegins = new string[] {
        "¡ahí hay algo… o alguien! ¡Hey amigo!",
        "Oh… ¿amiguito?... Esperaba que fueras más grande y vivo y hablante... otra cosa inmóvil en esta grandísima nada.",
        "Aunque tu cara... Yo he visto esos ojos, ese cabello… antes. ¿Dónde te vi?",
        "¡Grandísimos Dioses! ¡Soy yo! ¡Es mi rostro!"
    };
        private string [] memoryEstatuaEnds = new string[] {
        "Aquí dice algo: El iluminado, el osiris Nebamun justo de voz",
        "¡Nebamun! ¡NEBAMUN! ¡Ese es mi nombre! ¡Soy Nebamun, el escriba de Amón! ¡He recuperado mi nombre!",
        "El iluminado, el Osiris… ",
        "... ¡El OSIRIS!",
        "¿El Osiris? ¿El muerto? ¿Cómo el mismo dios muerto?",
        "Así que he cruzado el horizonte… he muerto, me he convertido en un Osiris… ",
        "Ya no estoy en el mundo de los vivos, sino en la Duat.",
        "Esta nada, este Nun [Agua primordial] me hacia sospechar. ¡Oh mi bella, noble y amada Hathshepsut! "
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

    public void DialogEndEscriba(){
        dialogNumber = 0;
        Debug.Log("Starting dialog");
        GetCurrentDialog("end_escriba");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogNearBoomerang(){
        Debug.Log("Starting dialog");
        GetCurrentDialog("near_boomerang");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogEndBoomerang(){
        dialogNumber = 0;
        Debug.Log("Starting dialog");
        GetCurrentDialog("end_boomerang");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }
    public void DialogNearTopper(){
        Debug.Log("Starting dialog");
        GetCurrentDialog("near_topper");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogEndTopper(){
        dialogNumber = 0;
        Debug.Log("Starting dialog");
        GetCurrentDialog("end_topper");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogNearCopa(){
        Debug.Log("Starting dialog");
        GetCurrentDialog("near_copa");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogEndCopa(){
        dialogNumber = 0;
        Debug.Log("Starting dialog");
        GetCurrentDialog("end_copa");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogNearStatua(){
        Debug.Log("Starting dialog");
        GetCurrentDialog("near_statua");
        GameObject.Find("Protagonist").GetComponent<Player>().enableMovement = false;
        canvasText.text= currentDialog[0];
        dialogsPanel.SetActive(true);
    }

    public void DialogEndStatua(){
        dialogNumber = 0;
        Debug.Log("Starting dialog");
        GetCurrentDialog("near_statua");
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
            case "end_escriba":
                currentDialog =  afterEscriba;
            break;
            case "near_boomerang":
                currentDialog =  memoryBoomerangBegins;
            break;
            case "end_boomerang":
                currentDialog =  memoryBoomerangEnds;
            break;
            case "near_topper":
                currentDialog =  memoryTopperBegins;
            break;
            case "end_topper":
                currentDialog =  memoryTopperEnds;
            break;
            case "near_copa":
                currentDialog =  memoryCopaBegins;
            break;
            case "end_copa":
                currentDialog =  memoryCopaEnds;
            break;
            case "near_statua":
                currentDialog =  memoryEstatuaBegins;
            break;
            case "end_statua":
                currentDialog =  memoryEstatuaEnds;
            break;
        }
    }

    
}
