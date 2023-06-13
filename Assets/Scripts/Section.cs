using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Section : MonoBehaviour
{
    public bool isIncorrect; // Checks if this section have error to be marked.
    [HideInInspector] public bool markedAsIncorrect;
    //
    private Button thisSection;
    private ColorBlock initialColors; // This var keeps the original colors of the button, not ment to be change ever.
    // Childs
    GameObject correctOption;
    GameObject incorrectOption;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the button/section:
        thisSection = gameObject.GetComponent<Button>();
        // Gets the childs:
        correctOption = gameObject.transform.Find("Correct Option").gameObject;
        incorrectOption = gameObject.transform.Find("Incorrect Option").gameObject;
        // Sets the initial colors of buttons we will need. This is used to restore a section that have been clicked:
        initialColors = thisSection.colors;     
        initialColors.pressedColor  = Color.red; 
        thisSection.colors = initialColors;
        // Check if this section is correct or not.
        disableOneOfTheOptions();
        // Add the method on click
        thisSection.onClick.AddListener(taskOnClick);
        
    }

    private void disableOneOfTheOptions(){
        if (isIncorrect){
            correctOption.SetActive(false);
        }
        else {
            incorrectOption.SetActive(false);
        }
    }

    private void taskOnClick(){
        if (UiManager.Instance.playerInputAllowed){
            if (!markedAsIncorrect){
                sectionMarkedAsIncorrect(true);
                
            }
            else {
                sectionMarkedAsIncorrect(false);
                
            }
            //Debug.Log(thisSection + " : " + markedAsIncorrect);
        }
    }

    void sectionMarkedAsIncorrect(bool trueOrNot){
        markedAsIncorrect = trueOrNot;
        if (trueOrNot){
            markedSectionChangeColor();
        }
        else {
            restoreSectionColor();
        }
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

}
