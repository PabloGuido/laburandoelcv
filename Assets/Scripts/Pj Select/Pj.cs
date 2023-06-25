using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Pj : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    private Button thisButton;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(askToLoadScene);
    }


    void askToLoadScene(){
        SceneManager.LoadScene(sceneToLoad);
    }


}
