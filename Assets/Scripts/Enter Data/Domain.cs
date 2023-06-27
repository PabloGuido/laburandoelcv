using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class Domain : MonoBehaviour
{
    public static Domain Instance;
    [SerializeField] private GameObject dropDown;
    private Button domainButton;
    private AudioSource clicked;

    private void Awake()
    {
        Instance = this;        
    }
    // Start is called before the first frame update
    void Start()
    {
        domainButton = gameObject.GetComponent<Button>();
        dropDown.SetActive(false);

        domainButton.onClick.AddListener(openOrcloseDropDown);

        clicked = GetComponent<AudioSource>();
    }

    public void playSound(){
        clicked.Play();
    }

    private void openOrcloseDropDown(){
        clicked.Play();
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
