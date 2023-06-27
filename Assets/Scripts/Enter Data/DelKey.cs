using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class DelKey : MonoBehaviour
{
    private TMP_Text thisKey;
    private string key;
    //
    private Button thisButton;
    //
    [SerializeField] private TMP_InputField mailField;
    private AudioSource clickedAudio;
    // Start is called before the first frame update
    void Start()
    {
        thisKey = gameObject.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
        key = thisKey.text;

        thisButton = gameObject.transform.GetComponent<Button>();
        thisButton.onClick.AddListener(removeKeyToField);
        clickedAudio = GetComponent<AudioSource>();
    }

    private void setButtonScale(){
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.785714f,1.724138f,1);
    }

    void removeKeyToField(){
        gameObject.GetComponent<RectTransform>().DOScale(2f, 0.25f).From().OnComplete(setButtonScale);
        clickedAudio.Play();
        if (EnterData.Instance.playerCanClick){
            if (mailField.text.Length > 0){
                mailField.text = mailField.text.Remove(mailField.text.Length-1,1);
                mailField.caretPosition = mailField.text.Length; 
                mailField.Select();  
                if (mailField.text.Length <= 11){
                    mailField.selectionFocusPosition = 0;
                }    
            }  
        }
        //Debug.Log(mailField.text.Length);
    }

}
