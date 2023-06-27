using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//read - animate - next - buildUp - awnser - correction - settle - finalSecctionText
public class CorrectionScriptPJ3 : MonoBehaviour
{
    [HideInInspector] public string[] textToRender;
    [HideInInspector] public string[] correctTextToRender;
    [HideInInspector] public string[] incorrectTextToRender;
    [HideInInspector] public string[] step;
    [HideInInspector] public float[] CvZoom;

    [HideInInspector] public RectTransform [] CvSectionsPos;
    [HideInInspector] public Transform [] SectionOffset;
    [HideInInspector] public Section [] CvSectionsGO;
    [HideInInspector] public string[] pageTexts;

    GameObject mask;
    // The cv
    GameObject Cv;
    // Start is called before the first frame update
    void Start()
    {
        mask = gameObject.transform.Find("Mask").gameObject;
        // Zooms:
        CvZoom = new float[]{1.5f,1.51f,1.51f,1.51f,1.51f,1.51f,1.51f};
        //
        CvSectionsGO = new Section[7];
        Cv = mask.transform.Find("CV").gameObject;
        CvSectionsGO[0] = Cv.transform.Find("Name").gameObject.GetComponent<Section>();
        CvSectionsGO[1] = Cv.transform.Find("Presentation").gameObject.GetComponent<Section>();
        CvSectionsGO[2] = Cv.transform.Find("Experience").gameObject.GetComponent<Section>();
        CvSectionsGO[3] = Cv.transform.Find("Education").gameObject.GetComponent<Section>();
        CvSectionsGO[4] = Cv.transform.Find("Abilities").gameObject.GetComponent<Section>();
        CvSectionsGO[5] = Cv.transform.Find("Lenguage").gameObject.GetComponent<Section>();
        CvSectionsGO[6] = Cv.transform.Find("Contact").gameObject.GetComponent<Section>();
        // 
        CvSectionsPos = new RectTransform[7];        
        CvSectionsPos[0] = Cv.transform.Find("Name").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[1] = Cv.transform.Find("Presentation").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[2] = Cv.transform.Find("Experience").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[3] = Cv.transform.Find("Education").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[4] = Cv.transform.Find("Abilities").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[5] = Cv.transform.Find("Lenguage").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[6] = Cv.transform.Find("Contact").gameObject.GetComponent<RectTransform>();
        //
        SectionOffset = new Transform[7]; 
        SectionOffset[0] = Cv.transform.Find("Name").transform.Find("Offset").GetComponent<Transform>();  
        SectionOffset[1] = Cv.transform.Find("Presentation").Find("Offset").GetComponent<Transform>(); 
        SectionOffset[2] = Cv.transform.Find("Experience").Find("Offset").GetComponent<Transform>();
        SectionOffset[3] = Cv.transform.Find("Education").Find("Offset").GetComponent<Transform>();
        SectionOffset[4] = Cv.transform.Find("Abilities").Find("Offset").GetComponent<Transform>();
        SectionOffset[5] = Cv.transform.Find("Lenguage").Find("Offset").GetComponent<Transform>();
        SectionOffset[6] = Cv.transform.Find("Contact").Find("Offset").GetComponent<Transform>();
        //Debug.Log(SectionOffset[4]);
        //
        pageTexts = new string[7];   
        pageTexts[0] = "NOMBRE";
        pageTexts[1] = "PERFIL LABORAL";
        pageTexts[2] = "EXPERIENCIA";
        pageTexts[3] = "FORMACIÓN";
        pageTexts[4] = "HABILIDADES";
        pageTexts[5] = "IDIOMAS";
        pageTexts[6] = "CONTACTO";
        // Normal text:
        step = new string[]{
        "read", "animate", "buildUp", "awnser", "correction", "settle", "next", // Name
        "buildUp", "awnser", "correction", "settle", "next", // Presentation
        "buildUp", "awnser", "correction", "settle", "next", // Experience
        "buildUp", "awnser", "correction", "settle", "next", // Education
        "buildUp", "awnser", "correction", "settle", "next", // Abilities
        "buildUp", "awnser", "correction", "settle", "next", // Lenguage
        "buildUp", "awnser", "correction", "settle", // Contact
        "endZoom","read","read","read","read","read",
        "cueEndScene","cueEndScene","cueEndScene","cueEndScene","cueEndScene",
        };

        textToRender = new string[100];
        // Presentation:
        textToRender[0] = "Muy bien, corrijamos el CV. Empecemos por el nombre...";
        textToRender[1] = "Muy bien, corrijamos el CV. Empecemos por el nombre...";
        textToRender[2] = "Veamos...";    
        textToRender[3] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[4] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[5] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[6] = "Revisemos el perfil...";
        // Education:
        textToRender[7] = "A ver qué pasa acá...";
        textToRender[8] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[9] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[10] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[11] = "Miremos la experiencia...";
        // Experience:
        textToRender[12] = "A ver...";
        textToRender[13] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[14] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[15] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[16] = "Y a ver la formación...";
        // Ad Ed:
        textToRender[17] = "Veamos...";
        textToRender[18] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[19] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[20] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[21] = "Miremos las habilidades...";
        // Abilities:
        textToRender[22] = "A ver...";
        textToRender[23] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[24] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[25] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[26] = "Y los idiomas...";
        // Lenguages:
        textToRender[27] = "Veamos...";
        textToRender[28] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[29] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[30] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[31] = "Y por último la información de contacto...";
        // Lenguages:
        textToRender[32] = "A ver qué pasa acá...";
        textToRender[33] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[34] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[35] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[36] = "¡Terminamos, revisamos todo el CV!";

        
        // End game:
        textToRender[37] = "Démosle una última leída y fijémonos cómo quedó.";
        textToRender[38] = "Recordá siempre revisar muy bien tu CV.";
        textToRender[39] = "Te recomendamos pedirle a amigos o conocidos que también lo vean y te den una devolución.";
        textToRender[40] = "¡Otro par de ojos nunca están de más!";
        textToRender[41] = "Con esto llegamos al final. ¡Esperamos que te sirvan alguno de estos consejos! :D";
        textToRender[42] = "— GRACIAS POR JUGAR —";
        textToRender[43] = "Desarrollo:\nPablo Sonaglioni \n @pgs1000";
        textToRender[44] = "Diseño gráfico:\nEmmanuel Schönfeld Estani \n @_emmyta";
        textToRender[45] = "Agradecimientos especiales \n Lorena Escobedo";

        // Correct awnsered by player text:
        correctTextToRender = new string[100];
        // Name:
        correctTextToRender[3] = "¡Muy bien! Te diste cuenta que nos está faltando algo por acá.";
        correctTextToRender[4] = "Nunca olvidemos agregar nuestra profesión o puesto al que apuntamos.";
        correctTextToRender[5] = "Y una cosa más. Este CV no tiene foto, recordá que no es obligatoria. Continuemos.";
        // Presentation:
        correctTextToRender[8] = "¡Muy bien! Este perfil queda como está.";
        correctTextToRender[9] = "Está bien claro quién es y sus intenciones de búsqueda.";
        correctTextToRender[10] = "Todos los perfiles pueden ser diferentes pero lo más importante es ser claros y concisos. Sigamos.";
        // :Experience
        correctTextToRender[13] = "¡Genial! Pudiste ver que había un problema con la cronología.";
        correctTextToRender[14] = "Nuestras experiencias siempre deben ir de la más actual a la más antigua.";
        correctTextToRender[15] = "Algo más: este mismo orden aplica también a la educación y formación. A ver que sigue...";
        // Education:
        correctTextToRender[18] = "¡Bien! Las palabras mal escritas y la falta de tildes no las podemos dejar pasar.";
        correctTextToRender[19] = "Tenemos que estar muy atentos a estas cosas.";
        correctTextToRender[20] = "¡Genial! Continuemos con el CV.";
        // Abilities:
        correctTextToRender[23] = "¡Muy bien! Acá está pasando algo, ¿no?";
        correctTextToRender[24] = "Las habilidades deben estar detalladas y presentadas de manera clara.";
        correctTextToRender[25] = "Es un detalle pero mientras más claro seamos mejor. Ya estamos terminando...";
        // Lenguage:
        correctTextToRender[28] = "Saber idiomas es clave, ¿Pero qué nivel tenemos?";
        correctTextToRender[29] = "Siempre agreguemos el nivel y el instituto si es que fuimos a uno.";
        correctTextToRender[30] = "Esto siempre va a ayudar a reforzar nuestras postulaciones.";
        // Contact:
        correctTextToRender[33] = "¡Perfecto! Esta información está correcta.";
        correctTextToRender[34] = "Es concreta y contiene lo necesario.";
        correctTextToRender[35] = "Es muy importante revistar que no falte nada importante y que esté actualizada.";


        // Wrongly awnsered by player:
        incorrectTextToRender = new string[100];
        // Name:
        incorrectTextToRender[3] = "¡Cuidado! Acá nos estaría faltando algo...¿Qué será?";
        incorrectTextToRender[4] = "¡Claro! No olvidemos agregar nuestra profesión o puesto al que apuntamos en el CV.";
        incorrectTextToRender[5] = "Y una cosa más. Este CV no tiene foto, recordá que no es obligatoria. Continuemos.";
        // Presentation:
        incorrectTextToRender[8] = "¡Ojo! ¿Encontraste algo raro?";
        incorrectTextToRender[9] = "Expresa muy claramente quién es y sus intenciones de búsqueda.";
        incorrectTextToRender[10] = "Todos los perfiles pueden ser diferentes pero lo más importante es ser claros y concisos. Sigamos.";
        // Education:
        incorrectTextToRender[13] = "¡Cuidado! No te diste cuenta pero hay un problema con la cronología.";
        incorrectTextToRender[14] = "Nuestras experiencias siempre deben ir de la más actual a la más antigua.";
        incorrectTextToRender[15] = "Algo más: este mismo orden aplica también a la educación y formación. A ver que sigue...";
        // Experience:
        incorrectTextToRender[18] = "¡Cuidado! Las palabras mal escritas y la falta de tildes no las podemos dejar pasar.";
        incorrectTextToRender[19] = "Tenemos que estar muy atentos a estas cosas.";
        incorrectTextToRender[20] = "¡Genial! Continuemos con el CV.";
        // Abilities:
        incorrectTextToRender[23] = "¡Ojo! Acá está pasando algo.";
        incorrectTextToRender[24] = "Las habilidades deben estar detalladas y presentadas de manera clara.";
        incorrectTextToRender[25] = "Es un detalle pero mientras más claro seamos mejor. Ya estamos terminando...";
        // Lenguage:
        incorrectTextToRender[28] = "Saber idiomas es clave, ¿Pero qué nivel tenemos?";
        incorrectTextToRender[29] = "Siempre agreguemos el nivel y el instituto si es que fuimos a uno.";
        incorrectTextToRender[30] = "Esto siempre va a ayudar a reforzar nuestras postulaciones.";
        // Contact:
        incorrectTextToRender[33] = "¡Ojo! ¿Qué te pareció raro en esta sección?";
        incorrectTextToRender[34] = "Es concreta y contiene lo necesario.";
        incorrectTextToRender[35] = "Es muy importante revistar que no falte nada importante y que esté actualizada.";
    }


}
