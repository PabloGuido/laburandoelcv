using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BackGround : MonoBehaviour
{
    public static BackGround Instance;
    //
    private GameObject mask;
    private Image mainMenu;
    private Image star;
    private RectTransform starRt;
    private Image middleImg;
    private Image gameImg;
    private Image pageTitle;
    private TMP_Text pageTxt;
    //
    private Color alphaZero;
    private Color alphaOne;
    private Color mainMenuColor;
    //
    private Image littleLogo;
    // sounds:
    private AudioSource introMusic;
    private AudioSource mainMenuSound;
    

    private void Awake()
    {
        if (Instance != null){ 
            Destroy(gameObject); 
            return;
        } 

        Instance = this; 
        DontDestroyOnLoad(gameObject);
        
        //
        mask = gameObject.transform.Find("Mask").gameObject;
        mainMenu = mask.transform.Find("MainMenu").GetComponent<Image>();
        star = mask.transform.Find("Star").GetComponent<Image>();
        middleImg = mask.transform.Find("MiddleImg").GetComponent<Image>();
        gameImg = mask.transform.Find("GameImg").GetComponent<Image>();
        //
        pageTitle = gameObject.transform.Find("PageTitle").GetComponent<Image>();
        pageTxt = pageTitle.transform.Find("PageTxt").GetComponent<TMP_Text>();
        //
        alphaZero = new Color(1,1,1,0);
        alphaOne = new Color(1,1,1,1);
        //
        starRt = mask.transform.Find("Star").gameObject.GetComponent<RectTransform>();
        starRt.DOLocalRotate(new Vector3(0, 0, -360), 60, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
        //
        middleImg.color = alphaZero;
        gameImg.color = alphaZero;
        mainMenuColor = mainMenu.color;
        //
        littleLogo = gameObject.transform.Find("Border").transform.Find("Logo").GetComponent<Image>();
        //
        introMusic = GetComponent<AudioSource>();
        if (!introMusic.isPlaying){
            introMusic.Play();
        }
        mainMenuSound = mask.transform.Find("MainMenu").GetComponent<AudioSource>();
        
    }

    public void playSound(string whichAudio){
        if (whichAudio == "mainMenu"){
            mainMenuSound.Play();
        }
        
    }

    private void killStarRotation(){
        DOTween.Kill(starRt, false);
    }
    private void stopIntroMusic(){
        introMusic.Stop();
    }

    private void changeBackground(int sceneNumber){
        if (sceneNumber == 0){
            gameImg.DOColor(alphaZero, 2);
            mainMenu.DOColor(mainMenuColor, 2);
            littleLogo.DOColor(alphaZero, 2);
            star.DOColor(alphaOne, 2);
            starRt.DOLocalRotate(new Vector3(0, 0, -360), 60, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
        }
        else if (sceneNumber == 1){
            mainMenu.DOColor(alphaZero, 2);            
            middleImg.DOColor(alphaOne, 2);            
        }
        else if (sceneNumber > 3){
            introMusic.DOFade(0,2).OnComplete(stopIntroMusic);
            middleImg.DOColor(alphaZero, 2);
            gameImg.DOColor(alphaOne, 2);
        }
    }

    private void nextScene(int sceneAsking){          
        int nextScene = sceneAsking + 1;
        changeBackground(nextScene);
        SceneManager.LoadScene(nextScene);
    }

    public void askToGoNextScene(int sceneAsking){
        nextScene(sceneAsking);
    }
    public void goToPjSelect(int sceneAsking){
        int nextScene = sceneAsking + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void showLittleLogoAndFadeStar(){
        star.DOColor(alphaZero, 1.25f).OnComplete(killStarRotation);
        littleLogo.DOColor(alphaOne, 2);
    }



    public void updatePageTitle(bool onOff, string whatSays){
        if (onOff){
            pageTxt.text = whatSays;
            pageTitle.DOColor(alphaOne, 0.75f);
            pageTxt.DOColor(new Color(0,0,0,1), 0.75f);
            
        }
        else{
            pageTitle.DOColor(alphaZero, 0.75f);
            pageTxt.DOColor(new Color(0,0,0,0), 0.75f);
        }
    }
    
}
