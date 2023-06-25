using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjSelect : MonoBehaviour
{
    [SerializeField] private GameObject cameraToDisable;
    [SerializeField] private bool DisableCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (DisableCamera) cameraToDisable.SetActive(false);
        //      
    }

}
