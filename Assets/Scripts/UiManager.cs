using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    public Camera cam;
    public static UiManager Instance;
    [HideInInspector] public bool playerInputAllowed = true;
    private bool gameCorrectingCv = false;
    // Show CV and countdown:
    GameObject Cv;
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
        
        // Start the timer:
        //Invoke("startTimer", 1);
        // Deny input  to player before the CV appears.
        playerInputAllowed = false;

        countdownToShowCv();
        //tests
        
        
        // var myVec = Cv.transform.Find("Photo").gameObject.GetComponent<RectTransform>().anchoredPosition;
        // var myVec2 = Cv.GetComponent<RectTransform>();
        
        // Debug.Log(myVec);
        // myVec2.DOAnchorPos(new Vector2(Mathf.Abs(myVec.x), -myVec.y)*3, 3, true);
        // Cv.transform.DOScale(3, 3);
       // Cv.transform.DOMoveX(324, 3);
    }

    void Update()
    {
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////
        // Maybe set a setting to let us check for the type of input for the testing with the real deal monitor.
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////
        if (gameCorrectingCv){
            // This input starts running after the times is up and while the game is correcting the CV.
            if (Input.GetMouseButtonDown(0)){
                //Debug.Log("Pressed primary button.");
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
            gameCorrectingCv = true; // ESTO VA CUANDO DESAPARECE TIMES UP
            //
            return;
        }
        else{
            Invoke("startTimer", 1);
            changeTimerText(timer);
        }
    }

    void theTimeIsUp(){
        if (timesUp.activeSelf){
            // Disabling visual stuff:
            timesUp.SetActive(false);
            timerGO.SetActive(false);
            Debug.Log("Deactivating TimesUp! visual cue. Start the correction phase.");
            // Start with the correction phase here.
                    var myVec = Cv.transform.Find("Photo").gameObject.GetComponent<RectTransform>().anchoredPosition;
        var myVec2 = Cv.GetComponent<RectTransform>();
        
        Debug.Log(myVec);
        myVec2.DOAnchorPos(new Vector2(Mathf.Abs(myVec.x), -myVec.y)*3, 3, true);
        Cv.transform.DOScale(3, 3);
        }
        else {
            Debug.Log("Activating TimesUp! visual cue and starting timer to self Invoke again.");
            timesUp.SetActive(true);
            Invoke("theTimeIsUp", 3);
        }

    }

    void changeTimerText(int time){
        timerText.text = time.ToString();
    }

}



