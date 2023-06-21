using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HowToPlay : MonoBehaviour
{
    private bool playerCanClick;
    //
    GameObject cv;
    Image cvImg;
    Image border;
    Image hand;
    Image click;
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
        texts[0] = "¡Hola! Bienvenido. Tocá la pantalla para continuar.";
        texts[1] = "Te vamos a motrar un currículum que tiene algunas fallas.";
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

        showShowTextBox();
        //showCv();
    }

    private void showText(){
        textBoxText.text = texts[textsCount];
    }

    private void paintTextBox(){
        mask.SetActive(true);
        textBoxImg.color = textBoxColor;
        showText();
        arrow.SetActive(true);
    }

    private void showShowTextBox(){
        textBoxImg.DOFade(1, 1.5f).OnComplete(paintTextBox);
    }

    private void showCv(){
        cvImg.DOFade(1, 3f);
    }


    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
