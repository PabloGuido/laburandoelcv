using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Allow click player to advance scene:
    private bool playerCanClick;
    //
    private GameObject logo;
    private RectTransform logoRt;
    //
    private GameObject touchToStart;
    //
    private GameObject helpAfriend;
    // sound
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        //
        logo = gameObject.transform.Find("Logo").gameObject;
        logoRt = logo.GetComponent<RectTransform>();
        logo.GetComponent<Image>().DOColor(new Color(1,1,1,0), .75f).From().OnComplete(scaleLogo);
        //
        touchToStart = gameObject.transform.Find("TouchToStart").gameObject;
        touchToStart.SetActive(false);
        //
        helpAfriend = gameObject.transform.Find("HelpAfriend").gameObject;
        helpAfriend.GetComponent<Image>().DOColor(new Color(1,1,1,0), .75f).From();
        //
        
    }

    void Update()
    {
        // This input starts running after the times is up and while the game is correcting the CV.
        if (playerCanClick){
            // Track a single touch as a direction control.
            if (Input.touchCount > 0)
            {         
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        fadeOutAll();
                        //Debug.Log("Working touch");
                        return;
                    }
            }
            else if (Input.GetMouseButtonDown(0)){ 
                fadeOutAll();
                //Debug.Log("Working Click");                
                return;
            }
        }
    }

    private void fadeOutAll(){
        BackGround.Instance.playSound("mainMenu");
        playerCanClick = false;
        touchToStart.GetComponent<Animator>().enabled = false;
        touchToStart.GetComponent<Image>().enabled = true;
        touchToStart.GetComponent<Image>().DOColor(new Color(1,1,1,0), .75f);
        helpAfriend.GetComponent<Image>().DOColor(new Color(1,1,1,0), .75f);
        logo.GetComponent<Image>().DOColor(new Color(1,1,1,0), .75f).OnComplete(killAllTweens);
        BackGround.Instance.showLittleLogoAndFadeStar();
    }


    private void scaleLogo(){
        playerCanClick = true;

        logoRt.DOScale(0.525f, 3f).SetLoops(-1, LoopType.Yoyo);
        touchToStart.SetActive(true); 
    }

    private void killAllTweens(){
        DOTween.KillAll(true);
        nextScene();
    }

    private void nextScene(){
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        BackGround.Instance.askToGoNextScene(sceneNumber);
    }

}
