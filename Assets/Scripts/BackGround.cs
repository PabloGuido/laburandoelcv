using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public static BackGround Instance;
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
    
}
