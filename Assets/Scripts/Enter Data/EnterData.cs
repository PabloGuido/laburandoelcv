using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EnterData : MonoBehaviour
{
    
    [SerializeField] private GameObject cameraToDisable;
    [SerializeField] private bool DisableCamera;
    //
    public static EnterData Instance;
    public bool playerCanClick = false;
    //
    private Button startButton;
    private GameObject startButtonGO;
    private AudioSource good;
    private AudioSource bad;
    //
    [SerializeField] private TMP_Text mailField;
    [SerializeField] private TMP_Text domainField;
    //
    private RectTransform fullKeyboard;
    private GameObject needMail;
    //
    [SerializeField] private GameObject dropDown;
    //
    private Image leaveData;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TouchScreenKeyboard.hideInput = true;
        if (DisableCamera) cameraToDisable.SetActive(false);
        //
        startButton = gameObject.transform.Find("Start").GetComponent<Button>();
        startButton.onClick.AddListener(askGoToNextScene);
        startButtonGO = transform.Find("Start").gameObject;
        good = startButtonGO.transform.Find("good").GetComponent<AudioSource>();
        bad = startButtonGO.transform.Find("bad").GetComponent<AudioSource>();
        //
        needMail = gameObject.transform.Find("NeedMail").gameObject;
        needMail.SetActive(false);
        //
        fullKeyboard = gameObject.GetComponent<RectTransform>();
        fullKeyboard.DOMoveX(-2300f,1f).SetEase(Ease.OutSine).From().OnComplete(letPlayerClick);
        //
        leaveData = gameObject.transform.Find("LeaveData").GetComponent<Image>();
        leaveData.DOColor(new Color(1,1,1,0), 1f).From();
        //
        //BackGround.Instance.updatePageTitle(true, "ANTES DE EMPEZAR");
    }
    private void letPlayerClick(){
        playerCanClick = true;
    }

    private void setButtonScale(){
        startButton.GetComponent<RectTransform>().localScale = new Vector3(0.5f,0.5f,1);
    }

    private void askGoToNextScene(){
        startButton.GetComponent<RectTransform>().DOScale(0.525f, 0.25f).From().OnComplete(setButtonScale);
        if (playerCanClick){
            if (mailField.text.Length <= 1 || domainField.text.Length <= 0 ){
                pleaseEnterValidMail();
                //Debug.Log("Enter mail.");
            }
            else {
                SaveMails.Instance.addMailToList(mailField.text + "@" + domainField.text);
                hideKeyboard();
                Debug.Log(mailField.text + "@" + domainField.text);
            }
        }
    }

    private void pleaseEnterValidMail(){
        if (!needMail.activeSelf){
            bad.Play();
            playerCanClick = false;
            dropDown.SetActive(false);
            needMail.SetActive(true);
            Invoke("pleaseEnterValidMail", 3);
        }
        else{
            playerCanClick = true;
            needMail.SetActive(false);
        }
    }

    private void hideKeyboard(){
        good.Play();
        playerCanClick = false;
        gameObject.transform.Find("Start").GetComponent<Image>().DOColor(new Color(1,1,1,0), 0.25f);
        leaveData.DOColor(new Color(1,1,1,0), 0.85f);
        fullKeyboard.DOMoveX(2300f,1f).SetEase(Ease.InSine).OnComplete(nextScene);
    }

    private void nextScene(){
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        BackGround.Instance.goToPjSelect(sceneNumber);
    }

}
