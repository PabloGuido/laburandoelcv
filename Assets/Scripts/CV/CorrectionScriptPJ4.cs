using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//read - animate - next - buildUp - awnser - correction - settle - finalSecctionText
public class CorrectionScriptPJ4 : MonoBehaviour
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
        pageTexts[2] = "PORFOLIO";
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
        textToRender[0] = "0: Muy bien, corrijamos el cv. Empecemos por el nombre.";
        textToRender[1] = "1: Muy bien, corrijamos el cv. Empecemos por el nombre.";
        textToRender[2] = "2: Veamos...";    
        textToRender[3] = "3: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[4] = "4: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[5] = "5: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[6] = "6: Revisemos el perfil.";
        // Education:
        textToRender[7] = "7: A ver que pasa acá...";
        textToRender[8] = "8:CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[9] = "9: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[10] = "10: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[11] = "11: Miremos la experiencia.";
        // Experience:
        textToRender[12] = "12: A ver...";
        textToRender[13] = "13:CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[14] = "14: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[15] = "15: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[16] = "16: Y a ver la formación...";
        // Ad Ed:
        textToRender[17] = "17: Veamos...";
        textToRender[18] = "18: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[19] = "19: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[20] = "20: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[21] = "21: Miremos las habilidades.";
        // Abilities:
        textToRender[22] = "22: A ver...";
        textToRender[23] = "23: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[24] = "24: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[25] = "25: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[26] = "26: Y los idiomas...";
        // Lenguages:
        textToRender[27] = "27: Veamos...";
        textToRender[28] = "28: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[29] = "29: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[30] = "30: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[31] = "31: Y por último la info de contacto.";
        // Lenguages:
        textToRender[32] = "27: A ver que pasa acá...";
        textToRender[33] = "28: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[34] = "29: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[35] = "30: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[36] = "31: Y con esto vimos todo el CV!";

        
        // End game:
        textToRender[37] = "32: Dale una última leída y fijate como quedó.";
        textToRender[38] = "33: Recordá siempre revisar muy bien tu CV.";
        textToRender[39] = "34: Pedí a tus conocidos y amigos que lo revisen y te den una devolución sobre el mismo también.";
        textToRender[40] = "35: Otro par de ojos nunca está de mas!";
        textToRender[41] = "36: Con esto llegamos al final. Espero que alguno de estos consejos te puedan servir :D";
        textToRender[42] = "37: Gracias por jugar!";
        textToRender[43] = "38: Desarrollador por:\nPablo Sonaglioni \n @pgs1000";
        textToRender[44] = "39: @emmyta";
        textToRender[45] = "41: Especial gracias para Lorena Escobedo";

        // Correct awnsered by player text:
        correctTextToRender = new string[100];
        // Name:
        correctTextToRender[3] = "3: Muy bien! Te diste cuenta que nos está faltando algo por acá.";
        correctTextToRender[4] = "4: Nunca olvidemos agregar nuestra profesión o puesto al que apuntamos!";
        correctTextToRender[5] = "5: Por cierto, en este CV hay foto pero podes elegir tenerla como no. Continuemos.";
        // Presentation:
        correctTextToRender[8] = "8: Quizás podamos modificar un poco este perfil profesional, no?";
        correctTextToRender[9] = "9: Reflexionar sobre cuál es tu misión, visión y valores para transmitirlos en esta sección.";
        correctTextToRender[10] = "10: Qué te parece este perfil ahora? Vamos a ver que sigue.";
        // :Experience
        correctTextToRender[13] = "13: Perfecto. Esto es clave.";
        correctTextToRender[14] = "14: Cuando no tengamos experiencia un buen porfolio es clave para mostrar nuestras capacidades";
        correctTextToRender[15] = "15: Siempre asegurase que funcionen nuestros links y de tener unos buenos ejemplos para mostrar!";
        // Education:
        correctTextToRender[18] = "18: Sí, lo viste. A esta información le faltan algunos detalles. ";
        correctTextToRender[19] = "19: Es importante agregar las fechas y el estado de nuestros estudios!";
        correctTextToRender[20] = "20: Genial! Sigamos.";
        // Abilities:
        correctTextToRender[23] = "23: Muy bien! Acá está pasando algo, no?";
        correctTextToRender[24] = "24: Recordá! Las habilidades deben estar detalladas y de manera clara.";
        correctTextToRender[25] = "25: Es un detalle pero mientras mas claro seamos mejor! Ya estamos terminando...";
        // Lenguage:
        correctTextToRender[28] = "28: Saber idiomas es clave, pero qué nivel tenemos?";
        correctTextToRender[29] = "29: Siempre agreguemos el nivel y el instituto si es que fuimos a uno!";
        correctTextToRender[30] = "30: Esto siempre va a ayudar a reforzar nuestras postulaciones sin dudas.";
        // Contact:
        correctTextToRender[33] = "28: Ojo. Qué te pareció raro de esta sección?";
        correctTextToRender[34] = "29: La información de contacto no necesita ser extensa.";
        correctTextToRender[35] = "30: Pero es muy importante revistar que no haya ninguna falta y que esté actualizada.";


        // Wrongly awnsered by player:
        incorrectTextToRender = new string[100];
        // Name:
        incorrectTextToRender[3] = "3: ¡Cuidado! Acá nos estaría faltando algo.. Qué será?";
        incorrectTextToRender[4] = "4: Claro! No olvidemos agregar nuestra profesión o puesto al que apuntamos en el CV!";
        incorrectTextToRender[5] = "5: Por cierto, en este CV hay foto pero podes elegir tenerla como no. Continuemos.";
        // Presentation:
        incorrectTextToRender[8] = "8: Quizás podamos modificar un poco este perfil profesional. Veamos...";
        incorrectTextToRender[9] = "9: Reflexionar sobre cuál es tu misión, visión y valores para transmitirlos en esta sección.";
        incorrectTextToRender[10] = "10: Qué te parece este perfil ahora? Continuemos.";
        // ::Experience
        incorrectTextToRender[13] = "13: Ojo. Qué te pareció raro de esta sección?";
        incorrectTextToRender[14] = "14: Cuando no tengamos experiencia un buen porfolio es clave para mostrar nuestras capacidades.";
        incorrectTextToRender[15] = "15: Siempre asegurase que funcionen nuestros links y de tener unos buenos ejemplos para mostrar!";
        // Education:
        incorrectTextToRender[18] = "18: Cuidado acá! A esta información le faltan algunos detalles. Miremos. ";
        incorrectTextToRender[19] = "19: Es importante agregar las fechas y el estado de nuestros estudios!";
        incorrectTextToRender[20] = "20: Ya lo sabemos para la próxima! Sigamos.";
        // Abilities:
        incorrectTextToRender[23] = "23: Ojo! Acá está pasando algo!";
        incorrectTextToRender[24] = "24: Nos está faltando marcar de manera clara las habilidades.";
        incorrectTextToRender[25] = "25: Es un detalle pero mientras mas claro seamos mejor! Ya estamos terminando...";
        // Lenguage:
        incorrectTextToRender[28] = "28: Ojo! Saber idiomas es clave, pero qué nivel tenemos?";
        incorrectTextToRender[29] = "29: Siempre agreguemos el nivel y el instituto si es que fuimos a uno!";
        incorrectTextToRender[30] = "30: Esto siempre va a ayudar a reforzar nuestras postulaciones sin dudas.";
        // Contact:
        incorrectTextToRender[33] = "28: Perfecto, esta información de contacto está correcta.";
        incorrectTextToRender[34] = "29: Es concreta y contiene lo necesario.";
        incorrectTextToRender[35] = "30: Siempre es muy importante revistar que no haya ninguna falta y esté actualizada.";
    }


}

