using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] private GameObject cameraToDisable;
    [SerializeField] private bool DisableCamera;
    //
    private bool playerCanClick = false;
    //
    GameObject cv;
    Image cvImg;
    GameObject border;
    GameObject hand;
    RectTransform handRT;
    Image handImg;
    GameObject click;
    RectTransform clickRT;
    Image clickImg;
    //
    GameObject textBox;
    Image textBoxImg;
    Color textBoxColor;
    GameObject mask;

    GameObject arrow;

    TMP_Text textBoxText;

    private string[] texts = new string[6];
    int textsCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        if (DisableCamera) cameraToDisable.SetActive(false);
        
        //
        texts[0] = "¡Hola! Bienvenido. Tocá la pantalla para continuar.";
        texts[1] = "Te vamos a mostrar un currículum que tiene algunas fallas.";
        texts[2] = "Cuando encuentres una tocá sobre ella.";
        texts[3] = "Y una vez que termine el tiempo vamos a ver que tal lo hicimos.";
        //
        textBox = gameObject.transform.Find("TextBox").gameObject;
        textBoxImg = textBox.transform.GetComponent<Image>();
        textBoxColor = textBoxImg.color;
        textBoxImg.color = new Color(1,1,1,0);

        mask = textBox.transform.Find("Mask").gameObject;

        textBoxText = textBox.transform.Find("TextBoxText").GetComponent<TMP_Text>();
        textBoxText.text = "";

        arrow = textBox.transform.Find("Arrow").gameObject;
        arrow.SetActive(false);

        //

        cv = gameObject.transform.Find("CV").gameObject;
        cvImg = cv.transform.GetComponent<Image>();
        cvImg.color = new Color(1,1,1,0);

        hand = cv.transform.Find("Hand").gameObject;
        handRT = hand.transform.GetComponent<RectTransform>();
        handImg = hand.transform.GetComponent<Image>();
        hand.SetActive(false);
        click = hand.transform.Find("Click").gameObject;
        click.transform.GetComponent<Image>().color = new Color(1,1,1,0);
        click.SetActive(false);
        clickRT = click.transform.GetComponent<RectTransform>();
        clickImg = click.transform.GetComponent<Image>();
        
        border = cv.transform.Find("Border").gameObject;

        showShowTextBox();        
        BackGround.Instance.updatePageTitle(true, "¿CÓMO JUGAR?");
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
                        showText();
                        Debug.Log("Working touch");
                        return;
                    }
            }
            else if (Input.GetMouseButtonDown(0)){ 
                showText();
                Debug.Log("Working Click");
                return;
            }
        }
    }


    private void showText(){
        switch(textsCount){
            case 0:
                textBoxText.text = texts[textsCount];
            break;
            case 1:
                textBoxText.text = texts[textsCount];
                showCv();
            break;
            case 2:
                textBoxText.text = texts[textsCount];
                showHandAndClick();
            break;
            case 3:
                textBoxText.text = texts[textsCount];
                killAllTweens();
            break;
            case 4:
                alphaOutElements();
                
            break;
        }

        textsCount ++;
    }
    private void nextScene(){
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        BackGround.Instance.askToGoNextScene(sceneNumber);
    }

    private void alphaOutElements(){
        playerCanClick = false;
        border.SetActive(false);
        arrow.SetActive(false);
        textBoxText.text = "";
        cvImg.DOColor(new Color(1,1,1,0), 0.75f);
        textBoxImg.DOColor(new Color(1,1,1,0), 0.75f);
        mask.GetComponent<Image>().DOColor(new Color(1,1,1,0), 0.75f).OnComplete(nextScene);
    }

    private void killAllTweens(){
        if (DOTween.IsTweening(handRT)){
            handRT.DOKill();            
        }
        if (DOTween.IsTweening(handImg)){
            handImg.DOKill();            
        }
        if (DOTween.IsTweening(clickImg)){
            clickImg.DOKill();            
        }
        if (DOTween.IsTweening(cvImg)){
            cvImg.DOKill();            
        }
        click.SetActive(false);
        hand.SetActive(false);
        border.SetActive(true);
    }

    private void restoreHandScale(){
        handRT.DOScale(2f, 0.25f).OnComplete(clickAnimation);
    }

    private void showClick(){
        click.SetActive(true);
        clickImg.DOFade(1, 0.5f).From().OnComplete(restoreHandScale);
        if (border.activeSelf){
            border.SetActive(false);
        }
        else{
            border.SetActive(true);
        }
        
    }

    private void clickAnimation(){
        handRT.DOScale(1.5f, 0.5f).OnComplete(showClick);
    }

    private void showHandAndClick(){
        hand.SetActive(true);
        handImg.DOFade(0f, 1f).From().OnComplete(clickAnimation);
    }



    private void paintTextBox(){
        mask.SetActive(true);
        textBoxImg.color = textBoxColor;
        showText();
        arrow.SetActive(true);
        playerCanClick = true;
    }

    private void showShowTextBox(){
        textBoxImg.DOFade(1, 1.5f).OnComplete(paintTextBox);
    }

    private void restoreClickAndArrow(){
        playerCanClick = true;
        arrow.SetActive(true);
    }

    private void showCv(){
        playerCanClick = false;
        arrow.SetActive(false);
        cvImg.DOFade(1, 1.5f).OnComplete(restoreClickAndArrow);
    }

    


}
