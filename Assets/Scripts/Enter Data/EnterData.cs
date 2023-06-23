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

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startButton = gameObject.transform.Find("Start").GetComponent<Button>();
        startButton.onClick.AddListener(askGoToNextScene);
    }

    private void askGoToNextScene(){
        if (playerCanClick){
            if (mailField.text.Length <= 1 || domainField.text.Length <= 0 ){
                
                //Debug.Log("Enter mail.");
            }
            else {
                
                //Debug.Log(mailField.text + "@" + domainField.text);
            }
        }
    }

}
