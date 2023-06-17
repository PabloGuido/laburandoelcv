using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//read - animate - next - buildUp - awnser - correction - settle
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
        CvZoom = new float[]{1.15f,1.75f,2f,1.75f,1.75f,1.75f,2f};
        //
        CvSectionsGO = new Section[6];
        Cv = gameObject.transform.Find("CV").gameObject;

        CvSectionsGO[0] = Cv.transform.Find("Name").gameObject.GetComponent<Section>();
        CvSectionsGO[1] = Cv.transform.Find("Abilities").gameObject.GetComponent<Section>();
        CvSectionsGO[2] = Cv.transform.Find("Presentation").gameObject.GetComponent<Section>();
        CvSectionsGO[3] = Cv.transform.Find("Education").gameObject.GetComponent<Section>();
        CvSectionsGO[4] = Cv.transform.Find("Experience").gameObject.GetComponent<Section>();
        CvSectionsGO[5] = Cv.transform.Find("Contact").gameObject.GetComponent<Section>();
        // 
        CvSectionsPos = new RectTransform[6];        
        Cv = gameObject.transform.Find("CV").gameObject;
        
        CvSectionsPos[0] = Cv.transform.Find("Name").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[1] = Cv.transform.Find("Abilities").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[2] = Cv.transform.Find("Presentation").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[3] = Cv.transform.Find("Education").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[4] = Cv.transform.Find("Experience").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[5] = Cv.transform.Find("Contact").gameObject.GetComponent<RectTransform>();
        // Normal text:
        step = new string[]{
        "read", "animate", "buildUp", "awnser", "correction", "settle", "next", // Photo + Name
        "buildUp", "awnser", "correction", "settle", "next",
        
        };

        textToRender = new string[100];
        // Photo + Name:
        textToRender[0] = "0: Muy bien, corrijamos el cv. Empecemos por los datos personales.";
        textToRender[1] = "1: Muy bien, corrijamos el cv. Empecemos por los datos personales.";
        textToRender[2] = "2: Veamos...";    
        textToRender[3] = "3: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[4] = "4: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[5] = "5: Recordá, no hay oblicación de poner una foto. Vamos con lo siguiente.";
        textToRender[6] = "6: REVISEMOS EL NOMBRE.";
        // Name:
        textToRender[7] = "7: El nombre esta...";
        textToRender[8] = "8:CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[9] = "9: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[10] = "10: ALGO MAS SOBRE EL NOMBRE. Vamos al siguiente";
        textToRender[11] = "11: Yendo hacia habilidades.";


        // Correct text:
        correctTextToRender = new string[100];
        //Photo:
        correctTextToRender[3] = "3: ¡La foto está muy borrosa! Muy bien por darte cuenta.";
        correctTextToRender[4] = "4: Si decidimos poner una foto es muy importante que siempre se nos pueda ver bien.";
        // Name:
        correctTextToRender[8] = "8: El nombre está muy bien!.";
        correctTextToRender[9] = "9: Por estos motivos.";


        // Not marked as Incorrect text:
        incorrectTextToRender = new string[100];
        //Photo:
        incorrectTextToRender[3] = "3: ¡Cuidado! La foto está muy borrosa y no la marcaste!";
        incorrectTextToRender[4] = "4: Si decidimos poner una foto es muy importante que siempre se nos pueda ver bien.";
        // Name:
        incorrectTextToRender[8] = "8: Cuidado! El nombre está bien y lo marcaste como incorrecto.";
        incorrectTextToRender[9] = "9: Por estos motivos. 222";


    }


}
