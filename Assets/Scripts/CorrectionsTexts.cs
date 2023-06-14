using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//read - animate - next
public class CorrectionsTexts : MonoBehaviour
{
    [HideInInspector] public string[] textToRender = new string[10];
    [HideInInspector] public RectTransform [] CvSectionsPos;
    [HideInInspector] public string[] step;

    // The cv
    GameObject Cv;
    // Start is called before the first frame update
    void Start()
    {
        step = new string[]{"read", "animate"};
        CvSectionsPos = new RectTransform[7];
        // 
        Cv = gameObject.transform.Find("CV").gameObject;
        CvSectionsPos[0] = Cv.transform.Find("Photo").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[1] = Cv.transform.Find("Name").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[2] = Cv.transform.Find("Abilities").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[3] = Cv.transform.Find("Presentation").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[4] = Cv.transform.Find("Education").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[5] = Cv.transform.Find("Experience").gameObject.GetComponent<RectTransform>();
        CvSectionsPos[6] = Cv.transform.Find("Contact").gameObject.GetComponent<RectTransform>();

        textToRender[0] = "Muy bien, corrijamos el cv. Empecemos por la foto.";

        
    }


}
