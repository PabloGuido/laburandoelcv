using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//read - animate - next - buildUp - awnser - correction - settle - finalSecctionText
public class CorrectionsTexts : MonoBehaviour
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
        CvSectionsGO = new Section[6];
        Cv = mask.transform.Find("CV").gameObject;

        CvSectionsGO[0] = Cv.transform.Find("Name").gameObject.GetComponent<Section>();
        CvSectionsGO[1] = Cv.transform.Find("Presentation").gameObject.GetComponent<Section>();
        CvSectionsGO[2] = Cv.transform.Find("Education").gameObject.GetComponent<Section>();
        CvSectionsGO[3] = Cv.transform.Find("Experience").gameObject.GetComponent<Section>();
        CvSectionsGO[4] = Cv.transform.Find("Abilities").gameObject.GetComponent<Section>();
        CvSectionsGO[5] = Cv.transform.Find("Contact").gameObject.GetComponent<Section>();
        // 
        CvSectionsPos = new RectTransform[6];        
        
        
        CvSectionsPos[0] = Cv.transform.Find("Name").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[1] = Cv.transform.Find("Presentation").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[2] = Cv.transform.Find("Education").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[3] = Cv.transform.Find("Experience").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[4] = Cv.transform.Find("Abilities").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[5] = Cv.transform.Find("Contact").gameObject.GetComponent<RectTransform>();
        //
        SectionOffset = new Transform[6];        
                
        SectionOffset[0] = Cv.transform.Find("Name").transform.Find("Offset").GetComponent<Transform>();
        SectionOffset[1] = Cv.transform.Find("Presentation").Find("Offset").GetComponent<Transform>();
        SectionOffset[2] = Cv.transform.Find("Education").Find("Offset").GetComponent<Transform>();
        SectionOffset[3] = Cv.transform.Find("Experience").Find("Offset").GetComponent<Transform>();
        SectionOffset[4] = Cv.transform.Find("Abilities").Find("Offset").GetComponent<Transform>();
        SectionOffset[5] = Cv.transform.Find("Contact").Find("Offset").GetComponent<Transform>();
        //Debug.Log(SectionOffset[4]);
        //
        pageTexts = new string[6];   
        pageTexts[0] = "FOTO DE PERFIL";
        pageTexts[1] = "RESUMEN LABORAL";
        pageTexts[2] = "EDUCACIÓN Y FORMACIÓN";
        pageTexts[3] = "EXPERIENCIA";
        pageTexts[4] = "HABILIDADES";
        pageTexts[5] = "CONTACTO";
        
        // Normal text:
        step = new string[]{
        "read", "animate", "buildUp", "awnser", "correction", "settle", "next", // Photo + Name
        "buildUp", "awnser", "correction", "settle", "next", // Presentation
        "buildUp", "awnser", "correction", "settle", "next", // Education
        "buildUp", "awnser", "correction", "settle", "next", // Experience
        "buildUp", "awnser", "correction", "settle", "next", // Abilities
        "buildUp", "awnser", "correction", "settle", // Contact
        "endZoom","read","read","read","read","read",
        "cueEndScene","cueEndScene","cueEndScene","cueEndScene","cueEndScene",
        };

        textToRender = new string[100];
        // Photo + Name:
        textToRender[0] = "Muy bien, corrijamos el CV. Empecemos por la foto...";
        textToRender[1] = "Muy bien, corrijamos el CV. Empecemos por la foto...";
        textToRender[2] = "Veamos...";    
        textToRender[3] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[4] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[5] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[6] = "Revisemos el resumen...";
        // Presentation:
        textToRender[7]  = "A ver que pasa acá...";
        textToRender[8]  = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[9]  = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[10] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[11] = "Miremos la formación...";
        // Education:
        textToRender[12] = "A ver...";
        textToRender[13] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[14] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[15] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[16] = "Revisemos la experiencia...";
        // Experience:
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
        textToRender[26] = "Y por último la información de contacto...";
        // Contact:
        textToRender[27] = "Esta información de contacto está...";
        textToRender[28] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[29] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[30] = "CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[31] = "¡Terminamos, revisamos todo el CV!";
        // End game:
        textToRender[32] = "Démosle una última leída y fijémonos cómo quedó.";
        textToRender[33] = "Recordá siempre revisar muy bien tu CV.";
        textToRender[34] = "Te recomendamos pedirle a amigos o conocidos que también lo vean y te den una devolución.";
        textToRender[35] = "¡Otro par de ojos nunca están de más!";
        textToRender[36] = "Con esto llegamos al final. ¡Esperamos que te sirvan alguno de estos consejos! :D";
        textToRender[37] = "— GRACIAS POR JUGAR —";
        textToRender[38] = "Desarrollo:\nPablo Sonaglioni \n @pgs1000";
        textToRender[39] = "Diseño gráfico:\nEmmanuel Schönfeld Estani \n @_emmyta";
        textToRender[40] = "Agradecimientos especiales \n Lorena Escobedo";

        // Correct awnsered by player text:
        correctTextToRender = new string[100];
        // Photo + Name:
        correctTextToRender[3] = "¡La foto está muy borrosa! Muy bien por darte cuenta.";
        correctTextToRender[4] = "Si decidimos poner una foto es muy importante que siempre se nos pueda ver bien.";
        correctTextToRender[5] = "Recordá, no hay obligación de poner foto. Vamos con lo siguiente.";
        // Presentation:
        correctTextToRender[8] = "¡Muy bien! Notaste que este CV tiene información que no es relevante para el puesto solicitado.";
        correctTextToRender[9] = "Reemplacemos el error por datos acordes al CV.";
        correctTextToRender[10] = "Veamos que sigue.";
        // Education:
        correctTextToRender[13] = "¡Muy bien! A esta información le faltan algunos detalles.";
        correctTextToRender[14] = "Es importante especificar el período, establecimiento y título obtenido en nuestra formación.";
        correctTextToRender[15] = "Continuemos.";
        // Experience:
        correctTextToRender[18] = "¿Hay algo raro, no? Quizás haya algo mas significativo para poner en los logros.";
        correctTextToRender[19] = "Mostrar nuestros logros mas concretos puede ser clave a la hora de conseguir un puesto.";
        correctTextToRender[20] = "Esto es super imporante.";
        // Abilities:
        correctTextToRender[23] = "Las habilidades técnicas están correctas, pero los idiomas...";
        correctTextToRender[24] = "Es importante siempre agregar el nivel que tenemos de ellos.";
        correctTextToRender[25] = "¡Genial! Sigamos.";
        // Contact:
        correctTextToRender[28] = "¡Perfecto! Esta información está correcta.";
        correctTextToRender[29] = "Es concreta y contiene lo necesario.";
        correctTextToRender[30] = "Es muy importante revisar que no le falte nada importante y que esté actualizada.";


        // Wrongly awnsered by player:
        incorrectTextToRender = new string[100];
        // Photo + Name:
        incorrectTextToRender[3] = "¡Cuidado! La foto está muy borrosa.";
        incorrectTextToRender[4] = "Si decidimos poner una foto es muy importante que siempre se nos pueda ver bien.";
        incorrectTextToRender[5] = "Recordá, no hay obligación de poner foto. Vamos con lo siguiente.";
        // Presentation:
        incorrectTextToRender[8]  = "¡Cuidado! ¡La ciencia ficción y el karate son grandes interes pero no relvantes para nuestro curriculum!";
        incorrectTextToRender[9]  = "La información en el CV tiene que corresponder al puesto solicitado.";
        incorrectTextToRender[10] = "Muy bien. ¡Estemos atentos con esto para la próxima! Sigamos.";
        // Education:
        incorrectTextToRender[13] = "¡Ojo! Esta información necesita ser mas específica.";
        incorrectTextToRender[14] = "Es importante especificar el período, establecimiento y título obtenido en nuestra formación.";
        incorrectTextToRender[15] = "¡Ya lo sabés para la próxima! Vamos con lo siguiente.";
        // Experience:
        incorrectTextToRender[18] = "¡Cuidado! Fijémonos en los logros, quizás hay algo mas significativo para poner.";
        incorrectTextToRender[19] = "Mostrar nuestros logros mas concretos puede ser clave a la hora de conseguir un puesto.";
        incorrectTextToRender[20] = "¡Esto es super imporante!";
        // Abilities:
        incorrectTextToRender[23] = "¡Ojo! Las habilidades técnicas están correctas, pero los idiomas...";
        incorrectTextToRender[24] = "Es importante siempre agregar el nivel que tenemos de ellos.";
        incorrectTextToRender[25] = "Es un detalle pero ¡mientras más claro seamos, mejor! Ya estamos terminando...";
        // Contact:
        incorrectTextToRender[28] = "¡Perfecto! Esta información está correcta.";
        incorrectTextToRender[29] = "Es concreta y contiene lo necesario.";
        incorrectTextToRender[30] = "Es muy importante revisar que no le falte nada importante y que esté actualizada.";

    }


}