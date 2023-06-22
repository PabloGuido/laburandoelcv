using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGround : MonoBehaviour
{
    public static BackGround Instance;
    // Scenes:
    private string[] scenes = {"MainMenu", "HowToPlay", "GameScene"};
    private int sceneCount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this){ 
            Destroy(this); 
        } 
        else{ 
            Instance = this; 
            DontDestroyOnLoad(this.gameObject);
        } 
    }

    private void nextScene(){        
        sceneCount ++;        
        SceneManager.LoadScene(scenes[sceneCount]);
    }

    public void askToGoNextScene(){
        nextScene();
    }
    
}
