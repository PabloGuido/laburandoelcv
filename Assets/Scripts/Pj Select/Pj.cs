using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Pj : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;
    private Button thisButton;
    private bool fadeThis = true;
    private bool thisOneWasClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(fadePjs);
        gameObject.GetComponent<Image>().DOColor(new Color(1,1,1,0), 0.75f).From();
    }

    void Update(){
        if (PjSelect.Instance.PjSelected && fadeThis){
            fadeThis = false;
            gameObject.GetComponent<Image>().DOColor(new Color(1,1,1,0), 0.75f).OnComplete(askToLoadScene);
        }
    }
     void askToLoadScene(){
        if (thisOneWasClicked){
            BackGround.Instance.askToGoNextScene(sceneToLoad-1);
            //SceneManager.LoadScene(sceneToLoad);
        }
        
     }

    void fadeOffAllPj(){
        PjSelect.Instance.PjSelected = true;
    }


    void fadePjs(){
        if (PjSelect.Instance.playerCanClick){
            PjSelect.Instance.playerCanClick = false;
            thisOneWasClicked = true;
            gameObject.GetComponent<RectTransform>().DOScale(0.565f, 0.5f).From().OnComplete(fadeOffAllPj);
            
        }
    }
}
