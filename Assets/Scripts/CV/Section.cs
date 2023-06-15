using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Section : MonoBehaviour
{
    public bool isIncorrect; // Checks if this section have error to be marked.
    [HideInInspector] public bool markedAsIncorrect;
    //
    private Button thisSection;
    private ColorBlock initialColors; // This var keeps the original colors of the button, not ment to be change ever.
    // Childs
    GameObject correctOption;
    Image correctImage;
    GameObject incorrectOption;
    GameObject border;
    RectTransform borderRT;
    // Icons
    GameObject iconWrong;
    GameObject iconRight;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the button/section:
        thisSection = gameObject.GetComponent<Button>();
        // Gets the childs:
        correctOption = gameObject.transform.Find("Correct Option").gameObject;
        correctImage = correctOption.transform.Find("Image").GetComponent<Image>();
        incorrectOption = gameObject.transform.Find("Incorrect Option").gameObject;
        // Gets the border and border RectTransform and sets it's size:
        border = gameObject.transform.Find("Border").gameObject;
        borderRT = gameObject.transform.Find("Border").GetComponent<RectTransform>();
        var imageSize = correctOption.transform.Find("Image").GetComponent<RectTransform>();
        borderRT.sizeDelta = new Vector2(imageSize.sizeDelta.x, imageSize.sizeDelta.y);
        border.SetActive(false);
        // Icons:
        iconWrong = border.transform.Find("IconWrong").gameObject;
        iconRight = border.transform.Find("IconRight").gameObject;
        deactivateIconsOnStart();
        
        /////// Methods to do at start: ///////
        // Check if this section is correct or not.
        disableOneOfTheOptions();
        // Add the method on click
        thisSection.onClick.AddListener(taskOnClick);
        
    }
    
    public void showCorrectImage(){
        correctOption.SetActive(true);
        Color alphaZero = new Color(1,1,1,0);
        correctImage.DOColor(alphaZero, 0);
        Color alphaOne = new Color(1,1,1,1);
        correctImage.DOColor(alphaOne, 1).SetLoops(-1, LoopType.Yoyo);
    }

    public void showCorrectIcon(){
        if (isIncorrect){
            iconWrong.SetActive(true);
        }
        else {
            iconRight.SetActive(true);
        }
    }

    private void deactivateIconsOnStart(){
        iconWrong.SetActive(false);
        iconRight.SetActive(false);
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
        markedAsIncorrect = trueOrNot; // ← ← ← ← ← This sets if market as incorrect or not.
        if (trueOrNot){
            
            border.SetActive(true);
            borderRT.DOScale(.975f, 0.1f).SetEase(Ease.Linear).From();
            
        }
        else {
            
            border.SetActive(false);
            border.transform.localScale = new Vector3(1,1,1);
        }
    }



}
