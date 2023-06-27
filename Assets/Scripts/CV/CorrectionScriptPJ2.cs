using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//read - animate - next - buildUp - awnser - correction - settle - finalSecctionText
public class CorrectionScriptPJ2 : MonoBehaviour
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
        //
        pageTexts = new string[7];   
        pageTexts[0] = "PERFIL LABORAL";
        pageTexts[1] = "EDUCACIÓN Y FORMACIÓN";
        pageTexts[2] = "EXPERIENCIA";
        pageTexts[3] = "CURSOS";
        pageTexts[4] = "HABILIDADES";
        pageTexts[5] = "IDIOMAS";
        pageTexts[6] = "CONTACTO";
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
        textToRender[0] = "Muy bien, corrijamos el CV. Empecemos por el perfil...";
        textToRender[1] = "Muy bien, corrijamos el CV. Empecemos por el perfil...";
        textToRender[2] = "Veamos...";    
        textToRender[3] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[4] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[5] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[6] = "Revisemos la formación...";
        // Education:
        textToRender[7] = "A ver que pasa acá...";
        textToRender[8] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[9] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[10] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[11] = "Miremos la experiencia...";
        // Experience:
        textToRender[12] = "A ver...";
        textToRender[13] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[14] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[15] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[16] = "Y a ver esos cursos...";
        // Ad Ed:
        textToRender[17] = "Veamos...";
        textToRender[18] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[19] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[20] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[21] = "Miremos las habilidades y conocimientos...";
        // Abilities:
        textToRender[22] = "A ver...";
        textToRender[23] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[24] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[25] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[26] = "Veamos los idiomas...";
        // Lenguages:
        textToRender[27] = "Veamos...";
        textToRender[28] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[29] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[30] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[31] = "Y por último la información de contacto..";
        // Lenguages:
        textToRender[32] = "A ver que pasa acá...";
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
        // Perfil:
        correctTextToRender[3] = "¡Bien! Te diste cuenta que este perfil no nos está diciendo mucho, ¿no?";
        correctTextToRender[4] = "El perfil nos da la oportunidad de poder presentar quién somos, qué buscamos y qué podemos aportar.";
        correctTextToRender[5] = "¡Genial! Ahora es mucho más concreto. ¡Tenemos que enfocarnos en contar de que somos capaces!";
        // Formación académica:
        correctTextToRender[8]  = "¡Bien! Los estudios están correctos pero no especifican fechas.";
        correctTextToRender[9]  = "Omitir fechas o no tener precisiones puede ser un error común.";
        correctTextToRender[10] = "Es importante que no se nos olvide esto. A ver qué sigue...";
        // Voluntariado:
        correctTextToRender[13] = "Seguro que dentro de esas responsabilidades puede haber mas detalle, ¿no?";
        correctTextToRender[14] = "Mirá la cantidad de capacidades que involucran estas actividades y el que cambio hacen.";
        correctTextToRender[15] = "¡Estas experiencias pueden tener relación directa con un aviso al que deseamos postularnos!";
        // Cursos adicionales:
        correctTextToRender[18] = "¡Bien! Digámosle SÍ a los cursos adicionales y NO a las faltas ortográficas.";
        correctTextToRender[19] = "Hay que estar atento a estas cosas.";
        correctTextToRender[20] = "Continuemos.";
        // Habilidades y competencias:
        correctTextToRender[23] = "¡Muy bien! Acá está pasando algo, ¿no?";
        correctTextToRender[24] = "Las habilidades deben estar detalladas y presentadas de manera clara.";
        correctTextToRender[25] = "¡Es un detalle pero mientras más claros seamos mejor! Ya estamos terminando...";
        // Idiomas:
        correctTextToRender[28] = "Saber idiomas es clave, ¿pero qué nivel tenemos?";
        correctTextToRender[29] = "Siempre agreguemos el nivel y el instituto si es que fuimos a uno.";
        correctTextToRender[30] = "Esto siempre va a ayudar a reforzar nuestras postulaciones.";
        // Contacto:
        correctTextToRender[33] = "¡Perfecto! Esta información está correcta.";
        correctTextToRender[34] = "Es concreta y contiene lo necesario.";
        correctTextToRender[35] = "Es muy importante revistar que no falte nada importante y que esté actualizada.";


        // Wrongly awnsered by player:
        incorrectTextToRender = new string[100];
        // Perfil:
        incorrectTextToRender[3] = "¡Cuidado! Este perfil no nos está diciendo mucho.";
        incorrectTextToRender[4] = "El perfil nos da la oportunidad de poder presentar quién somos, qué buscamos y qué podemos aportar.";
        incorrectTextToRender[5] = "Fijate ahora. ¡Muchísimo mas concreto! Tenemos que enfocarnos en lo que somos capaces.";
        // Formación académica:
        incorrectTextToRender[8]  = "¡Ojo! Fijate bien, ¿no te parece que falta algo?";
        incorrectTextToRender[9]  = "Omitir fechas o no tener precisiones puede ser un error común.";
        incorrectTextToRender[10] = "¡Estemos atentos con esto para la próxima! A ver que sigue...";
        // Voluntariado:
        incorrectTextToRender[13] = "Seguramente esas tareas conlleven mas detalles del que dicen.";
        incorrectTextToRender[14] = "Mirá la cantidad de capacidades que involucran estas actividades y el que cambio hacen.";
        incorrectTextToRender[15] = "Estas experiencias pueden tener relación directa con un aviso al que deseamos postularnos. ¡Muy clave esto!";
        // Cursos adicionales:
        incorrectTextToRender[18] = "¡Cuidado! Digámosle SÍ a los cursos adicionales y NO a las faltas ortográficas";
        incorrectTextToRender[19] = "Hay que estar atento a estas cosas.";
        incorrectTextToRender[20] = "Continuemos.";
        // Habilidades y competencias:
        incorrectTextToRender[23] = "¡Ojo! Acá está pasando algo.";
        incorrectTextToRender[24] = "Las habilidades deben estar detalladas y presentadas de manera clara.";
        incorrectTextToRender[25] = "Es un detalle pero mientras mas claro seamos mejor. Ya estamos terminando...";
        // Idiomas:
        incorrectTextToRender[28] = "¡Ojo! Saber idiomas es clave, ¿Pero qué nivel tenemos?";
        incorrectTextToRender[29] = "Siempre agreguemos el nivel y el instituto si es que fuimos a uno.";
        incorrectTextToRender[30] = "Es un detalle pero mientras más claro seamos, mejor. Ya estamos terminando...";
        // Contacto:
        incorrectTextToRender[33] = "¡Ojo! ¿Qué te pareció raro en esta sección?";
        incorrectTextToRender[34] = "Es concreta y contiene lo necesario.";
        incorrectTextToRender[35] = "Es muy importante revistar que no falte nada importante y que esté actualizada.";
    }


}
