using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Allow click player to advance scene:
    private bool playerCanClick;
    // Scenes:
    private string[] scenes = {"MainMenu", "HowToPlay", "GameScene"};
    private int sceneCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerCanClick = true;
    }

    void nextScene(){
        playerCanClick = false;
        sceneCount ++;        
        SceneManager.LoadScene(scenes[sceneCount]);
    }
    void Update()
    {
        // This input starts running after the times is up and while the game is correcting the CV.
        if (playerCanClick){
            // Track a single touch as a direction control.
            if (Input.touchCount > 0)
            {         
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        nextScene();
                        //Debug.Log("Working touch");
                        return;
                    }
            }
            else if (Input.GetMouseButtonDown(0)){ 
                nextScene();
                //Debug.Log("Working Click");                
                return;
            }
        }
    }
}
