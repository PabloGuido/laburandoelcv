using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class Domain : MonoBehaviour
{
    [SerializeField] private GameObject dropDown;
    private Button domainButton;
    // Start is called before the first frame update
    void Start()
    {
        domainButton = gameObject.GetComponent<Button>();
        dropDown.SetActive(false);

        domainButton.onClick.AddListener(openOrcloseDropDown);
    }

    private void openOrcloseDropDown(){
        if (EnterData.Instance.playerCanClick){
            if (!dropDown.activeSelf){
                dropDown.SetActive(true);
            }
            else {
                dropDown.SetActive(false);
            }
        }
    }



}
