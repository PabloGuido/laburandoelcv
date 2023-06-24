using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowPlayerToClick : MonoBehaviour
{
    public static AllowPlayerToClick Instance;
    [HideInInspector] public bool playerInputAllowed = true;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
