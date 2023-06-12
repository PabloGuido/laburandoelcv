using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Section : MonoBehaviour
{
    public bool isIncorrect;
    [HideInInspector] public bool markedAsIncorrect;
    //
    private Button thisSection;
    private ColorBlock initialColors; // This var keeps the original colors of the button, not ment to be change ever.
    // Start is called before the first frame update
    void Start()
    {
        thisSection = gameObject.GetComponent<Button>(); // Gets the button/section
        initialColors = thisSection.colors;        
        
        
        initialColors.pressedColor  = Color.red; 
        
        thisSection.colors = initialColors;
        //

        thisSection.onClick.AddListener(taskOnClick);

    }

    private void taskOnClick(){
        if (!markedAsIncorrect){
            sectionMarkedAsIncorrect(true);
            markedSectionChangeColor();
        }
        else {
            sectionMarkedAsIncorrect(false);
            restoreSectionColor();
        }
        Debug.Log(thisSection + " : " + markedAsIncorrect);
    }

    void sectionMarkedAsIncorrect(bool trueOrNot){
        markedAsIncorrect = trueOrNot;
    }

    void markedSectionChangeColor(){
        ColorBlock cb = thisSection.colors;
        cb.normalColor = Color.red;
        cb.selectedColor = Color.red;
        cb.highlightedColor = Color.red;
        
        thisSection.colors = cb;
    }

    void restoreSectionColor(){
        thisSection.colors = initialColors;
    }
    

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
