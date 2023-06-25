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
        CvSectionsGO[0] = Cv.transform.Find("Presentation").gameObject.GetComponent<Section>();
        CvSectionsGO[1] = Cv.transform.Find("Education").gameObject.GetComponent<Section>();
        CvSectionsGO[2] = Cv.transform.Find("Experience").gameObject.GetComponent<Section>();
        CvSectionsGO[3] = Cv.transform.Find("Name").gameObject.GetComponent<Section>();
        CvSectionsGO[4] = Cv.transform.Find("Abilities").gameObject.GetComponent<Section>();
        CvSectionsGO[5] = Cv.transform.Find("Lenguage").gameObject.GetComponent<Section>();
        CvSectionsGO[6] = Cv.transform.Find("Contact").gameObject.GetComponent<Section>();
        // 
        CvSectionsPos = new RectTransform[7];        
        
        CvSectionsPos[0] = Cv.transform.Find("Presentation").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[1] = Cv.transform.Find("Education").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[2] = Cv.transform.Find("Experience").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[3] = Cv.transform.Find("Name").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[4] = Cv.transform.Find("Abilities").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[5] = Cv.transform.Find("Lenguage").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[6] = Cv.transform.Find("Contact").gameObject.GetComponent<RectTransform>();
        //
        SectionOffset = new Transform[7];        
        SectionOffset[0] = Cv.transform.Find("Presentation").Find("Offset").GetComponent<Transform>(); 
        SectionOffset[1] = Cv.transform.Find("Education").Find("Offset").GetComponent<Transform>();
        SectionOffset[2] = Cv.transform.Find("Experience").Find("Offset").GetComponent<Transform>();
        SectionOffset[3] = Cv.transform.Find("Name").transform.Find("Offset").GetComponent<Transform>();
        SectionOffset[4] = Cv.transform.Find("Abilities").Find("Offset").GetComponent<Transform>();
        SectionOffset[5] = Cv.transform.Find("Lenguage").Find("Offset").GetComponent<Transform>();
        SectionOffset[6] = Cv.transform.Find("Contact").Find("Offset").GetComponent<Transform>();
        //Debug.Log(SectionOffset[4]);
        // Normal text:
        step = new string[]{
        "read", "animate", "buildUp", "awnser", "correction", "settle", "next", // Presentation
        "buildUp", "awnser", "correction", "settle", "next", // Education
        "buildUp", "awnser", "correction", "settle", "next", // Experience
        "buildUp", "awnser", "correction", "settle", "next", // AditionalEd
        "buildUp", "awnser", "correction", "settle", "next", // Abilities
        "buildUp", "awnser", "correction", "settle", "next", // Lenguage
        "buildUp", "awnser", "correction", "settle", // Contact
        "endZoom","read","read","read","read","read",
        "cueEndScene","cueEndScene","cueEndScene","cueEndScene","cueEndScene",
        };

        textToRender = new string[100];
        // Presentation:
        textToRender[0] = "0: Muy bien, corrijamos el cv. Empecemos por el perfil.";
        textToRender[1] = "1: Muy bien, corrijamos el cv. Empecemos por el perfil.";
        textToRender[2] = "2: Veamos...";    
        textToRender[3] = "3: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[4] = "4: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[5] = "5: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[6] = "6: Revisemos la formación.";
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
        textToRender[16] = "16: Y a ver esos cursos...";
        // Ad Ed:
        textToRender[17] = "17: Veamos...";
        textToRender[18] = "18: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[19] = "19: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[20] = "20: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[21] = "21: Miremos las habilidades y conocimientos.";
        // Abilities:
        textToRender[22] = "22: A ver...";
        textToRender[23] = "23: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[24] = "24: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[25] = "25: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[26] = "26: Veamos los idiomas.";
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
        // Photo + Name:
        correctTextToRender[3] = "3: Bien! Te diste cuenta que este perfil no nos está diciendo mucho, no?";
        correctTextToRender[4] = "4: El perfil nos la oportunidad de poder presentar quién somos, qué buscamos y qué podemos aportar.";
        correctTextToRender[5] = "5: Muchísimo mas concreto ahora este perfil. A enfocarse en lo que somos capaces!";
        // Presentation:
        correctTextToRender[8] = "8: Bien! Los estudios están bien pero sin fechas.";
        correctTextToRender[9] = "9: Omitir fechas o no tener precisiones puede ser un error común mientras hacemos un cv.";
        correctTextToRender[10] = "10: Es importante que no se nos olvide esto! A ver que sigue..";
        // Education:
        correctTextToRender[13] = "13: Seguro que dentro de esas responsabilidades haya mas detalles, no?";
        correctTextToRender[14] = "14: Mirá la cantidad de capacidades que involucran estas actividades y que cambio hace.";
        correctTextToRender[15] = "15: Estas experiencias pueden tener relación directa con un aviso al que deseamos postularnos! Muy clave esto!";
        // Experience:
        correctTextToRender[18] = "18: Bien! Dígale SÍ a los cursos adicionales y NO a las faltas ortográficas!";
        correctTextToRender[19] = "19: Muy importante estar atento a estas cosas.";
        correctTextToRender[20] = "20: Genial! Continuemos con el CV.";
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
        // Photo + Name:
        incorrectTextToRender[3] = "3: ¡Cuidado! Quizás no te parezca pero  este perfil no nos está diciendo mucho.";
        incorrectTextToRender[4] = "4: El perfil nos la oportunidad de poder presentar quien somos, que buscamos y que podemos aportar.";
        incorrectTextToRender[5] = "5: Fijate ahora qué tal. Muchísimo mas concreto este perfil. A enfocarse en lo que somos capaces!";
        // Presentation:
        incorrectTextToRender[8] = "8: Ojo! Fijate bien, no te parece que falta algo?";
        incorrectTextToRender[9] = "9: Omitir fechas o no tener precisiones puede ser un error común mientras hacemos un cv.";
        incorrectTextToRender[10] = "10: Estemos atentos con esto para la próxima! A ver que sigue..";
        // Education:
        incorrectTextToRender[13] = "13: Mirá las responsabilidades, seguramente esas tareas conlleven mas detalles del que dicen..";
        incorrectTextToRender[14] = "14: Mirá la cantidad de capacidades que involucran estas actividades y que cambio hace.";
        incorrectTextToRender[15] = "15: Estas experiencias pueden tener relación directa con un aviso al que deseamos postularnos! Muy clave esto!";
        // Experience:
        incorrectTextToRender[18] = "18: Cuidado! Dígale SÍ a los cursos adicionales y NO a las faltas ortográficas!";
        incorrectTextToRender[19] = "19: Muy importante estar atento a estas cosas. Mirá la corrección en el CV!";
        incorrectTextToRender[20] = "20: A no olvidar buscar por este tipo de fallas cuando armamos el CV! Sigamos.";
        // Abilities:
        incorrectTextToRender[23] = "23: Ojo! Acá está pasando algo!";
        incorrectTextToRender[24] = "24: Recordá! Las habilidades deben estar detalladas y de manera clara.";
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

