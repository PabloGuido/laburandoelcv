using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class DomainButton : MonoBehaviour
{
    private Button thisButton;
    private string domainText;
    //
    [SerializeField] private GameObject dropDown;
    [SerializeField] private TMP_Text dropDownButtonText;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = gameObject.GetComponent<Button>();
        domainText = gameObject.transform.Find("DomainText").GetComponent<TMP_Text>().text;
        //
        thisButton.onClick.AddListener(selectDomain);

    }

    private void selectDomain(){
        if (EnterData.Instance.playerCanClick){
            dropDown.SetActive(false);
            dropDownButtonText.text = domainText;
        }
    }

}
