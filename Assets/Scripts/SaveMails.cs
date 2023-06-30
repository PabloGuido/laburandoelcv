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
    //
    private string path = "";
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
        SetPaths();
                txtFileDirectory = persistentPath + "mails" + ".txt";
        //File.Create(txtFileDirectory);
        Invoke("SaveData",3);
    }

    public void addMailToList(string mailDir){
        //File.AppendAllText(txtFileDirectory, mailDir + "\n");
    }
    /////////////////////
    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    public void SaveData()
    {
        
        string savePath = persistentPath;

        File.AppendAllText(txtFileDirectory, "234234" + "\n");
        Debug.Log("Saving Data at " + savePath);
        string json = new string("\n 123");
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.WriteLine(json);
        
        
    }

}
