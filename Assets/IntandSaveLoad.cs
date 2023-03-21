using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using TMPro;

public class IntandSaveLoad : MonoBehaviour
{
    public static SaveObject        SaveObject = new();
    public        TextMeshProUGUI   text;
    public        ContentStringText ContentStringText;
    public        SaveFileManager   SaveFileManager;


    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame  
    void Update()
    {
        text.text = SaveObject.Num.ToString();
    }

    public void Inc()
    {
        SaveObject.Num++;
    }

    public void incOver()
    {
        SaveObject.Over++;
    }

    public void IncNumTwo()
    {
        SaveObject.NumTwo++;
    }

    public void Save()
    {
        ES3.Save("SaveData", SaveObject, SaveFileManager.Settings);
    }

    public void RemoveCookies()
    {
        PlayerPrefs.DeleteKey(ES3Settings.defaultSettings.path);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (ES3.KeyExists("SaveData", SaveFileManager.Settings))
        {
            SaveObject = ES3.Load<SaveObject>("SaveData", SaveFileManager.Settings);
        }
    }
}