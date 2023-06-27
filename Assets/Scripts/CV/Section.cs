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
    RectTransform correctImageBack;
    GameObject correctImageBackGO;
    GameObject correctImageGO;
    GameObject incorrectOption;
    GameObject border;
    RectTransform borderRT;
    // Icons
    GameObject iconWrong;
    GameObject iconRight;
    // Animator
    private Animator blinkAnim;


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
        // white back image
        correctImageBack = correctOption.transform.Find("Back").GetComponent<RectTransform>();
        correctImageBack.sizeDelta = new Vector2(imageSize.sizeDelta.x, imageSize.sizeDelta.y)*0.9f;
        correctImageBackGO = correctOption.transform.Find("Back").gameObject;
        correctImageBackGO.SetActive(false);
        //
        correctImageGO = correctOption.transform.Find("Image").gameObject;
        //

        blinkAnim = correctOption.transform.GetComponent<Animator>();
        blinkAnim.enabled = false;
        // sounds

        // Icons:
        iconWrong = border.transform.Find("IconWrong").gameObject;
        iconRight = border.transform.Find("IconRight").gameObject;
        deactivateIconsOnStart();
        
        /////// Methods to do at start: ///////
        // Check if this section is correct or not.
        disableOneOfTheOptions();
        // Add the method on click
        thisSection.onClick.AddListener(taskOnClick);
        //

        
        
    }



    public void hideBorderAndSettleCorrectImage(){
        // hide border moved to hideBorder()
        // if (isIncorrect){
        //     correctImage.DOKill();
        // }

        blinkAnim.enabled = false;
        correctImageBackGO.SetActive(false);
        incorrectOption.SetActive(false);
        correctOption.SetActive(true);
        correctImageGO.SetActive(true);
        correctImage.enabled = true;
        //correctImage.color = new Color(1,1,1,1);
    }

    public void hideBorder(){
        border.SetActive(false);
    }
    
    public void showCorrectImage(){
        
        if (isIncorrect){
            correctOption.SetActive(true);
            correctImageBackGO.SetActive(true);
            blinkAnim.enabled = true;

            // Color alphaZero = new Color(1,1,1,0);
            // correctImage.DOColor(alphaZero, 0);
            // Color alphaOne = new Color(1,1,1,1);
            // correctImage.DOColor(alphaOne, 1).SetLoops(-1, LoopType.Yoyo);
        }

    }

    private void leaveSubtleTweenOnIcon(RectTransform whichIcon){
        float iconScale = 1.075f;
        float tweenTime = 1.5f;
        whichIcon.transform.GetComponent<RectTransform>().DOScale(iconScale, tweenTime).SetEase(Ease.OutBounce).SetLoops(-1, LoopType.Yoyo).From();

    }

    public void showCorrectIcon(){
        
        float iconScale = 1.25f;
        float tweenTime = 0.65f;
        if (!markedAsIncorrect){
            border.GetComponent<Image>().color = new Color(255,255,255,0);  
            border.SetActive(true);          
        }

        if (isIncorrect){
            iconWrong.SetActive(true);
            RectTransform IWRT = iconWrong.transform.GetComponent<RectTransform>(); // This icon RectTransform.
            IWRT.DOScale(iconScale, tweenTime).SetEase(Ease.OutBack).SetLoops(2, LoopType.Yoyo).OnComplete(()=>leaveSubtleTweenOnIcon(IWRT));
        }
        else {
            iconRight.SetActive(true);
            RectTransform IRRT = iconRight.transform.GetComponent<RectTransform>(); // This icon RectTransform.
            IRRT.DOScale(iconScale, tweenTime).SetEase(Ease.OutBack).SetLoops(2, LoopType.Yoyo).OnComplete(()=>leaveSubtleTweenOnIcon(IRRT));
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
        if (AllowPlayerToClick.Instance.playerInputAllowed ){
            if (!markedAsIncorrect){
                sectionMarkedAsIncorrect(true);
                SoundsBorder.Instance.soundOn(true);
            }
            else {
                sectionMarkedAsIncorrect(false);
                SoundsBorder.Instance.soundOn(false);
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
