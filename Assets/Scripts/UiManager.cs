using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    //
    private int transTimer = 1;
    //

    public static UiManager Instance;
    [HideInInspector] public bool playerInputAllowed = true;
    private bool gameCorrectingCv = false;
    bool playerCanClick = false;

    // Show CV and countdown:
    GameObject Cv;
    RectTransform CvRT;
    [SerializeField] private bool skipCountdown;
    private int countDownToCv = 5;
    private string[] countDownTexts = {"", "¡Ahora!","1", "2", "3", "¿Listo?"};
    TMP_Text countDownTmp;
    GameObject countDownTmpGO; // This is for disabling the 'node';
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
    GameObject textBoxArrow;
    CorrectionsTexts textsAndPos;
    int stepNumber = 0;
    int moveTowardsNumber = 0;


    private void Awake()
    {
        // Ver de chequear que haya uno solo. creo que no haría falta porque este script no persiste entre escenas.
        Instance = this;
    }
    //Start is called before the first frame update
    void Start()
    {
        
        // Show CV and countdown:
        Cv = gameObject.transform.Find("CV").gameObject;
        Cv.SetActive(false);
        CvRT = Cv.GetComponent<RectTransform>();
        countDownTmp = gameObject.transform.Find("Countdown").gameObject.GetComponent<TMP_Text>();
        countDownTmpGO = gameObject.transform.Find("Countdown").gameObject;
        //Timer Time:
        //timer = 60; // In case of need or in the final build put set timer here. Maybe we can add a setting for this, at least yes for testing.
        timerText = gameObject.transform.Find("Timer").gameObject.GetComponent<TMP_Text>();
        changeTimerText(timer); // Set the timer text to then be disabled and enabled.
        timerGO = gameObject.transform.Find("Timer").gameObject;
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
        textBoxArrow = textBox.transform.Find("Arrow").gameObject;
        textBox.SetActive(false);
        // Texts
        textsAndPos = gameObject.GetComponent<CorrectionsTexts>();

        
        // Deny input  to player before the CV appears:
        playerInputAllowed = false;

        countdownToShowCv();

    }

    void Update()
    {
        
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////
        // Maybe set a setting to let us check for the type of input for the testing with the real deal monitor.
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////

        // This input starts running after the times is up and while the game is correcting the CV.
        if (Input.GetMouseButtonDown(0)){
            // Debug.Log("GC " + gameCorrectingCv);
            // Debug.Log("PC " + playerCanClick);
            if (gameCorrectingCv && playerCanClick){
                whatToDoNext();
            }
        }
    }

    void startCorrectingCv(){
        countDownTmpGO.SetActive(false);
        Cv.SetActive(true);
        timerGO.SetActive(true);
        playerInputAllowed = true;
        Invoke("startTimer", 1);
    }

    void countdownToShowCv(){
        if (skipCountdown){
            startCorrectingCv();
            return;
        }
        countDownTmp.text = countDownTexts[countDownToCv];
        countDownToCv --;
        if (countDownToCv == 0){
            Invoke("startCorrectingCv", 1);
            return;
        }
        else {
            Invoke("countdownToShowCv", 1);
        }        
    }

    void startTimer(){
        timer --;
        //Debug.Log(timer);
        if (timer == 0){
            changeTimerText(timer);
            playerInputAllowed = false;
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
            allowPlayerClickAndShowArrow(true);
            break;
        case "correction":
            // code block
            doTheCorrection();
            updateTextBoxWithAwnser();
            allowPlayerClickAndShowArrow(true);
            break;             
        case "next":
            // code block
            moveTowardsNumber ++;
            break;
        }
        stepNumber ++;        
    }

    void doTheCorrection(){
        Debug.Log("is this ok?");
        textsAndPos.CvSectionsGO[moveTowardsNumber].showCorrectImage();
    }
    void buildUpImpactAndContinue(){
        textsAndPos.CvSectionsPos[moveTowardsNumber].transform.DOScale(1, 0.15f).SetEase(Ease.OutBack).OnComplete(whatToDoNext);
    }
    void createBuildUp(){
        textsAndPos.CvSectionsPos[moveTowardsNumber].transform.DOScale(1.1f, 2).OnComplete(buildUpImpactAndContinue);
        
    }

    void moveTowards(){     
        var myTargetVec = textsAndPos.CvSectionsPos[moveTowardsNumber].anchoredPosition;
        Cv.transform.DOScale(3, 3);
        CvRT.DOAnchorPos(new Vector2(Mathf.Abs(myTargetVec.x), -myTargetVec.y)*3, 3, true).OnComplete(whatToDoNext);       
        
    }
    void updateTextBoxWithAwnser(){
        // The correct awnsers.
        if (textsAndPos.CvSectionsGO[moveTowardsNumber].isIncorrect){
            if (textsAndPos.CvSectionsGO[moveTowardsNumber].markedAsIncorrect){
                textBoxText.text = textsAndPos.correctTextToRender[stepNumber];
            }
        } 
        else if (!textsAndPos.CvSectionsGO[moveTowardsNumber].isIncorrect){
            if (!textsAndPos.CvSectionsGO[moveTowardsNumber].markedAsIncorrect){
                textBoxText.text = textsAndPos.correctTextToRender[stepNumber];
            }
        }
        // The wrong awnsers.
        
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

}



