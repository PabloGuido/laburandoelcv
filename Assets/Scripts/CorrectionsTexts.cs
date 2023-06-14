using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectionsTexts : MonoBehaviour
{
    [HideInInspector] public string[] countDownTexts = new string[10];
    // Start is called before the first frame update
    void Start()
    {
        countDownTexts[0] = "ASDASDASDASDASD";
        Debug.Log(countDownTexts[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
