using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    [HideInInspector] public bool playerInputAllowed = true;
    private bool gameCorrectingCv = false;
    // Timer:
    [SerializeField] private int timer;
    TMP_Text timerText;
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
        //timer = 60; // In case of need or in the final build put set timer here. Maybe we can add a setting for this, at least yes for testing.
        timerText = gameObject.transform.Find("Timer").gameObject.GetComponent<TMP_Text>();
        changeTimerText(timer);
        // Time's Up!:
        timesUp = gameObject.transform.Find("Times up").gameObject;
        timesUp.SetActive(false);
        
        // Start the timer:
        Invoke("TimerTest", 1);
    }

    void Update()
    {
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////
        //////// VER INPUT GET TOCUCH PARA LA PANTALLA ////////
        if (gameCorrectingCv){
            // This input starts running after the times is up and while the game is correcting the CV.
            if (Input.GetMouseButtonDown(0)){
                //Debug.Log("Pressed primary button.");
            }
        }
    }

    void TimerTest(){
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
            Invoke("TimerTest", 1);
            changeTimerText(timer);
        }
    }

    void theTimeIsUp(){
        if (timesUp.activeSelf){
            timesUp.SetActive(false);
            Debug.Log("Deactivating TimesUp! visual cue. Start the correction phase.");
            // Start with the correction phase here.
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
