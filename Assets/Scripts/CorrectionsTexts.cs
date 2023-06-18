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
    [HideInInspector] public Section [] CvSectionsGO;
    // The cv
    GameObject Cv;
    // Start is called before the first frame update
    void Start()
    {
        // Zooms:
        CvZoom = new float[]{2f,1.75f,1.65f,1.65f,1.5f,1.75f,2f};
        //
        CvSectionsGO = new Section[6];
        Cv = gameObject.transform.Find("CV").gameObject;

        CvSectionsGO[0] = Cv.transform.Find("Name").gameObject.GetComponent<Section>();
        CvSectionsGO[1] = Cv.transform.Find("Presentation").gameObject.GetComponent<Section>();
        CvSectionsGO[2] = Cv.transform.Find("Education").gameObject.GetComponent<Section>();
        CvSectionsGO[3] = Cv.transform.Find("Experience").gameObject.GetComponent<Section>();
        CvSectionsGO[4] = Cv.transform.Find("Abilities").gameObject.GetComponent<Section>();
        CvSectionsGO[5] = Cv.transform.Find("Contact").gameObject.GetComponent<Section>();
        // 
        CvSectionsPos = new RectTransform[6];        
        Cv = gameObject.transform.Find("CV").gameObject;
        
        CvSectionsPos[0] = Cv.transform.Find("Name").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[1] = Cv.transform.Find("Presentation").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[2] = Cv.transform.Find("Education").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[3] = Cv.transform.Find("Experience").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[4] = Cv.transform.Find("Abilities").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[5] = Cv.transform.Find("Contact").gameObject.GetComponent<RectTransform>();
        // Normal text:
        step = new string[]{
        "read", "animate", "buildUp", "awnser", "correction", "settle", "next", // Photo + Name
        "buildUp", "awnser", "correction", "settle", "next", // Presentation
        "buildUp", "awnser", "correction", "settle", "next", // Education
        "buildUp", "awnser", "correction", "settle", "next", // Experience
        "buildUp", "awnser", "correction", "settle", "next", // Abilities
        "buildUp", "awnser", "correction", "settle", "next", // Contact
        
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
        textToRender[22] = "22: A ver que pasa acá...";
        textToRender[23] = "23: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[24] = "24: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[25] = "25: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[26] = "26: END THIS GAME.";

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
        correctTextToRender[23] = "23: Genial, para algunos puede parecer muy simple pero estas habiliades son correctas.";
        correctTextToRender[24] = "24: No siempre es necesario que te extiendas pero si que ellas sean acordes al puesto.";
        correctTextToRender[25] = "25: Igual, no olvides que esto varía de persona en persona! Sigamos.";
        // Contact:
        correctTextToRender[26] = "26: Perfecto, esta información de contacto está correcta.";
        correctTextToRender[27] = "27: s concreta y contiene lo necesario.";
        correctTextToRender[28] = "28: Siempre es muy importante revistar que no haya ninguna falta y esté actualizada.";


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
        incorrectTextToRender[23] = "23: Te pareció que había algo raro en esta sección?";
        incorrectTextToRender[24] = "24: No siempre es necesario que te extiendas en tus habilidades pero si que ellas sean acordes al puesto.";
        incorrectTextToRender[25] = "25: Igual, no olvides que esto varía de persona en persona! Sigamos.";
        // Contact:
        incorrectTextToRender[26] = "26: Ojo. Qué te pareció raro de esta sección?";
        incorrectTextToRender[27] = "27: La información de contacto no necesita ser extensa.";
        incorrectTextToRender[28] = "28: Pero es muy importante revistar que no haya ninguna falta y que esté actualizada.";

    }


}
