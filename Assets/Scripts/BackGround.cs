using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGround : MonoBehaviour
{
    public static BackGround Instance;
    // Scenes:
    private string[] scenes = {"MainMenu", "HowToPlay", "EnterData", "GameScene"};
    //private int sceneMaxCount = 0; // then use this number to restart the game at game over.

    private void Awake()
    {
        if (Instance != null){ 
            Destroy(gameObject); 
            return;
        } 

        Instance = this; 
        DontDestroyOnLoad(gameObject);
        
    }

    private void nextScene(int sceneAsking){          
        int nextScene = sceneAsking + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void askToGoNextScene(int sceneAsking){
        nextScene(sceneAsking);
    }
    
}
