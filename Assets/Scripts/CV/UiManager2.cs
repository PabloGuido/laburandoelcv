using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UiManager2 : MonoBehaviour
{
    //[SerializeField] private int whatCvToCorrect;
    //
    private int transTimer = 2;
    //

    public static UiManager2 Instance;
    [HideInInspector] public bool playerInputAllowed = true;
    private bool gameCorrectingCv = false;
    bool playerCanClick = false;

    // Show CV and countdown:
    GameObject mask;
    GameObject Cv;
    RectTransform CvRT;
    [SerializeField] private bool skipCountdown;
    private int countDownToCv = 5;
    [SerializeField]  private Sprite[] countDownImgArray = new Sprite[6];
    Image countDownImg;
    GameObject countDownGO; // This is for disabling the 'node';
    // Timer:
    [SerializeField] private int timer;
    TMP_Text timerText;
    private GameObject timerGO;
    // Time's up!:
    GameObject timesUp;
    // Correction img:
    GameObject correctionImg;
    // TextBox:
    GameObject textBox;
    TMP_Text textBoxText;
    Image textBoxImg;
    GameObject textBoxArrow;
    //
    CorrectionScriptPJ2 textsAndPos;

    //
    GameObject iconWrong;
    GameObject iconRight;
    bool playerAwnseredRight;
    int stepNumber = 0;
    int moveTowardsNumber = 0;
    // Colors:
    Color yellow = new Color(0.98f, 0.75f, 0.14f, 1f);
    Color green = new Color(0.3f, 0.87f, 0.56f, 1f);
    Color red = new Color(1f, 0.29f, 0.55f, 1f);

    // Canvas Sort Order:
    [SerializeField] private Canvas thisCanvas;
    
    // test build
    //public Button startGame;
    //public GameObject startGameGO;

    private float middleOfScreen;

    private void Awake()
    {
        // Ver de chequear que haya uno solo. creo que no haría falta porque este script no persiste entre escenas.
        Instance = this;
        //Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        //Debug.Log(gameObject.GetComponent<RectTransform>().anchoredPosition.x);
        middleOfScreen = gameObject.GetComponent<RectTransform>().anchoredPosition.x;

    }
    //Start is called before the first frame update
    void Start()
    {
        
        mask = gameObject.transform.Find("Mask").gameObject;
        // Show CV and countdown:
        Cv = mask.transform.Find("CV").gameObject;
        Cv.SetActive(false);
        CvRT = Cv.GetComponent<RectTransform>();        
        countDownGO = gameObject.transform.Find("Countdown").gameObject;
        countDownImg = countDownGO.transform.GetComponent<Image>();
        //Timer Time:
        //timer = 60; // In case of need or in the final build put set timer here. Maybe we can add a setting for this, at least yes for testing.
        
        timerGO = gameObject.transform.Find("Timer Img").gameObject;
        timerText = timerGO.transform.Find("Timer Txt").gameObject.GetComponent<TMP_Text>();
        changeTimerText(timer); // Set the timer text to then be disabled and enabled.
        timerGO.SetActive(false);        
        // Time's Up!:
        timesUp = gameObject.transform.Find("Times up").gameObject;
        timesUp.SetActive(false);
        // Correction img:
        correctionImg = gameObject.transform.Find("CorrectionImg").gameObject;
        correctionImg.SetActive(false);
        // TextBox:
        textBox = gameObject.transform.Find("TextBox").gameObject;
        textBoxText = textBox.transform.Find("TextBoxText").GetComponent<TMP_Text>();
        textBoxImg = textBox.GetComponent<Image>();
        textBoxImg.color = yellow;

        textBoxArrow = textBox.transform.Find("Arrow").gameObject;        
        iconWrong = textBox.transform.Find("IconWrong").gameObject;
        iconRight = textBox.transform.Find("IconRight").gameObject;
        deactivateIconsOnStart();
        textBox.SetActive(false);
        // Texts
        // Add method that selects what text we should read
        textsAndPos = gameObject.GetComponent<CorrectionScriptPJ2>();
        

        
        // Deny input  to player before the CV appears:
        AllowPlayerToClick.Instance.playerInputAllowed = false;

        //
        //startGame.onClick.AddListener(countdownToShowCv);
        countdownToShowCv();

    }

    void Update()
    {
        // This input starts running after the times is up and while the game is correcting the CV.
        if (gameCorrectingCv && playerCanClick){
            // Track a single touch as a direction control.
            if (Input.touchCount > 0)
            {         
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        Debug.Log("Working touch");
                        
                        whatToDoNext();
                        return;
                    }
            }
            else if (Input.GetMouseButtonDown(0)){ 
                Debug.Log("Working Click");
                whatToDoNext();
                return;
            }
        }
    }

    void changeThisCanvasSortOrderToTop(){
        thisCanvas.sortingOrder = 10;
    }

    void cueInTheCvAnimation(){
        Cv.SetActive(true);
        CvRT.DOMoveX(middleOfScreen,1.15f).SetEase(Ease.InOutElastic).OnComplete(changeThisCanvasSortOrderToTop);
        //CvRT.DOMoveX(720,1.15f).SetEase(Ease.Linear).OnComplete(changeThisCanvasSortOrderToTop);
    }

    void startCorrectingCv(){
        countDownGO.SetActive(false);
        timerGO.SetActive(true);
        AllowPlayerToClick.Instance.playerInputAllowed = true;
        Invoke("startTimer", 1);
    }

    void countdownToShowCv(){
        if (skipCountdown){
            startCorrectingCv();
            return;
        }
        
        countDownImg.sprite = countDownImgArray[countDownToCv];
        countDownToCv --;
        if (countDownToCv == 0){
            countDownGO.transform.GetComponent<RectTransform>().DOScale(0.45f, 0.15f).From();
            Invoke("startCorrectingCv", 1);
            cueInTheCvAnimation();
            return;
        }
        else if (countDownToCv == 4){
            //startGameGO.SetActive(false);
            countDownImg.DOFade(0f, 1.5f).From(); // Fades in "LISTO?";
            Invoke("countdownToShowCv", 3);
            return;
        }
        else {
            countDownGO.transform.GetComponent<RectTransform>().DOScale(0.45f, 0.15f).From();
            Invoke("countdownToShowCv", 1);
        }        
    }

    void startTimer(){
        timer --;
        //Debug.Log(timer);
        if (timer == 0){
            changeTimerText(timer);
            AllowPlayerToClick.Instance.playerInputAllowed = false;
            //
            Debug.Log("Times up! Execute time up func.");
            theTimeIsUp();
            
            //
            return;
        }
        else{
            Invoke("startTimer", 1);
            changeTimerText(timer);
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void allowPlayerClickAndShowArrow(bool trueOrFalse){
            playerCanClick = trueOrFalse;
            textBoxArrow.SetActive(trueOrFalse);

    }
    void whatToDoNext(){

        string doWhat = textsAndPos.step[stepNumber];
        switch(doWhat) 
        {
        case "read":
            // code block
            updateTextBox();
            allowPlayerClickAndShowArrow(true);
            Debug.Log("READ");
            break;
        case "animate":
            // code block
            updateTextBox();
            allowPlayerClickAndShowArrow(false);
            moveTowards();
            break;
        case "buildUp":
            // code block
            updateTextBox();
            allowPlayerClickAndShowArrow(false);
            createBuildUp();
            break;
        case "awnser":
            // code block            
            updateTextBoxWithAwnser();
            showCorrectIcon();
            allowPlayerClickAndShowArrow(true);
            break;
        case "correction":
            // code block
            doTheCorrection();
            updateTextBoxWithAwnser();
            allowPlayerClickAndShowArrow(true);
            break;
        case "settle":
            // code block
            hideBorderAndIcon();
            updateTextBoxWithAwnser();
            allowPlayerClickAndShowArrow(true);
            break; 
        case "next":
            // code block
            updateTextBox();
            allowPlayerClickAndShowArrow(false);
            moveTowardsNumber ++;
            moveTowards();
            break;
        case "endZoom":
            // code block
            endZoom();
            updateTextBox();
            allowPlayerClickAndShowArrow(false);
            break;
        case "cueEndScene":
            if (stepNumber == textsAndPos.step.Length-1){
                Debug.Log("volver a cargar intro screen.");
                loadMainMenu();
                break;
            }
            else{
                allowPlayerClickAndShowArrow(false);
                updateTextBox();
                cueEndScene();
                break;
            }

        }
        
        stepNumber ++;        
    }

    private void nextScene(){
        BackGround.Instance.askToGoNextScene(-1);
        //SceneManager.LoadScene(0);
    }

    void loadMainMenu(){
        textBoxText.text = "";
        textBox.SetActive(false);
        CvRT.DOMoveX(1400,1.25f).SetEase(Ease.OutSine).OnComplete(nextScene);
    }

    void cueEndScene(){
        Invoke("whatToDoNext",2f);
    }

    void endZoom(){
        Cv.transform.DOScale(0.8f, 3);
        CvRT.DOAnchorPos(new Vector2(0, -400f), 3, true).OnComplete(whatToDoNext); 
    }

    void hideBorderAndIcon(){
        textBoxImg.color = yellow;
        deactivateIconsOnStart();
        textsAndPos.CvSectionsGO[moveTowardsNumber].hideBorderAndSettleCorrectImage();
    }

    void showCorrectIcon(){
        //textsAndPos.CvSectionsGO[moveTowardsNumber].showCorrectIcon();
        if (iconRight.activeSelf || iconWrong.activeSelf){
            return;
        }
        if (playerAwnseredRight){
            textBoxImg.color = green;
            iconRight.SetActive(true);
        }
        else {
            textBoxImg.color = red;
            iconWrong.SetActive(true);
        }
    }
    void doTheCorrection(){
        textsAndPos.CvSectionsGO[moveTowardsNumber].showCorrectImage();
    }
    void buildUpImpactAndContinue(){
        textsAndPos.CvSectionsPos[moveTowardsNumber].transform.DOScale(1f, 0.15f).SetEase(Ease.OutBack).OnComplete(whatToDoNext);
        textsAndPos.CvSectionsGO[moveTowardsNumber].hideBorder();
    }
    void createBuildUp(){
        textsAndPos.CvSectionsPos[moveTowardsNumber].transform.DOScale(1.1f, 2).OnComplete(buildUpImpactAndContinue);
        
    }

    void moveTowards(){    
        float scaleCv = textsAndPos.CvZoom[moveTowardsNumber]; 
        var myTargetVec = textsAndPos.CvSectionsPos[moveTowardsNumber].anchoredPosition;
        var myOffsetX = textsAndPos.SectionOffset[moveTowardsNumber].localPosition.x;
        var myOffsetY = textsAndPos.SectionOffset[moveTowardsNumber].localPosition.y;
        //Debug.Log(myOffsetX + "   " + myOffsetY);
        myTargetVec.x = myTargetVec.x + myOffsetX;
        myTargetVec.y = myTargetVec.y + myOffsetY;

        if (myTargetVec.x > 0){
            myTargetVec.x = -myTargetVec.x;
        }
        else if (myTargetVec.x < 0){
            myTargetVec.x = Mathf.Abs(myTargetVec.x);
        }

        if (myTargetVec.y > 0){
            myTargetVec.y = -myTargetVec.y;
        }
        else if (myTargetVec.y < 0){
            myTargetVec.y = Mathf.Abs(myTargetVec.y);
        }

        Cv.transform.DOScale(scaleCv, 3);
        CvRT.DOAnchorPos(new Vector2(myTargetVec.x, myTargetVec.y)*scaleCv, 3, true).OnComplete(whatToDoNext);      
    }
    void updateTextBoxWithAwnser(){
        // The correct awnsers.
        bool sectionIsIncorrect = textsAndPos.CvSectionsGO[moveTowardsNumber].isIncorrect;
        bool markedAsIncorrectByPlayer = textsAndPos.CvSectionsGO[moveTowardsNumber].markedAsIncorrect;

        if (sectionIsIncorrect){
            if (markedAsIncorrectByPlayer){
                playerAwnseredRight = true;
                textBoxText.text = textsAndPos.correctTextToRender[stepNumber];
            }
            else if (!markedAsIncorrectByPlayer){
                playerAwnseredRight = false;
                textBoxText.text = textsAndPos.incorrectTextToRender[stepNumber];
            }
        } 
        //
        else if (!sectionIsIncorrect){
            if (markedAsIncorrectByPlayer){
                playerAwnseredRight = false;
                textBoxText.text = textsAndPos.incorrectTextToRender[stepNumber];
            }
            else if (!markedAsIncorrectByPlayer){
                playerAwnseredRight = true;
                textBoxText.text = textsAndPos.correctTextToRender[stepNumber];
            }
        }
        
    }
    void updateTextBox(){       
        textBoxText.text = textsAndPos.textToRender[stepNumber];
    }

    void showTextBox(){
        textBox.SetActive(true);
        whatToDoNext();
        Debug.Log("STEP: " + textsAndPos.step[stepNumber]);
    }

    void showCorrectionImg(){
        if (correctionImg.activeSelf){
            correctionImg.SetActive(false);
            gameCorrectingCv = true;
            showTextBox();
        }
        else{
            correctionImg.SetActive(true);
            Invoke("showCorrectionImg", transTimer);
        }
    }

    void theTimeIsUp(){
        if (timesUp.activeSelf){
            // Disabling visual stuff:
            timesUp.SetActive(false);
            timerGO.SetActive(false);
            Debug.Log("Deactivating TimesUp! visual cue. Start the correction phase.");
            // Start with the correction phase here.
            thisCanvas.sortingOrder = 1;
            showCorrectionImg(); 

        }
        else {
            Debug.Log("Activating TimesUp! visual cue and starting timer to self Invoke again.");
            timesUp.SetActive(true);
            Invoke("theTimeIsUp", transTimer);
        }

    }

    void changeTimerText(int time){
        timerText.text = time.ToString();
    }

    private void deactivateIconsOnStart(){
        iconWrong.SetActive(false);
        iconRight.SetActive(false);
    }

}



