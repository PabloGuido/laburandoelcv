using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjSelect : MonoBehaviour
{
    public static PjSelect Instance;
    //
    [SerializeField] private GameObject cameraToDisable;
    [SerializeField] private bool DisableCamera;
    //
    public bool playerCanClick;
    public bool PjSelected = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        if (DisableCamera) cameraToDisable.SetActive(false);
        //      
        playerCanClick = false;
        Invoke("allowClick", 1f);
    }

    private void allowClick(){
        Debug.Log("allowing click");
        playerCanClick = true;
    }

}
