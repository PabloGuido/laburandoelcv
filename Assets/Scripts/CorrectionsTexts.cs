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
        textToRender[0] = "0: Muy bien, corrijamos el cv. Empecemos por los datos personales.";
        textToRender[1] = "1: Muy bien, corrijamos el cv. Empecemos por los datos personales.";
        textToRender[2] = "2: Veamos...";    
        textToRender[3] = "3: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[4] = "4: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[5] = "5: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[6] = "6: Revisemos el resúmen.";
        // Presentation:
        textToRender[7] = "7: A ver que pasa acá...";
        textToRender[8] = "8:CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[9] = "9: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[10] = "10: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[11] = "11: Miremos la formación.";
        // Education:
        textToRender[12] = "12: A ver...";
        textToRender[13] = "13:CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[14] = "14: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[15] = "15: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[16] = "16: Revisemos la experiencia.";
        // Experience:
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
        textToRender[26] = "26: Terminemos con la info de contacto.";
        // Contact:
        textToRender[27] = "27: Esta info de contacto está...";
        textToRender[28] = "28: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[29] = "29: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[30] = "30: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[31] = "31: Y con esto vimos todo el CV!";
        // End game:
        textToRender[32] = "32: Dale una última leída y fijate como quedó.";
        textToRender[33] = "33: Recordá siempre revisar muy bien tu CV.";
        textToRender[34] = "34: Pedí a tus conocidos y amuigos que lo revisen y te den una devolución sobre el mismo también.";
        textToRender[35] = "35: Otro par de ojos nunca está de mas!";
        textToRender[36] = "36: Con esto llegamos al final. Espero que alguno de estos consejos te puedan servir :D";
        textToRender[37] = "37: Gracias por jugar!";
        textToRender[38] = "38: Desarrollador por:\nPablo Sonaglioni \n @pgs1000";
        textToRender[39] = "39: @emmyta";
        textToRender[40] = "41: Especial gracias para Lorena Escobedo";

        // Correct awnsered by player text:
        correctTextToRender = new string[100];
        // Photo + Name:
        correctTextToRender[3] = "3: ¡La foto está muy borrosa! Muy bien por darte cuenta.";
        correctTextToRender[4] = "4: Si decidimos poner una foto es muy importante que siempre se nos pueda ver bien.";
        correctTextToRender[5] = "5: Recordá, no hay oblicación de poner una foto. Vamos con lo siguiente.";
        // Presentation:
        correctTextToRender[8] = "8: Muy bien! Notaste que este CV tiene información que no es relevante para el puesto solicitado.";
        correctTextToRender[9] = "9: Reemplacemos el error por datos acordes al CV.";
        correctTextToRender[10] = "10: Muy bien! Veamos que sigue..";
        // Education:
        correctTextToRender[13] = "13: Como que falta algo, no? A esta información no le vendría mal un poco mas de detalle.";
        correctTextToRender[14] = "14: Es importante especificar el período, establecimiento y título obtenido en nuestra formación.";
        correctTextToRender[15] = "15: Genial, continuemos.";
        // Experience:
        correctTextToRender[18] = "18: Había algo raro, no? Quizás haya algo mas significativo para poner en los logros.";
        correctTextToRender[19] = "19: Mostrar nuestros logros mas concretos puede ser clave a la hora de conseguir un puesto.";
        correctTextToRender[20] = "20: Recorá que esto es super imporante!";
        // Abilities:
        correctTextToRender[23] = "23: Las habilidades técnicas muy bien. Pero los idiomas qué nivel tenemos?";
        correctTextToRender[24] = "24: Siempre agreguemos el nivel y el instituto si es que fuimos a uno!";
        correctTextToRender[25] = "25: Esto siempre va a ayudar a reforzar nuestras postulaciones sin dudas.";
        // Contact:
        correctTextToRender[28] = "28: Perfecto, esta información de contacto está correcta.";
        correctTextToRender[29] = "29: Es concreta y contiene lo necesario.";
        correctTextToRender[30] = "30: Siempre es muy importante revistar que no haya ninguna falta y que esté actualizada.";


        // Wrongly awnsered by player:
        incorrectTextToRender = new string[100];
        // Photo + Name:
        incorrectTextToRender[3] = "3: ¡Cuidado! La foto está muy borrosa y no la marcaste!";
        incorrectTextToRender[4] = "4: Si decidimos poner una foto es muy importante que siempre se nos pueda ver bien.";
        incorrectTextToRender[5] = "5: Recordá, no hay oblicación de poner una foto. Vamos con lo siguiente.";
        // Presentation:
        incorrectTextToRender[8] = "8: ¡Cuidado! ¡La ciencia ficción y el karate son grandes interes pero no relvantes para nuestro curriculum!";
        incorrectTextToRender[9] = "9: Recordá que la información en el CV tiene que corresponder al puesto solicitado.";
        incorrectTextToRender[10] = "10: Muy bien. ¡Estemos atentos con esto para la próxima! Sigamos..";
        // Education:
        incorrectTextToRender[13] = "13: ¡Ojo acá! Esta información necesita ser mas específica!";
        incorrectTextToRender[14] = "14: Recordá detallar el período, establecimiento y título obtenido en nuestra formación.";
        incorrectTextToRender[15] = "15: Ya lo sabés para la próxima! Vamos con lo siguiente.";
        // Experience:
        incorrectTextToRender[18] = "18: ¡Cuidado! Fijate en los logros, quizás haya algo mas significativo para poner.";
        incorrectTextToRender[19] = "19: Mostrar nuestros logros mas concretos puede ser clave a la hora de conseguir un puesto.";
        incorrectTextToRender[20] = "20: Recorá que esto es super imporante!";
        // Abilities:
        incorrectTextToRender[23] = "23: Ojo! Las habilidades técnicas muy bien. Pero los idiomas qué nivel tenemos?";
        incorrectTextToRender[24] = "24: Siempre agreguemos el nivel y el instituto si es que fuimos a uno!";
        incorrectTextToRender[25] = "25: Esto siempre va a ayudar a reforzar nuestras postulaciones sin dudas.";
        // Contact:
        incorrectTextToRender[28] = "28: Ojo. Qué te pareció raro de esta sección?";
        incorrectTextToRender[29] = "29: La información de contacto no necesita ser extensa.";
        incorrectTextToRender[30] = "30: Pero es muy importante revistar que no haya ninguna falta y que esté actualizada.";

    }


}
