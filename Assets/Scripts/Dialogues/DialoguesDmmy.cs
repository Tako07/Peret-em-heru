using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
     private string [] startLevel = new string[] {
            "¿Dónde… dónde estoy?",
            "Qué calor… todo es tan raro. Ni animales, ni plantas, ni ruido. Nadie más que yo  el excelente…",
            "...",
            "¡¡¡¿Cuál es mi nombre?!!!",
            "¡No recuerdo nada! ¡Esto es la nada, el Nun [océano primordial]! ¡Aquí no hay vida… ¿Cómo, cómo llegue aquí?",
            "¡Oh Dioses de las dos Tierras ayúdenme",
            "Pero no... no puede ser, sin… sin mi nombre, jamás oirán mis suplicas. ¿Qué haré?..."
        };
        private string [] interactionBoat = new string[] {
            "¿y esta barca… cómo llegó a este lugar?",
            "Vaya viaje que tuviste para terminar así… aquí.",
            "Creo que ambos necesitamos un poco de agua… ¡o cerveza! ¡Cuánto calor tengo… para ser de noche!",
            "Espera ¿Qué hay debajo de aquellas maderas?"
        };
        private string [] interactionVaca = new string[] {
            "Hathor: ¡Escriba de Amun, servidor de los Dioses! Di tu nombre, exclama el mío y te dejaré cruzar esta puerta",
            "¡Sólo así comenzarás tu verdadero viaje para llegar a los bellos campos del Ianru!",
            "Nebamun: Yo soy Nebamun, el escriba del Dios Amón y supervisor de sus graneros.",
            "¿Cómo no reconocerte graciosa diosa, si mi amada esposa era tu cantora?",
            "Hathor, Señora del Occidente y de Dendera. ¡Señora del Sicomoro y la turquesa! ¡Diosa que ilumina la vida los hombres! ",
            "¡Gracias por acudir a mi y por favor guíame para empezar mi travesía hacia la eternidad!"
        };
        //Instrucciones
        private string [] descriptionWrite = new string[] {
            "Intenta recordar... memoriza y anota el orden correcto"
        };
        //Objeto 1
        private string [] memoryEscribaBegins = new string[] {
            "No es arena… ¿Qué es? Un rollo de papiro, ¡seco y de excelente calidad! ",
            "Parece que hay algo dentro del rollo.",
            "Esto se siente bien, se siente familiar y parece que este cáñamo aún tiene tinta fresca… ¡Mucho mejor!"
        };
        
        private string [] memoryEscribaEnds = new string[] {
            "Claro, aquí dice Escriba…",
            "Así es… ¡Yo soy un Escriba! ",
            "Y uno excelente... pero ¿a qué costo?"
        };
        //Objeto 2
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
        //Objeto 3
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
        //Objeto 4
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
        //Objeto 5
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
    void Start()
    {
        //Level interactions
       
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
