using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveMails : MonoBehaviour
{
    public static SaveMails Instance;
    // Win:
    private string mailFolderDirectory;
    private string txtFileDirectory;
    // Andr:
    //private string path = "";
    private string persistentPath = "";
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // mailFolderDirectory = Application.streamingAssetsPath + "/mails/";
        // txtFileDirectory = mailFolderDirectory + "mails" + ".txt";

        // if (!Directory.Exists(mailFolderDirectory)){
        //     Directory.CreateDirectory(Application.streamingAssetsPath + "/mails/");
        //     File.Create(txtFileDirectory);
        //     //Debug.Log("Creating directoryand file.");
        // }
        // else {
        //     //Debug.Log("No need to create directory and file.");
        // }

        
        /////////////////////////////////////////////////////////////////////

        
        
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "/mails/";
        txtFileDirectory = persistentPath + "mails" + ".txt";
        if (!Directory.Exists(persistentPath)){
            Directory.CreateDirectory(persistentPath);
            File.Create(txtFileDirectory);
        }
        
    }

    public void addMailToList(string mailDir){

        File.AppendAllText(txtFileDirectory, mailDir + "\n");
    }



}
