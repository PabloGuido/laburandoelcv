using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveMails : MonoBehaviour
{
    public static SaveMails Instance;
    //
    private string mailFolderDirectory;
    private string txtFileDirectory;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        mailFolderDirectory = Application.streamingAssetsPath + "/mails/";
        txtFileDirectory = mailFolderDirectory + "mails" + ".txt";

        if (!Directory.Exists(mailFolderDirectory)){
            Directory.CreateDirectory(Application.streamingAssetsPath + "/mails/");
            File.Create(txtFileDirectory);
            Debug.Log("Creating directoryand file.");
        }
        else {
            Debug.Log("No need to create directory and file.");
        }

        //Invoke("addMailToList", 5);

        
    }

    public void addMailToList(string mailDir){
        File.AppendAllText(txtFileDirectory, mailDir + "\n");
    }
}
