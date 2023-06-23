using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class Key : MonoBehaviour
{
    private TMP_Text thisKey;
    private string key;
    //
    private Button thisButton;
    //
    [SerializeField] private GameObject dropDown;
    [SerializeField] private TMP_InputField mailField;
    // Start is called before the first frame update
    void Start()
    {
        thisKey = gameObject.transform.Find("thisKey").transform.GetComponent<TMP_Text>();
        key = thisKey.text;

        thisButton = gameObject.transform.GetComponent<Button>();
        thisButton.onClick.AddListener(addKeyToField);
    }

    void addKeyToField(){
        if (EnterData.Instance.playerCanClick){

        
            if (dropDown.activeSelf){
                dropDown.SetActive(false);
            }

            mailField.text = mailField.text + key;
            mailField.caretPosition = mailField.text.Length; 
            mailField.Select();
        }
        //Debug.Log(key);
        //Debug.Log(mailField.caretPosition);
    }

}
