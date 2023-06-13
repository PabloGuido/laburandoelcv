using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    [HideInInspector] public bool playerInputAllowed = true;
    //
    [SerializeField] private int timer;
    TMP_Text timerText;
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
        // Start the timer:
        Invoke("TimerTest", 1);
    }

    void TimerTest(){
        timer --;
        Debug.Log(timer);
        if (timer == 0){
            changeTimerText(timer);
            playerInputAllowed = false;
            Debug.Log("Times up! Execute time up func.");
            return;
        }
        else{
            Invoke("TimerTest", 1);
            changeTimerText(timer);
        }
    }

    void changeTimerText(int time){
        timerText.text = time.ToString();
    }

}
