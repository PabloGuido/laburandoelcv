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
    //
    private Color alphaZero;
    private Color alphaOne;
    private Color mainMenuColor;
    //
    private Image littleLogo;
    
    private int firstTimeBootingGame = 0;

    private void Awake()
    {
        if (Instance != null){ 
            Destroy(gameObject); 
            return;
        } 

        Instance = this; 
        DontDestroyOnLoad(gameObject);
        firstTimeBootingGame ++;
        //
        mask = gameObject.transform.Find("Mask").gameObject;
        mainMenu = mask.transform.Find("MainMenu").GetComponent<Image>();
        star = mask.transform.Find("Star").GetComponent<Image>();
        middleImg = mask.transform.Find("MiddleImg").GetComponent<Image>();
        gameImg = mask.transform.Find("GameImg").GetComponent<Image>();
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
        
    }
    private void killStarRotation(){
        DOTween.Kill(starRt, false);
    }

    private void changeBackground(int sceneNumber){
        if (sceneNumber == 0){
            gameImg.DOColor(alphaZero, 2);
            mainMenu.DOColor(mainMenuColor, 2);
            star.DOColor(alphaOne, 2);
            starRt.DOLocalRotate(new Vector3(0, 0, -360), 60, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
        }
        else if (sceneNumber == 1){
            mainMenu.DOColor(alphaZero, 2);
            star.DOColor(alphaZero, 0.25f).OnComplete(killStarRotation);
            middleImg.DOColor(alphaOne, 2);
            littleLogo.DOColor(alphaOne, 2);
        }
        else if (sceneNumber > 3){
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
    
}
