using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EnterData : MonoBehaviour
{
    public static EnterData Instance;
    public bool playerCanClick = false;
    //
    private Button startButton;
    //
    [SerializeField] private TMP_Text mailField;
    [SerializeField] private TMP_Text domainField;
    //
    private RectTransform fullKeyboard;
    private GameObject needMail;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startButton = gameObject.transform.Find("Start").GetComponent<Button>();
        startButton.onClick.AddListener(askGoToNextScene);
        //
        needMail = gameObject.transform.Find("NeedMail").gameObject;
        needMail.SetActive(false);
        //
        fullKeyboard = gameObject.GetComponent<RectTransform>();
        fullKeyboard.DOMoveX(-2300f,1f).SetEase(Ease.InOutElastic).From();
    }

    private void askGoToNextScene(){
        if (playerCanClick){
            if (mailField.text.Length <= 1 || domainField.text.Length <= 0 ){
                pleaseEnterValidMail();
                //Debug.Log("Enter mail.");
            }
            else {
                SaveMails.Instance.addMailToList(mailField.text + "@" + domainField.text);
                Invoke("nextScene",2f);
                
                Debug.Log(mailField.text + "@" + domainField.text);
            }
        }
    }

    private void pleaseEnterValidMail(){
        if (!needMail.activeSelf){
            playerCanClick = false;
            needMail.SetActive(true);
            Invoke("pleaseEnterValidMail", 3);
        }
        else{
            playerCanClick = true;
            needMail.SetActive(false);
        }
    }

    private void nextScene(){
        playerCanClick = false;
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        BackGround.Instance.askToGoNextScene(sceneNumber);
    }

}
