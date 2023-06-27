using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsBorder : MonoBehaviour
{
    public static SoundsBorder Instance;
    // sounds
    AudioSource borderOn;
    AudioSource borderOff;
    void Awake(){
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        borderOn = transform.Find("on").GetComponent<AudioSource>();
        borderOff = transform.Find("off").GetComponent<AudioSource>();
    }

    public void soundOn(bool trueOrNot){
        if (trueOrNot){
            borderOn.Play();
        }
        else{
            borderOff.Play();
        }
    }
}
