using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//read - animate - next - buildUp - awnser - correction - settle
public class CorrectionsTexts : MonoBehaviour
{
    [HideInInspector] public string[] textToRender;
    [HideInInspector] public string[] correctTextToRender;
    [HideInInspector] public string[] incorrectTextToRender;
    // [HideInInspector] public string[] markedAsIncorrectTextToRender;
    [HideInInspector] public string[] step;

    [HideInInspector] public RectTransform [] CvSectionsPos;
    [HideInInspector] public Section [] CvSectionsGO;
    // The cv
    GameObject Cv;
    // Start is called before the first frame update
    void Start()
    {
        CvSectionsGO = new Section[7];
        Cv = gameObject.transform.Find("CV").gameObject;
        CvSectionsGO[0] = Cv.transform.Find("Photo").gameObject.GetComponent<Section>();
        CvSectionsGO[1] = Cv.transform.Find("Name").gameObject.GetComponent<Section>();
        CvSectionsGO[2] = Cv.transform.Find("Abilities").gameObject.GetComponent<Section>();
        CvSectionsGO[3] = Cv.transform.Find("Presentation").gameObject.GetComponent<Section>();
        CvSectionsGO[4] = Cv.transform.Find("Education").gameObject.GetComponent<Section>();
        CvSectionsGO[5] = Cv.transform.Find("Experience").gameObject.GetComponent<Section>();
        CvSectionsGO[6] = Cv.transform.Find("Contact").gameObject.GetComponent<Section>();
        // 
        CvSectionsPos = new RectTransform[7];        
        Cv = gameObject.transform.Find("CV").gameObject;
        CvSectionsPos[0] = Cv.transform.Find("Photo").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[1] = Cv.transform.Find("Name").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[2] = Cv.transform.Find("Abilities").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[3] = Cv.transform.Find("Presentation").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[4] = Cv.transform.Find("Education").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[5] = Cv.transform.Find("Experience").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[6] = Cv.transform.Find("Contact").gameObject.GetComponent<RectTransform>();
        // Normal text:
        step = new string[]{"read", "animate", "read", "buildUp", "awnser", "correction", "settle"};

        textToRender = new string[100];
        textToRender[0] = "0: Muy bien, corrijamos el cv. Empecemos por la foto.";
        textToRender[1] = "1: Muy bien, corrijamos el cv. Empecemos por la foto.";
        textToRender[2] = "2: Veamos..";
        textToRender[3] = "3: La foto está...";
        textToRender[4] = "4: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[5] = "5: CORRECT OR INCORRECT TEXT HERE, NOT MENT TO BE READ.";
        textToRender[6] = "6: ALGO MAS SOBRE LAS FOTOS.";

        // Correct text:
        correctTextToRender = new string[100];
        correctTextToRender[4] = "4: ¡La foto está muy borrosa! Muy bien por darte cuenta.";
        correctTextToRender[5] = "5: Es muy importante que en nuestra foto siempre se nos pueda ver bien.";

        // Not marked as Incorrect text:
        incorrectTextToRender = new string[100];
        incorrectTextToRender[4] = "4: ¡Cuidado! La foto está muy borrosa y no la marcaste!";
        incorrectTextToRender[5] = "5: Recorá, es muy importante que en nuestra foto siempre se nos pueda ver bien.";




        // // Marked as Incorrect text:
        // markedAsIncorrectTextToRender = new string[100];
        // markedAsIncorrectTextToRender[4] = "4: ¡Cuidado! La foto está muy borrosa y no la marcaste!";
        // markedAsIncorrectTextToRender[5] = "5: Recorá, es muy importante que en nuestra foto siempre se nos pueda ver bien.";
    }


}
